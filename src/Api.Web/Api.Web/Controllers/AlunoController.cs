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

            return Ok(new { mensagem = "Aluno cadastrado com sucesso!" });
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] Aluno aluno)
        {
            var dadosDoAluno = _listaDeAlunos.FirstOrDefault(x => x.Id == id);

            dadosDoAluno.Nome = aluno.Nome;
            dadosDoAluno.Idade = aluno.Idade;
            dadosDoAluno.Telefone = aluno.Telefone;

            _listaDeAlunos.Add(dadosDoAluno);

            return Ok();
        }

        [HttpGet]
        public IEnumerable<Aluno> Listar()
        {
            return _listaDeAlunos;
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            var aluno = _listaDeAlunos.FirstOrDefault(x => x.Id == id);
            if (aluno is not null)
            {
                return Ok(aluno);
            }

            return NotFound(new { mensagem = "Aluno não encontrado"});
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var aluno = _listaDeAlunos.FirstOrDefault(x => x.Id == id);
            _listaDeAlunos.Remove(aluno);

            return Ok();
        }
    }
}
