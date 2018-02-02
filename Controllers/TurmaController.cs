using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PanfletoCursos.Dados;
using PanfletoCursos.Models;

namespace PanfletoCursos.Controllers
{
    [Route("api/[controller]")]
    public class TurmaController : Controller
    {
        Turma Turma = new Turma();
        readonly PanfletoContexto contexto;

        public TurmaController(PanfletoContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Turma> Listar()
        {

            return contexto.Turma.ToList();
        }

        [HttpGet("{id}")]
        public Turma Listar(int id)
        {
            return contexto.Turma.Where(x => x.IdTurma == id).FirstOrDefault();
        }

        [HttpPost]
        public void Cadastrar([FromBody]Turma tur)
        {
            contexto.Turma.Add(tur);
            contexto.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody] Turma Turma){
            if(Turma==null || Turma.IdTurma!=id){
            return BadRequest();
            }

            var tur = contexto.Turma.FirstOrDefault(x=>x.IdTurma==id);

            if(tur==null)
            return NotFound();

            tur.IdTurma = Turma.IdTurma;
            tur.DataInicial = Turma.DataInicial;
            tur.DataFinal = Turma.DataFinal;
            tur.Dias = Turma.Dias;
            tur.HorarioInicial = Turma.HorarioInicial;
            tur.HorarioFinal = Turma.HorarioFinal;            
            
            contexto.Turma.Update(tur);
            int rs = contexto.SaveChanges();

            if(rs > 0)
            return Ok();
            else return BadRequest();            
            }

            [HttpDelete("{id}")]
            public IActionResult Deletar(int id){
            var tur = contexto.Turma.Where(x=>x.IdTurma==id).FirstOrDefault();
            if(tur ==null){
                return NotFound();
            }         
            contexto.Turma.Remove(tur);
            int rs = contexto.SaveChanges();
            if(rs > 0)
            return Ok();
            else
            return BadRequest();
            }
        }
    }
