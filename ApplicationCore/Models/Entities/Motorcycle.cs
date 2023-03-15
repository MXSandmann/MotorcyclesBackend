using ApplicationCore.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.Entities
{
    public class Motorcycle
    {
        [Key]
        public Guid Id { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public ModelType ModelType { get; set; }
        public int EnginePower { get; set; }
        public double Price { get; set; }
    }
}
