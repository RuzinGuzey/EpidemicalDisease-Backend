using EpidemicalDisease.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpidemicalDisease.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; }
        DbSet<DiseaseAnalysis> DiseaseAnalyzes { get; }
        DbSet<MedicalCenter> MedicalCenters { get; }
        DbSet<Vaccine> Vaccines { get; }
        DbSet<VaccineType> VaccineTypes { get; }


        //Diğer entityler aynı şekilde eklencek

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
