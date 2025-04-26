using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parcial.Data;
using Parcial.Models;

namespace Parcial.Controllers
{
    
    public class JugadorController : Controller
    {
        private readonly ILogger<JugadorController> _logger;
        private readonly ApplicationDbContext _context;

        public JugadorController(ILogger<JugadorController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Equipos = _context.DbSetEquipo.ToList();
        ViewBag.Posiciones = new List<string> { "Portero", "Defensa", "Delantero"};
        return View();
    }

    // Procesar formulario
    [HttpPost]
    public IActionResult Create(Jugador jugad, int EquipId)
    {
        if (ModelState.IsValid)
        {
            // Verificar si ya existe un jugador con ese nombre en ese equipo
            var jugadorExistente = (from a in _context.DbSetAsociacion
                                    join p in _context.DbSetJugador on a.JugadorId equals p.Id
                                    where p.Nombre == jugad.Nombre && a.EquipoId == EquipId
                                    select a).FirstOrDefault();

            if (jugadorExistente != null)
            {
                ModelState.AddModelError("", "Este jugador ya está registrado en este equipo.");
            }
            else
            {
                // Guardar nuevo jugador
                _context.DbSetJugador.Add(jugad);
                _context.SaveChanges();

                // Crear la relación en Assignment
                var asociacion = new Asociacion
                {
                    
                    EquipoId = EquipId
                };

                _context.DbSetAsociacion.Add(asociacion);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        // Si hay errores, recargar selects
        ViewBag.Equipos = _context.DbSetEquipo.ToList();
        ViewBag.Posiciones = new List<string> { "Portero", "Defensa", "Delantero" };
        return View(jugad);
    }
    }
}