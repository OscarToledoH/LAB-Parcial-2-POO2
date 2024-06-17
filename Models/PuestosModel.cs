using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_de_Empleados.Models;

    public class PuestosModel
    {
        public PuestosModel()
        {
        }

        public Guid Id { get; set; }

        public string Areas { get; set; }
        [Required(ErrorMessage = "Se requiere un Puesto")]

        public int Clave { get; set; }
        [Required(ErrorMessage = "Se requiere una Clave")]

        public int Personas { get; set; }
        [Required(ErrorMessage = "Se requiere el No.Personas")]

        public decimal Salario { get; set; }
        
        

    }
