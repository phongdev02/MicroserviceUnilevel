using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhanvien.Context;
using Nhanvien.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nhanvien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {
        private readonly UnilevelContext _context;
        public NhanvienController(UnilevelContext context) {
            _context = context;
        }

        // GET: api/<NhanvienController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVien>>> Get()
        {
            return await _context.NhanViens.ToListAsync();
        }

        // GET api/<NhanvienController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NhanvienController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NhanvienController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NhanvienController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
