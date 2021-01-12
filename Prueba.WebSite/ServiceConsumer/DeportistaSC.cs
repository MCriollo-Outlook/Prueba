using Prueba.Entity.Dto;
using Prueba.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace Prueba.WebSite.ServiceConsumer
{
    public class DeportistaSC
    {
        private string UrlApi;

        public DeportistaModalidad Create(DeportistaModalidad deportistaModalidad)
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            DeportistaModalidad deportistaModalidadCreate = new DeportistaModalidad();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    UrlApi = string.Format("{0}DeportistaModalidad/Create", ConfigurationManager.AppSettings["UrlApi"]);
                    httpClient.BaseAddress = new Uri(UrlApi);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = httpClient.PostAsync(UrlApi, deportistaModalidad, new JsonMediaTypeFormatter { }).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            deportistaModalidadCreate = JsonConvert.DeserializeObject<DeportistaModalidad>(responseMessage);
                            break;
                        case System.Net.HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            break;
                    }
                }
                return deportistaModalidadCreate;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}