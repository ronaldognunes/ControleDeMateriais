using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    [Route("api/[controller]")]
    public class MaterialController : MainController
    {
        // GET: api/<PoloController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PoloController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PoloController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PoloController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PoloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
