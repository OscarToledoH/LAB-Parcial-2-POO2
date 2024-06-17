
using Registro_de_Empleados.Models;
using Microsoft.AspNetCore.Mvc;
using Registro_de_Empleados;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class EmpleadosController : Controller
{

    private readonly ApplicationDbContext _context;
    public EmpleadosController(ApplicationDbContext context)
    {
        _context = context;

    }

    //ESTA PARTE ES PARA COLOCAR LOS DATOS QUE QUIERES REGISTRAR EN LA TABLA DE LA VISTA QUE CREASTE
    public IActionResult Empleadoslist()
    {
        List<Empleado> list = new List<Empleado>();
        list = _context.Empleados.Select(e => new Empleado()
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            Edad = e.Edad,
            Telefono = e.Telefono,
            Email = e.Email
        }).ToList();
        return View(list);

    }

    [HttpGet]
    public IActionResult EmpleadosAdd()
    {
        return View();
    }


    //ESTA FUNCION TE PERMITE REGISTRAR LOS DATOS EN LA BASE DE DATOS , TIENE QUE TENER HTTPOS PORQUE SE REPITE EL "EmpleadosAdd" 
    [HttpPost]
    public IActionResult EmpleadosAdd(EmpleadosModel model)
    {
        if (ModelState.IsValid)
        {


            Empleado e = new Empleado();
            e.Id = new Guid();
            e.Nombre = model.Nombre;
            e.Apellido = model.Apellido;
            e.Edad = model.Edad;
            e.Telefono = model.Telefono;
            e.Email = model.Email;

            this._context.Empleados.Add(e);
            this._context.SaveChanges();
            return RedirectToAction("Empleadoslist");

        } 
        return View();
    }




    [HttpGet]
    public IActionResult EmpleadosEdit(Guid Id)
    {
        Empleado? empleadoActualizar = this._context.Empleados.Where(e => e.Id == Id).FirstOrDefault();

        //VALIDACION SI NO LO ENCUENTRA
        if (empleadoActualizar == null)
        {
            return RedirectToAction("Empleadoslist");
        }

        //SE ASIGNA LA INFO DE LA BD AL MODELO

        EmpleadosModel model = new EmpleadosModel
        {
        Id = empleadoActualizar.Id,
        Nombre = empleadoActualizar.Nombre,
        Apellido = empleadoActualizar.Apellido,
        Edad = empleadoActualizar.Edad,
        Telefono = empleadoActualizar.Telefono,
        Email = empleadoActualizar.Email
        };
            return View(model);
    }




    //ES LA SEGUNDA EMPLEADOSEDIT 
    [HttpPost]
    public IActionResult EmpleadosEdit(EmpleadosModel model)
    {
        
        if (ModelState.IsValid)
        {
            Empleado empleadoActualizar = this._context.Empleados.Where(e => e.Id == model.Id).First();
        
            //LA VALIDACION
            if(empleadoActualizar == null)
            {
                return RedirectToAction("Empleadoslist");
            }

            empleadoActualizar.Id = model.Id;
            empleadoActualizar .Nombre = model.Nombre;
            empleadoActualizar.Apellido = model.Apellido;
            empleadoActualizar.Edad = model.Edad;
            empleadoActualizar.Telefono = model.Telefono;
            empleadoActualizar.Email = model.Email;

            this._context.Empleados.Update(empleadoActualizar);
            this._context.SaveChanges();

            return RedirectToAction("Empleadoslist");


        }
        return View(model);
        
    }



    [HttpGet]
    public IActionResult EmpleadosDelete(Guid Id)
    {
        Empleado? empleadosBorrar = this._context.Empleados.Where(e => e.Id == Id).FirstOrDefault();

        if (empleadosBorrar == null)
        {
            return RedirectToAction("Empleadoslist");
        }

        EmpleadosModel model = new EmpleadosModel
        {
            Id = empleadosBorrar.Id,
            Nombre=empleadosBorrar.Nombre,
            Apellido= empleadosBorrar.Apellido,
            Edad=empleadosBorrar.Edad,
            Telefono=empleadosBorrar.Telefono,
            Email= empleadosBorrar.Email
        };
        return View(model);

    }

    
    [HttpPost]
    public IActionResult EmpleadosDelete(EmpleadosModel model)
    {
            bool exits = this._context.Empleados.Any(e => e.Id == model.Id);
            if(!exits)
            {
                return View(model);
            }

            Empleado empleadosBorrar = this._context.Empleados.Where(e => e.Id == model.Id).First();


            this._context.Empleados.Remove(empleadosBorrar);
            this._context.SaveChanges();

            return RedirectToAction("Empleadoslist");
        
        
    }
} 
    