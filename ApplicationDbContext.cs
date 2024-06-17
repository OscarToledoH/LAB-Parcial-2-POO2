using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registro_de_Empleados;
using Registro_de_Empleados.Entities;

namespace Registro_de_Empleados
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Empleado> Empleados {get; set;}

        public DbSet<Puesto> Puestos {get; set;}
    }
}