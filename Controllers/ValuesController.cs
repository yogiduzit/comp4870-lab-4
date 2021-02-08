using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        // GET: api/Values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return days;
        }

        // GET: api/Values/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            if (id > -1 && id < days.Count())
                return days[id];
            else
                return "NotFound";

        }

        // POST: api/Values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
