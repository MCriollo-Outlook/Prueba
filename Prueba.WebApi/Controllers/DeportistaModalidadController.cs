using Prueba.BusinessLogic.Class;
using Prueba.Entity.Dto;
using Prueba.Entity.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prueba.WebApi.Controllers
{
    [RoutePrefix("api/DeportistaModalidad")]
    public class DeportistaModalidadController : ApiController
    {
        private DeportistaModalidadBL deportistaModalidadBL;

        public DeportistaModalidadController()
        {
            deportistaModalidadBL = new DeportistaModalidadBL();
        }
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(DeportistaModalidad deportistaModalidad)
        {
            HttpResponseMessage Response = new HttpResponseMessage();
            try
            {
                DeportistaModalidad deportistaModalidadCreate = deportistaModalidadBL.Create(deportistaModalidad);
                Response = Request.CreateResponse(HttpStatusCode.OK, deportistaModalidadCreate);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.ex = ex;
                Response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return Response;
        }
    }
}
