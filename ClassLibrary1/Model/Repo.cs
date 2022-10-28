using ClassLibrary1.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClassLibrary1.Model
{
    public class Repo<T> where T : Entity
    {
        public delegate void RepoHandler(RepoEventArgs e);
        public event RepoHandler? Notify;
        public Repo(){
            Load();
        }
        public List<T> list { get; set; }

        public T Read(int id){
            foreach (var entity in list)
                if (entity.EntityId == id)
                {
                    return entity;
                }
            throw new NotFoundEntityException(String.Format("Такой сущности {0} не существует", typeof(T).Name));
            return null;
        }

        public void Add(T entity){
            if (list == null)
                list = new List<T>();
            foreach (var item in list)
                if (entity.Equals(item))
                    throw new ExistingException(String.Format("Сущность {0} уже существует", typeof(T).Name));
            list?.Add(entity);
            this.Save();
            Notify?.Invoke(new RepoEventArgs(string.Format("Добавлена сущность: {0}",
                                                typeof(T).Name)));
        }

        public void Remove(int id){
            foreach (var item in list)
                if (item.EntityId == id){
                    list.Remove(item);
                    this.Save();
                    Notify?.Invoke(new RepoEventArgs(string.Format("Удаление сущности {0}",
                                                        typeof(T).Name)));
                    return;
                }
            throw new NotFoundEntityException(String.Format("Такой сущности {0} не существует", typeof(T).Name));
        }

        public void Update(T oldEntity, T newEntity)
        {
            list.Remove(oldEntity);
            list.Add(newEntity);
            Notify?.Invoke(new RepoEventArgs(string.Format("Обновление сущности: {0}",
                                                        typeof(T).Name)));
        }

        /// <summary>
        /// Формирование имени файла
        /// </summary>
        /// <returns></returns>
        private string FileNameSet() => string.Format("{0}.json", typeof(T).Name);

        /// <summary>
        /// Сохранение в JSON
        /// </summary>
        public void Save(){
            var json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(FileNameSet(), json);
            Notify?.Invoke(new RepoEventArgs(string.Format("Сохранение в файл {0}",
                                                        FileNameSet())));
        }

        /// <summary>
        /// Загрузка из JSON
        /// </summary>
        public void Load()
        {
            list = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(FileNameSet()));
            Notify?.Invoke(new RepoEventArgs(string.Format("Загрузка из файла {0}",
                                                        FileNameSet())));
        }
    }
}
