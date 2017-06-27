using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.Framework
{
    /// <summary>
    /// 抽象WebAPI服务调用类
    /// </summary>
    public abstract class AbstractApiService<T, Tkey> : IBaseService<T, Tkey> where T : IBaseEntity<Tkey>
    {
        #region Field
        /// <summary>
        /// 远程服务根地址
        /// </summary>
        protected string host = "http://localhost:80/api/";

        /// <summary>
        /// 控制器
        /// </summary>
        private string controller;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 抽象WebAPI服务调用类
        /// </summary>
        /// <param name="controller">控制器</param>
        public AbstractApiService(string controller)
        {
            this.controller = controller;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public T FindById(Tkey id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                T entity = default(T);
                string url = host + controller + "/" +id.ToString();
                               
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    entity = response.Content.ReadAsAsync<T>().Result;
                }

                return entity;
            }
        }
        #endregion //Method

        public long Count()
        {
            throw new NotImplementedException();
        }

        public long Count<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public T Create(T entity, bool generateKey)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAllNormal()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public T FindOneByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
       
    }
}
