
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Registro_de_Empleados.Models;

public class EmpleadosModel
{
    public EmpleadosModel()
    {
    }

    public Guid Id { get; set; }
    
    public string Nombre { get; set; }
    [Required(ErrorMessage = "Se requiere un Nombre")]
    
    public string Apellido { get; set; }
    [Required(ErrorMessage = "Se requiere un Apellido")]
    

    public int Edad { get; set; }
    [Required(ErrorMessage = "Se requiere una Edad")]

    public int Telefono { get; set; }
    [Required(ErrorMessage = "Se requiere un Telefono ")]

    public string Email { get; set; }

    

}