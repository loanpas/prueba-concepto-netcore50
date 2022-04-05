using apiPruebaConceptoNet50.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiPruebaConceptoNet50.Models;
using System.Linq;
using System;
using apiPruebaConceptoNet50.Models.Request;

namespace apiPruebaConceptoNet50.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspaciosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllEspacios()
        {
            Response response = new Response();

            try
            {
                using DbPruebaConcepto50Context db = new DbPruebaConcepto50Context();
                var respuestaGet = db.Espacios.ToList();

                response.Codigo = 200;
                response.Data = respuestaGet;
                response.Mensaje = "";
            }
            catch (Exception ex)
            {
                response.Codigo = 400;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetEspaciosById(int id)
        {
            Response response = new Response();

            try
            {
                using DbPruebaConcepto50Context db = new DbPruebaConcepto50Context();                
                Espacio espacio = db.Espacios.Find(id);

                response.Codigo = 200;
                response.Data = espacio;
                response.Mensaje = "";
            }
            catch (Exception ex)
            {
                response.Codigo = 400;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddEspacios(RequestEspacios requestEspacios)
        {
            Response response = new Response();

            try
            {
                using DbPruebaConcepto50Context db = new DbPruebaConcepto50Context();

                Espacio espacio = new Espacio
                {
                    Nombre = requestEspacios.Nombre,
                    Direccion = requestEspacios.Direccion,
                    Descripcion = requestEspacios.Descripcion,
                    Latitud = requestEspacios.Latitud,
                    Longitud = requestEspacios.Longitud
                };

                db.Espacios.Add(espacio);
                db.SaveChanges();

                response.Codigo = 201;                
                response.Mensaje = "Datos creados con éxito !.";                
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateEspacios(RequestEspacios requestEspacios)
        {
            Response response = new Response();

            try
            {
                using DbPruebaConcepto50Context db = new DbPruebaConcepto50Context();

                Espacio espacio = db.Espacios.Find(requestEspacios.Id);

                espacio.Nombre = requestEspacios.Nombre;
                espacio.Direccion = requestEspacios.Direccion;
                espacio.Descripcion = requestEspacios.Descripcion;
                espacio.Latitud = requestEspacios.Latitud;
                espacio.Longitud = requestEspacios.Longitud;

                db.Entry(espacio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                response.Codigo = 201;
                response.Mensaje = "Datos actualizados con éxito !";

            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEspacios(int id)
        {
            Response response = new Response();

            try
            {
                using DbPruebaConcepto50Context db = new DbPruebaConcepto50Context();

                Espacio espacio = db.Espacios.Find(id);
                db.Remove(espacio);
                db.SaveChanges();

                response.Codigo = 200;
                response.Mensaje = "Datos eliminados con éxito !";

            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }
    }

}
