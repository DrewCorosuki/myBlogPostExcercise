using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.ViewModels
{
    public class ServiceResponseViewModel<T> where T : class
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = "OK";
        public bool ReloadPage { get; set; }
        public List<T> Data { get; set; } = new List<T>();
    }
    public class ServiceResponseSingleItemViewModel
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = "OK";
        public bool ReloadPage { get; set; }
    }
}
