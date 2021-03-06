﻿using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PanfletoCursos;
using PanfletoCursos.Dados;

namespace PanfletoCursos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ambiente = BuildWebHost(args);
            using (var escopo = ambiente.Services.CreateScope())
            {
                var servico = escopo.ServiceProvider;
                try
                {
                    var contexto = servico.GetRequiredService<PanfletoContexto>();
                    IniciarBanco.Inicializar(contexto);
                }

                catch (Exception e)
                {
                    var saida = servico.GetRequiredService<ILogger<Program>>();
                    saida.LogError(e, "Erro ao criar o banco");
                }
            }

            ambiente.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
