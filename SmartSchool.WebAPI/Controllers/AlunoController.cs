using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController: ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Vitor",
                Sobrenome = "Soares",
                Telefone = "99999"
            },
            new Aluno(){
                Id = 2,
                Nome = "oiasdasd",
                Sobrenome = "Silva",
                Telefone = "99999"
            },
            new Aluno(){
                Id = 3,
                Nome = "Pedro",
                Sobrenome = "Souza",
                Telefone = "99999"
            }
        };
        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(aluno => aluno.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(aluno => 
                aluno.Nome.Contains(nome) && aluno.Sobrenome.Contains(sobrenome)
            );
            if(aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno){
            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){
            return Ok(aluno);
        }
        [HttpDelete]
        public IActionResult Delete(int id){
            return Ok();
        }
    }
}