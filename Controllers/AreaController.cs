using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PanfletoCursos.Dados;
using PanfletoCursos.Models;

namespace PanfletoCursos.Controllers
{
    [Route("api/[controller]")]
    public class AreaController : Controller
    {
        Area area = new Area();
        readonly PanfletoContexto contexto;

        public AreaController(PanfletoContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Area> Listar()
        {

            return contexto.Area.ToList();
        }

        [HttpGet("{id}")]
        public Area Listar(int id)
        {
            return contexto.Area.Where(x => x.IdArea == id).FirstOrDefault();
        }

        [HttpPost]
        public void Cadastrar([FromBody]Area arere)
        {
            contexto.Area.Add(arere);
            contexto.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Area area)
        {
            if (area == null || area.IdArea != id)
            {
                return BadRequest();
            }

            var are = contexto.Area.FirstOrDefault(x => x.IdArea == id);

            if (are == null)
                return NotFound();

            are.IdArea = area.IdArea;
            are.NomeArea = area.NomeArea;

            contexto.Area.Update(are);
            int rs = contexto.SaveChanges();

            if (rs > 0)
                return Ok();
            else return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var arere = contexto.Area.Where(x => x.IdArea == id).FirstOrDefault();
            if (arere == null)
            {
                return NotFound();
            }
            contexto.Area.Remove(area);
            int rs = contexto.SaveChanges();
            if (rs > 0)
                return Ok();
            else
                return BadRequest();
        }
    }
}
