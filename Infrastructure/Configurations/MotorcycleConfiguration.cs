using ApplicationCore.Models.Entities;
using ApplicationCore.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.Property(x => x.ModelType).HasConversion(x => x.ToString(), x => Enum.Parse<ModelType>(x));
            builder.HasData(
                new Motorcycle
                {
                    Id = Guid.NewGuid(),
                    ModelName = "Bonnevile T100",
                    Company = "Triumph",
                    ModelType = ModelType.Naked,
                    EnginePower = 70,
                    Price = 14000
                },
                new Motorcycle
                {
                    Id = Guid.NewGuid(),
                    ModelName = "KLX110R",
                    Company = "Kawasaki",
                    ModelType = ModelType.Motocross,
                    EnginePower = 7,
                    Price = 3195
                },
                new Motorcycle
                {
                    Id = Guid.NewGuid(),
                    ModelName = "R 1250 RS",
                    Company = "BMW",
                    ModelType = ModelType.Sport,
                    EnginePower = 136,
                    Price = 20000
                });
        }
    }
}
