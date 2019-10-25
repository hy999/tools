using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;
using Microsoft.AspNetCore.Mvc;

namespace tools.Controllers
{
    public class EncryptionController : Controller
    {
        // GET
        [HttpGet]
        [Route("api/v1/encryption/base64")]
        public string base64 (string type,string strEncoding,string contStr,string resStr)
        { 
            
            //type：编码/解码
            //strEncoding:字符串编码格式
            //conStr 字符串
            //resStr 返回的结果
            
            //判断必要字符是否存在
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(contStr))
            {
                return resStr = "There was an err!";
            }
            
            //判断字符编码是否存在
            if (string.IsNullOrEmpty(strEncoding))
            {
                strEncoding = "utf-8";
            }

            try
            {
                //进行base64编码
                if (type == "encode")
                {
                    resStr = EncodeBase64(strEncoding, contStr);
                }
                //进行base64解码
                else if (type == "decode")
                {
                    resStr = DecodeBase64(strEncoding, contStr);
                }
                else
                {
                    resStr = "There was an err!";
                }
            }
            catch (Exception e)
            {
                resStr = "There was an err!";
            }
            
            return resStr.ToString();
        }
        
        [HttpGet]
        [Route("api/v1/encryption/sha256")]
        public string sha256(string contStr,string resStr)
        {
            if (string.IsNullOrEmpty(contStr))
            {
                resStr = "There was an err!";
            }
            else
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contStr);
                   byte[] hash = SHA256Managed.Create().ComputeHash(bytes);
                 
                   StringBuilder builder = new StringBuilder();
                   for (int i = 0; i < hash.Length; i++)
                   {
                          builder.Append(hash[i].ToString("X2"));
                   }
                 
                   resStr= builder.ToString();
            }
            return resStr;
        }
        
        public string EncodeBase64(string codeType, string code)
        {
            string encode = "";
            byte[] bytes = Encoding.GetEncoding(codeType).GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }
        ///base64解码
        public string DecodeBase64(string codeType, string code)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = Encoding.GetEncoding(codeType).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }

        [HttpGet]
        [Route("api/v1/encryption/md5")]
        public string md5(string md5Type,string contStr,string resStr)
        {
            if (string.IsNullOrEmpty(md5Type) && string.IsNullOrEmpty(contStr))
            {
                resStr = "There was an err!";
            }
            else
            {
               if (md5Type == "md516")
               { 
                   MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider(); 
                   string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(contStr)), 4, 8); 
                   resStr = t2.Replace("-", "");
               }
               else if(md5Type=="md532") 
               { 
                   MD5 md5 = MD5.Create();//实例化一个md5对像
                   // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择
                   byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(contStr));
                   // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
                   for (int i = 0; i < s.Length; i++)
                   {
                       // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
                       resStr = resStr + s[i].ToString("X");
                   }
               }
               else
               {
                   resStr = "There was an err!";
               }
            }
            return resStr;
        }
    }
}