using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net.Http.Headers;

namespace Poseidon.Test
{
    [TestClass]
    public class UploadTest
    {
        private string host = "http://localhost:57123/api/upload";

        private List<ByteArrayContent> GetFileByteArrayContent(List<string> files)
        {
            List<ByteArrayContent> list = new List<ByteArrayContent>();
            foreach(var file in files)
            {
                var fileContent = new ByteArrayContent(File.ReadAllBytes(file));
                fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = Path.GetFileName(file),
                    Name = file
                };
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(MimeMapping.GetMimeMapping(Path.GetFileName(file)));
                

                list.Add(fileContent);
            }

            return list;
        }

        private List<ByteArrayContent> GetFormDataByteArrayContent(NameValueCollection collection)
        {
            List<ByteArrayContent> list = new List<ByteArrayContent>();
            foreach (var key in collection.AllKeys)
            {
                var dataContent = new ByteArrayContent(Encoding.UTF8.GetBytes(collection[key]));
                dataContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    Name = key
                };
                list.Add(dataContent);
            }
            return list;
        }


        public async Task<HttpResponseMessage> Post(string url, List<string> filePath)
        {
            using (HttpClient client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())//表明是通过multipart/form-data的方式上传数据  
                {
                    //var formDatas = this.GetFormDataByteArrayContent(this.GetNameValueCollection(this.gv_FormData));//获取键值集合对应的ByteArrayContent集合  
                    var files = this.GetFileByteArrayContent(filePath);//获取文件集合对应的ByteArrayContent集合  

                    Action<List<ByteArrayContent>> act = (dataContents) =>
                    {
                        //声明一个委托，该委托的作用就是将ByteArrayContent集合加入到MultipartFormDataContent中  
                        foreach (var byteArrayContent in dataContents)
                        {
                            content.Add(byteArrayContent);
                        }
                    };
                    //act(formDatas);//执行act  

                    act(files);//执行act  

                    //var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath.First()));
                    //fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attchment")
                    //{
                    //    FileName = Path.GetFileName(filePath.First())
                    //};
                    //content.Add(fileContent, "file1", "abc.txt");
                    //content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    //{
                    //    FileName = Path.GetFileName(filePath.First())
                    //};


                    var result = await client.PostAsync(url, content);

                    return result;
                }
            }
        }


        public async Task<HttpResponseMessage> Post(string filePath)
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 15);

            try
            {
                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                // 读取文件的 byte[]   
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                fileStream.Close();
                // 把 byte[] 转换成 Stream   
                Stream stream = new MemoryStream(bytes);

                StreamContent scontent = new StreamContent(stream);

                var content = new MultipartFormDataContent();
                content.Add(scontent, "upfile", filePath);

                var result = await client.PostAsync(this.host, content);

                return result;
            }
            catch (HttpRequestException e)
            {
                //throw new PoseidonException($"Http Exception: {e.Message}");
                throw new Exception(e.Message);
            }
        }

        [TestMethod]
        public void TestPost2()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\abc.txt";
            string imgPath = AppDomain.CurrentDomain.BaseDirectory + "\\333.jpg";

            List<string> path = new List<string>();
            path.Add(filePath);
            path.Add(imgPath);

            var task = Task.Run(() =>
            {
                var data = Post(this.host, path);

                return data;
            });

            var result = task.Result;
          
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);

            var resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.AreEqual("", resultContent);
        }


        [TestMethod]
        public void TestMethod1()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\abc.txt";

            var task = Task.Run(() =>
            {
                var data = Post(filePath);

                return data;
            });

            var result = task.Result;

            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
