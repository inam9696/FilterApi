using FilterApi.Filters;
using FilterApi.Filters.FilterTask.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class HelloController : ControllerBase
    //{
    //}

    public class InputModel
    {
        public string Value { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : Controller
    {
        // GET: api/<HelloController>
        [ServiceFilter(typeof(ControllerFilter), Order = 1)]
        [ServiceFilter(typeof(ActionFilter), Order = 2)]
        [ServiceFilter(typeof(MethodFilter), Order = 3)]
        [ServiceFilter(typeof(ResponseHeader))]
        [HttpGet]
        public IEnumerable<string> GetList()
        {
            Thread.Sleep(1000);
            return new string[] { "value1", "value2" };
        }

        // GET api/<HelloController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HelloController>
        [HttpPost]
        public void Post([FromBody] InputModel model)
        {
        }

        // PUT api/<HelloController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] InputModel model)
        {
        }

        // PUT api/<HelloController>/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] InputModel model)
        {
            throw new Exception("Error");
        }

        // DELETE api/<HelloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("individual")]
        public IActionResult CustomHeaderResponse()
        {
            HttpContext.Response.Headers.Add("x-my-custom-header", "individual response");
            return Ok();
        }
    }
}
