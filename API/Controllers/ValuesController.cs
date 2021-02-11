using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        DataContext _dataContext;
        public ValuesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET api/values
        [HttpGet]
        public  ActionResult<IEnumerable<Value>> Get()
        {
            var values = _dataContext.Values.ToList();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<String> Get(int id)
        {
            var value = _dataContext.Values.Find(id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _dataContext.Values.Add (new Value() { Name = value});
            _dataContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string val)
        {
            Value value =  _dataContext.Values.Find(id);
            value.Name = val;
            _dataContext.Values.Update(value);
             _dataContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Value value =  _dataContext.Values.Find(id);
            _dataContext.Values.Remove(value);
             _dataContext.SaveChanges();
        }
    }
}
