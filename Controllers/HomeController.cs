using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UniversidadeFederal.Data;
using UniversidadeFederal.ViewModels;

using Universidade_Federal.Models;

namespace Universidade_Federal.Controllers
{
    public class HomeController : Controller
    {
        //Variável para o contextoo do bd
        private readonly EscolaContexto _context;

        public HomeController(EscolaContexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {

            /*A instrução LINQ usada agrupa as entidades estudantes, 
             * calcula o número de entidades em cada grupo
             * e armazena o resultado em uma coleção de objetos ViewModel DataMatriculaGrupo.*/

            IQueryable<DataMatriculaGrupo> dados = from estudante in _context.Estudantes
                                                   group estudante by estudante.DataMatricula into dateGroup
                                                   select new DataMatriculaGrupo()
                                                   {
                                                       DataMatricula = dateGroup.Key,
                                                       EstudanteContador = dateGroup.Count()
                                                   };

            return View(await dados.AsNoTracking().ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
