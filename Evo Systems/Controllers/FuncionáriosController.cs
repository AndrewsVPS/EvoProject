using EvoSystems.Application.Interfaces;
using EvoSystems.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evo_Systems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionáriosController : ControllerBase
    {
        private readonly IFuncionáriosService funcionáriosService;

        public FuncionáriosController(IFuncionáriosService funcionáriosService)
        {
            this.funcionáriosService = funcionáriosService;
        } 

        [HttpGet("{funcionarios}")]
        public IActionResult Get()
        {
            return Ok(this.funcionáriosService.Get());
        }

        [HttpGet("{departamentoId}")]
        public IActionResult GetByDI(int departamentoId)
        {
            return Ok(this.funcionáriosService.GetByDI(departamentoId));
        }

        [HttpGet("one/{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.funcionáriosService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(Funcionários funcionários)
        {
            return NewMethod(funcionários);
        }

        private IActionResult NewMethod(Funcionários funcionários)
        {
            return Ok(this.funcionáriosService.Post(funcionários));
        }

        [HttpPut]
        public IActionResult Put(Funcionários funcionários)
        {
            return Ok(this.funcionáriosService.Put(funcionários));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.funcionáriosService.Delete(id));
        }


    }
}
