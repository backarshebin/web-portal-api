using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_domain
{
    public class ApiDataResponse<T>
    {
        public ApiDataResponse()
        {
            Data = new List<T>();
        }
        public List<T> Data { get; set; }
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
