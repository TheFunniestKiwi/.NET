﻿using Lab_08.Data;
using Lab_08.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_08.Controllers
{
    [Route("api/fox")]
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
            return new JsonResult(_repo.GetAll().OrderByDescending(fox=>fox.Loves).ThenBy(fox=>fox.Hates));
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Fox fox)
        {
            _repo.Add(fox);
            return CreatedAtAction(nameof(Get), new { id = fox.Id }, fox);
        }

        [HttpPut("love/{id}")]
        public IActionResult Love(int id)
        {
            var fox = _repo.Get(id);
            if (fox == null)
                return NotFound();
            fox.Loves++;
            _repo.Update(id,fox);
            return Ok(fox);
        }

        [HttpPut("hate/{id}")]
        public IActionResult Hate(int id)
        {
            var fox = _repo.Get(id);
            if (fox == null)
                return NotFound();
            fox.Hates++;
            _repo.Update(id, fox);
            return Ok(fox);
        }

    }
}
