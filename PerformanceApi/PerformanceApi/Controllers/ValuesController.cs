using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace PerformanceApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IMemoryCache _cache;

        public ValuesController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            List<Produto> produtos = new List<Produto>();

            Produto prod;
            for (int i = 1; i <= 200; i++)
            {
                prod = new Produto();
                prod.CodProduto = null; // i.ToString("0000");
                prod.NomeProduto = string.Format("PRODUTO {0:0000}", i);
                prod.Preco = i / 10.0;

                produtos.Add(prod);
            }

            return produtos;
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<DateTime> Get(int id)
        {
            List<DateTime> datas = new List<DateTime>();
            DateTime dataCache = _cache.GetOrCreate<DateTime>(
                "TesteCache", context =>
                {
                    context.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                    context.SetPriority(CacheItemPriority.High);

                    return DateTime.Now;
                });

            datas.Add(dataCache);
            datas.Add(DateTime.Now);

            return datas;
        }
    
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
