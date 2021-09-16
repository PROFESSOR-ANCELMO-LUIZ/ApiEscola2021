using Api.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        protected static IList<Aluno> _listaDeAlunos = new List<Aluno>();

        [HttpPost]
        public IActionResult Adicionar([FromBody] Aluno aluno)
        {
            var novoAluno = new Aluno { 
                Id = aluno.Id,
                Nome = aluno.Nome,
                Idade = aluno.Idade,
                Telefone = aluno.Telefone
            };

            _listaDeAlunos.Add(novoAluno);

            return Ok();
        }

        [HttpGet]
        public IEnumerable<Aluno> Listar()
        {
            return _listaDeAlunos;
        }

        [HttpGet("{id}")]
        public Aluno Buscar(int id)
        {
            var aluno = _listaDeAlunos.FirstOrDefault(x => x.Id == id);

            return aluno;
        }
    }
}
