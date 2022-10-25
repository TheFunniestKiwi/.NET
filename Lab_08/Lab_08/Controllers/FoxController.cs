using Lab_08.Data;
using Lab_08.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoxController : ControllerBase
    {
        private readonly IFoxesRepository _repo;

        public FoxController(IFoxesRepository repository)
        {
            _repo = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _repo.Get(id);
            if(obj == null)
                return NotFound();
            return new JsonResult(obj);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_repo.GetAll());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Fox fox)
        {
            _repo.Add(fox);
            return CreatedAtAction(nameof(Get), new { id = fox.Id }, fox);
        }
        

    }
}
