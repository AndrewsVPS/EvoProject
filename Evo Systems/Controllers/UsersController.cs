using EvoSystems.Application.Interfaces;
using EvoSystems.Application.Services;
using EvoSystems.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evo_Systems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService DepartamentoService;
        public DepartamentoController(IDepartamentoService DepartamentoService)
        {
            this.DepartamentoService = DepartamentoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.DepartamentoService.Get());
        }

        [HttpPost]
        public IActionResult Post(UserViewModel userViewModel)
        {
            return Ok(this.DepartamentoService.Post(userViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.DepartamentoService.GetById(id));
        }
        
        [HttpPut]
        public IActionResult Put(UserViewModel userViewModel)
        {
            return Ok(this.DepartamentoService.Put(userViewModel));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(string id)
        {
            return Ok(this.DepartamentoService.Delete(id));
        }

    }
}
