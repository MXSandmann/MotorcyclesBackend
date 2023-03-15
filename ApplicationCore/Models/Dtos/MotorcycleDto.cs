namespace ApplicationCore.Models.Dtos
{
    public class MotorcycleDto
    {
        public Guid Id { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string ModelType { get; set; } = string.Empty;
        public int EnginePower { get; set; }
        public double Price { get; set; }
    }
}
