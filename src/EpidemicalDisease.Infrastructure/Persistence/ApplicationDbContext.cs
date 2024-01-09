using EpidemicalDisease.Application.Common.Interfaces;
using EpidemicalDisease.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpidemicalDisease.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons => Set<Person>();

        public DbSet<DiseaseAnalysis> DiseaseAnalyzes => Set<DiseaseAnalysis>();

        public DbSet<MedicalCenter> MedicalCenters => Set<MedicalCenter>();

        public DbSet<Vaccine> Vaccines => Set<Vaccine>();

        public DbSet<VaccineType> VaccineTypes => Set<VaccineType>();
        //Diğer entityler aynı şekilde eklencek




        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
