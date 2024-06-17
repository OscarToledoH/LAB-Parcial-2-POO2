using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Registro_de_Empleados.Entities
{
    public class Puesto
    {
        
        public Guid Id { get; set; }

        public string Areas { get; set; }
       

        public int Clave { get; set; }
       

        public int Personas { get; set; }
       

        public decimal Salario { get; set; }


        
    }
}