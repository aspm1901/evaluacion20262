using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecnoGasHogar.Data;
using TecnoGasHogar.Models;

namespace TecnoGasHogar.Controllers;

public class SolicitudesController : Controller
{
    private readonly TecnoGasContext _context;

    public SolicitudesController(TecnoGasContext context)
    {
        _context = context;
    }

    // GET: Solicitudes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Solicitudes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Cliente,Telefono,Distrito,TipoServicio,Descripcion")] SolicitudServicio solicitud)
    {
        if (ModelState.IsValid)
        {
            solicitud.FechaRegistro = DateTime.Now;
            _context.Add(solicitud);
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "¡La solicitud de servicio fue registrada exitosamente!";
            TempData["TipoAlerta"] = "success";

            return RedirectToAction(nameof(Index));
        }

        // Si el modelo no es válido, se retorna a la vista mostrando los errores
        return View(solicitud);
    }

    // GET: Solicitudes
    public async Task<IActionResult> Index()
    {
        var solicitudes = await _context.SolicitudesServicio
            .OrderByDescending(s => s.FechaRegistro)
            .ToListAsync();
        return View(solicitudes);
    }
}
