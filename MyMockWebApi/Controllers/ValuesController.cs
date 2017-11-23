using MyMockWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyMockWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public object Get()
        {
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/Data.json"));
            return JsonConvert.DeserializeObject(text);
        }

        // GET api/values/5
        public EventData Get(int id)
        {
            try
            {
                var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/Data.json"));
                return JsonConvert.DeserializeObject<IEnumerable<EventData>>(text).FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                return null;
            }
        }

        // POST api/values
        public IEnumerable<EventData> Post([FromUri]int pageNum, [FromUri]int pageSize, [FromBody]IEnumerable<string> areas)
        {
            var text = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/Data.json"));
            var obj = JsonConvert.DeserializeObject<IEnumerable<EventData>>(text);
            var itemsToSkip = (pageNum - 1) * pageSize;
            return obj.Where(a => areas.Contains(a.Location, StringComparer.InvariantCultureIgnoreCase)).OrderBy(a => a.DateTime).ThenBy(a => a.Title).Skip(itemsToSkip).Take(pageSize);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
