



using Microsoft.AspNetCore.Mvc;
using Registro_de_Empleados;
using Registro_de_Empleados.Entities;
using Registro_de_Empleados.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Data.SqlClient;

public class PuestosController : Controller
{

    private readonly ApplicationDbContext _context;
    public PuestosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Puestoslist()
    {
        List<PuestosModel> list = new List<PuestosModel>();
        list = _context.Puestos.Select(p => new PuestosModel()
        {
            Id = p.Id,
            Areas = p.Areas,
            Clave = p.Clave,
            Personas = p.Personas,
            Salario = p.Salario
            
        }).ToList();
        return View(list);

    }

    [HttpGet]
    public IActionResult PuestosAdd()
    {
        return View();
    } 
    

    [HttpPost]
    public IActionResult PuestosAdd(PuestosModel puestos)
    {
        if(ModelState.IsValid)
        {
            Puesto p = new Puesto();
            p.Id = new Guid();
            p.Areas = puestos.Areas;
            p.Clave = puestos.Clave;
            p.Personas = puestos.Personas;
            p.Salario = puestos.Salario;

            this._context.Puestos.Add(p);
            this._context.SaveChanges();
            return RedirectToAction("Puestoslist");

        }
        return View();
    } 

    [HttpGet]
    public IActionResult PuestosEdit(Guid Id)
    {
        Puesto? puestosActualizar = this._context.Puestos.Where(p => p.Id == Id).FirstOrDefault();

        if(puestosActualizar == null)
        {
            return RedirectToAction("Puestoslist");
        }

        PuestosModel puestos = new PuestosModel
        {
            Id = puestosActualizar.Id,
            Areas = puestosActualizar.Areas,
            Clave = puestosActualizar.Clave,
            Personas = puestosActualizar.Personas,
            Salario = puestosActualizar.Salario
        };
        return View(puestos);
    }


    [HttpPost]
    public IActionResult PuestosEdit(PuestosModel puestos)
    {
        if(ModelState.IsValid)
        {
            Puesto puestosActualizar = this._context.Puestos.Where(p => p.Id == puestos.Id).First();

            if(puestosActualizar == null)
            {
                return RedirectToAction("Puestoslist");
            }

            puestosActualizar.Id = puestos.Id;
            puestosActualizar.Areas = puestos.Areas;
            puestosActualizar.Clave = puestos.Clave; 
            puestosActualizar.Personas = puestos.Personas;
            puestosActualizar.Salario = puestos.Salario; 

            this._context.Puestos.Update(puestosActualizar);
            this._context.SaveChanges();

            return RedirectToAction("Puestoslist");
        }
        return View(puestos);
    }

    [HttpGet]
    public IActionResult PuestosDelete(Guid Id)
    {
        Puesto? puestosBorrar = this._context.Puestos.Where(p => p.Id == Id).FirstOrDefault();

        if(puestosBorrar == null)
        {
            return RedirectToAction("Puestoslist");
        }

        PuestosModel puestos = new PuestosModel
        {
            Id = puestosBorrar.Id,
            Areas = puestosBorrar.Areas,
            Clave = puestosBorrar.Clave,
            Personas = puestosBorrar.Personas,
            Salario = puestosBorrar.Salario

        };
        return View(puestos);
    }


    [HttpPost]
    public IActionResult PuestosDelete(PuestosModel puestos)
    {
        bool exits = this._context.Puestos.Any(p => p.Id == puestos.Id);
        if(!exits)
        {
            return View(puestos);
        }

        Puesto puestosBorrar = this._context.Puestos.Where(p => p.Id == puestos.Id).First();

        this._context.Puestos.Remove(puestosBorrar);
        this._context.SaveChanges();

        return RedirectToAction("Puestoslist");
    }


}