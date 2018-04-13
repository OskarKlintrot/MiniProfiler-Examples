using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StackExchange.Profiling;
using Profiler = StackExchange.Profiling.MiniProfiler;

namespace MiniProfiler.Api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" }; 
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            var profiler = Profiler.Current;

            using (profiler.Step($"{nameof(Post)} - {value}"))
            {
                System.Threading.Thread.Sleep(new Random().Next(50, 500));
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        { }

        // DELETE api/values/5
        public void Delete(int id)
        { }
    }
}
