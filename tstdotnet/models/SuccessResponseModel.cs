using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tstdotnet.models
{
    public class SuccessResponseModel<T>
    {

        public string Status { get; set; } = "success";
        public T Data { get; set; }
        public string Msg { get; set; } = null;

        public SuccessResponseModel(T data)
        {

            Data = data;

        }
    }
}