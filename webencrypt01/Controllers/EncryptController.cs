using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webencrypt01.Controllers
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
                var data = AesEncryptionService.DecryptString(encryptModel.data.Substring(16),iv);
                var dataEncrypt = AesEncryptionService.EncryptString("something wrong with big",iv);
                return Ok(new SuccessResponseModel<object>(iv+ dataEncrypt));
            }
            catch (Exception e)
            {
                return BadRequest(new BadResponseModel<object>());
            }
           
          
         

           
        }
    }

    public class EncryptModel
    {
        public string data { get; set; }

    }

    public class SuccessResponseModel<T>
    {
        public string Status { get; set; } = "success";
        public T Data { get; set; }
        public string Msg { get; set; } = null;

        public SuccessResponseModel( T data)
        {
          
            Data = data;
           
        }
    }

    public class NotFoundResponseModel<T>
    {
        public string Status { get; set; } = "success";
        public T Data { get; set; }
        public string Msg { get; set; } = "Not found item";

        public NotFoundResponseModel(T data)
        {

            Data = data;

        }
    }

    public class BadResponseModel<T>
    {
        public string Status { get; set; } = "badrequest";
        public string Data { get; set; } = null;
        public string Msg { get; set; } = "something went wrong!";

      
    }
}


public static class AesEncryptionService
{
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); // Ensure your key is 16, 24, or 32 bytes
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("zU7XBVHwmp/rjC++8KguOQ=="); // Ensure your IV is 16 bytes

    public static string EncryptString(string plainText,string iv)
    {
        using (var aes = Aes.Create())
        {
         
            aes.Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); ;
            aes.IV = Encoding.UTF8.GetBytes(iv);

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    public static string DecryptString(string cipherText,string iv)
    {

        var buffer = Convert.FromBase64String(cipherText);

        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            aes.IV = Encoding.UTF8.GetBytes(iv);

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (var ms = new MemoryStream(buffer))
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            using (var sr = new StreamReader(cs))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
