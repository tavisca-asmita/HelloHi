using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Greetings!!";
        }

        // GET api/values/5
        [HttpGet("{val}")]
        public ActionResult<string> Get(string val)
        {
            if (val.Equals("Hi"))
                return "Hello";
            else if (val.Equals("Hello"))
                return "Hi";
            else
                return ("Hi " + val);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
