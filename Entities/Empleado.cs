
using System.ComponentModel.DataAnnotations;

namespace Registro_de_Empleados
{
    public class Empleado
    {
        public Empleado()
        {
        }
        
        public Guid Id { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int Edad { get; set; }

        public int Telefono { get; set; }

        public string Email { get; set; }
    }
}