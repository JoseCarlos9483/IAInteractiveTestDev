using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Response
{
    public class ResponseGeneric<T> where T : class
    {
        public ResponseGeneric()
        {
            Success = true;
        }

        public bool Success { get; set; }
        public T? Response { get; set; }
        //public IList<T>? ResponseTolist { get; set; }
        public Error? Error { get; set; }

    }

    public class Error {
        
        public string Message { get; set; }
        public string Code { get; set; }
        public string MessageFront { get; set; }
        public string Name { get; set; }
    }
}
