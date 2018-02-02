using System.Linq;
using PanfletoCursos.Models;

namespace PanfletoCursos.Dados
{
    public class IniciarBanco
    {
        public static void Inicializar(PanfletoContexto contexto){
            contexto.Database.EnsureCreated();

            if (contexto.Area.Any())
            { 
                return; 
            }
            var area = new Area()
            {   
                NomeArea = "Empreendedorismo"                        
            };
            contexto.Area.Add(area);
            contexto.SaveChanges();
        }
    }
}