using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private DataContext _dataContext;
        public AuthorsController(DataContext context)
        {
            _dataContext = context;
        }    

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
            var authors = await _dataContext.Authors.ToListAsync();
            return Ok(authors);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            var author = await _dataContext.Authors.FindAsync(id);
            return Ok(author);
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody] Author author)
        {
            await _dataContext.Authors.AddAsync(author);
            await _dataContext.SaveChangesAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public  async void Put(int id, [FromBody] Author auth)
        {
            Author author = await _dataContext.Authors.FindAsync(id);
            author.FirstName = auth.FirstName;
            author.LastName = auth.LastName;
            _dataContext.Authors.Update(author);
            await _dataContext.SaveChangesAsync();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            Author author = await _dataContext.Authors.FindAsync(id);
            if (author != null)
            {
              _dataContext.Authors.Remove(author);
              await _dataContext.SaveChangesAsync();
            }
        }
    }
}
