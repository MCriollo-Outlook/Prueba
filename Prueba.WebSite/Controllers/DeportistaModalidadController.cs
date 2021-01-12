using Prueba.Entity.Entities;
using Prueba.WebSite.ServiceConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba.WebSite.Controllers
{
    public class DeportistaModalidadController : Controller
    {
        private DeportistaSC DeportistaSC;

        // Constructor
        public DeportistaModalidadController()
        {
            DeportistaSC = new DeportistaSC();
        }

        // GET: Deportista
        public ActionResult List()
        {
            return View();
        }

        public ActionResult CreateDeportistaModalidad(DeportistaModalidad deportistaModalidad)
        {
            deportistaModalidad.IdDeportista = 1;
            deportistaModalidad.IdModalidad = 1;
            deportistaModalidad.Peso = 140;
            deportistaModalidad = DeportistaSC.Create(deportistaModalidad);
            return RedirectToAction("List");
        }
    }
}