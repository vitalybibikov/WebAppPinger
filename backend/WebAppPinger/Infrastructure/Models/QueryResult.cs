using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPinger.Infrastructure.ViewModels
{
    public class QueryResult
    {
        public string Message { get; set; }

        public bool Succsess { get; set; }

        public object Data { get; set; }
    }
}