using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class RepoEventArgs
    {
        public string Message { get; }
        public RepoEventArgs(string message){
            Message = message;
        }
    }
}
