using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.Framework
{
    using Poseidon.Base.System;
    using Poseidon.Common;

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
        protected string controller;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 抽象WebAPI服务调用类
        /// </summary>
        /// <param name="controller">控制器</param>
        public AbstractApiService(string controller)
        {
            this.host = Cache.Instance["ApiHost"].ToString();
            this.controller = controller;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        protected virtual T GetEntity(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                T entity = default(T);

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    entity = response.Content.ReadAsAsync<T>().Result;
                }

                return entity;
            }
        }

        /// <summary>
        /// 异步获取实体
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        protected virtual async Task<T> GetEntityAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                var entity = response.Content.ReadAsAsync<T>();
                return await entity;
            }
        }

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        protected virtual List<T> GetList(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(url).Result;

                response.EnsureSuccessStatusCode();
                var entity = response.Content.ReadAsAsync<List<T>>().Result;

                return entity;
            }
        }

        /// <summary>
        /// 异步获取实体列表
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        protected virtual async Task<List<T>> GetListAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                var entity = response.Content.ReadAsAsync<List<T>>();

                return await entity;
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual T FindById(Tkey id)
        {
            string url = host + controller + "/" + id.ToString();
            T entity = GetEntity(url);

            return entity;
        }

        /// <summary>
        /// 异步根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual async Task<T> FindByIdAsync(Tkey id)
        {
            string url = host + controller + "/" + id.ToString();
            return await GetEntityAsync(url);
        }

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAll()
        {
            string url = host + controller;
            var entity = GetList(url);
            return entity;
        }

        /// <summary>
        /// 异步查找所有对象
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> FindAllAsync()
        {
            string url = host + controller;
            return await GetListAsync(url);
        }

        /// <summary>
        /// 按状态查找对象
        /// </summary>
        /// <param name="status">对象状态</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindByStatus(EntityStatus status)
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

        /// <summary>
        /// 按ID列表查找记录
        /// </summary>
        /// <param name="values">ID列表</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindListInIds(List<Tkey> values)
        {
            throw new NotImplementedException();
        }

        public T FindOneByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

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

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Tkey id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 标记删除对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        public virtual void MarkDelete(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 标记删除对象
        /// </summary>
        /// <param name="id">ID</param>
        public virtual void MarkDelete(Tkey id)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }

    /// <summary>
    /// 抽象WebAPI服务调用类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class AbstractApiService<T> : AbstractApiService<T, string> where T : BaseEntity
    {
        #region Constructor
        /// <summary>
        /// 抽象WebAPI服务调用类
        /// </summary>
        /// <param name="controller">控制器</param>
        public AbstractApiService(string controller) : base(controller)
        {
        }
        #endregion //Constructor
    }
}
