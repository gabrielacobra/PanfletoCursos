using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PanfletoCursos.Dados;
using PanfletoCursos.Models;

namespace PanfletoCursos.Controllers
{
    [Route("api/[controller]")]
    public class CursoController : Controller
    {
        Curso curso = new Curso();
        readonly PanfletoContexto contexto;

        public CursoController(PanfletoContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Curso> Listar()
        {

            return contexto.Curso.ToList();
        }

        [HttpGet("{id}")]
        public Curso Listar(int id)
        {
            return contexto.Curso.Where(x => x.IdCurso == id).FirstOrDefault();
        }

        [HttpPost]
        public void Cadastrar([FromBody]Curso cur)
        {
            contexto.Curso.Add(cur);
            contexto.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody] Curso Curso){
            if(Curso==null || Curso.IdCurso!=id){
            return BadRequest();
            }

            var cur = contexto.Curso.FirstOrDefault(x=>x.IdCurso==id);

            if(cur==null)
            return NotFound();

            cur.IdCurso = Curso.IdCurso;
            cur.NomeCurso = Curso.NomeCurso;

            contexto.Curso.Update(cur);
            int rs = contexto.SaveChanges();

            if(rs > 0)
            return Ok();
            else return BadRequest();            
            }

            [HttpDelete("{id}")]
            public IActionResult Deletar(int id){
            var curss = contexto.Curso.Where(x=>x.IdCurso==id).FirstOrDefault();
            if(curss ==null){
                return NotFound();
            }         
            contexto.Curso.Remove(curss);
            int rs = contexto.SaveChanges();
            if(rs > 0)
            return Ok();
            else
            return BadRequest();
            }
        }
    }
