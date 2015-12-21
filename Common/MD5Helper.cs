using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MD5Helper
{
    public static class MD5Helper
    {
        public static string ComputeMd5File(string path)
        {
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                MD5 md5 = MD5.Create();
                //计算文件的md5值的时候，直接把文件流传递到ComputHash()方法中
                //然后在该方法内部会读取字节内容。
                byte[] bytesMd5 = md5.ComputeHash(fs);
                md5.Clear();
                //把bytesMd5，这个字节数组转换为字符串，不能调用Encoding.UTF8.GetString();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytesMd5.Length; i++)
                {
                    //"x2",表示如果这个数字是一个个位数的话，也要显示两位，即，前面要补一个0
                    sb.Append(bytesMd5[i].ToString("x2")); //x表示转换为16进制字符串
                }

                return sb.ToString();
            }
        }


        //计算字符串的Md5
        public static string ComputeMd5String(string userInput)
        {
            //1.创建一个md5对象
            MD5 md5 = MD5.Create();
            //2.获取字符串的byte[]
            //因为同一个字符串，使用不同编码计算出的byte[]数组内容不同，所以有可能同一个字符串的两次计算的Md5值不一样。解决：采用统一的编码方式。
            byte[] bytes = System.Text.Encoding.Default.GetBytes(userInput);
            //调用ComputeHash()方法来计算Md5值。
            byte[] bytesMd5 = md5.ComputeHash(bytes);
            md5.Clear();


            //把bytesMd5，这个字节数组转换为字符串，不能调用Encoding.UTF8.GetString();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytesMd5.Length; i++)
            {
                //"x2",表示如果这个数字是一个个位数的话，也要显示两位，即，前面要补一个0
                sb.Append(bytesMd5[i].ToString("x2")); //x表示转换为16进制字符串
            }

            return sb.ToString();
        }
    }
}
