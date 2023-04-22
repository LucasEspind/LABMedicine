using LABMedicine.Models;
using Microsoft.EntityFrameworkCore;

namespace LABMedicine.Context
{
    public class labmedicinebdContext : DbContext
    {
        public labmedicinebdContext(DbContextOptions<labmedicinebdContext> options) : base(options) 
        {
            
        }

        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<MedicoModel> Medicos { get; set; }
        public DbSet<EnfermeiroModel> Enfermeiros { get; set; }
    }
}
