using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tstdotnet.models
{
    public class BadResponseModel<T>
    {
        public string Status { get; set; } = "badrequest";
        public string Data { get; set; } = null;
        public string Msg { get; set; } = "something went wrong!";


    }
}