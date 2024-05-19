using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tstdotnet.models;
using tstdotnet.Service;

namespace tstdotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncryptController : ControllerBase
    {

        [HttpGet("GetEncrypt")]
        public ActionResult<List<string>> GetEncryptwithoutName()
        {
            var products = new List<string>();
            products.Add("VueJS");
            products.Add("Flutter");
            products.Add("React");
            return Ok(products);
        }

        [HttpGet(Name = "GetEncrypt")]
        public ActionResult<List<string>> GetEncryptwithName()
        {
            var products = new List<string>();
            products.Add("VueJS");
            products.Add("Flutter");
            products.Add("React");
            return Ok(products);
        }

        [HttpPost("QueryEncrypt")]
        public ActionResult<List<string>> QueryEncryptwithoutName(EncryptModel encryptModel)
        {
            try
            {
                var iv = encryptModel.data.Substring(0, 16);
                var data = EncryptServiceClass.DecryptString(encryptModel.data.Substring(16), iv);
                var dataEncrypt = EncryptServiceClass.EncryptString("something wrong with big", iv);
                return Ok(new SuccessResponseModel<object>(iv + dataEncrypt));
            }
            catch (Exception e)
            {
                return BadRequest(new BadResponseModel<object>());
            }





        }
    }
}