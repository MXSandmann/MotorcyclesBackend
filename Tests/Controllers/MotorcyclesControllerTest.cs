using ApplicationCore.Models.Dtos;
using ApplicationCore.Models.Entities;
using ApplicationCore.Profiles;
using ApplicationCore.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace Tests.Controllers
{
    public class MotorcyclesControllerTest
    {
        private readonly Mock<IMotorcyclesService> _mockService;
        private readonly IMapper _mapper;
        private readonly MotorcyclesController _sut;

        public MotorcyclesControllerTest()
        {
            _mockService = new Mock<IMotorcyclesService>();
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<AutomapperProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
            _sut = new MotorcyclesController(_mockService.Object, _mapper);
        }

        [Fact]
        public async Task GetAllMotorcycles_ReturnsOkObjectResult_WithListOfMotorcycleDtos()
        {
            // Arrange
            var motorcycles = new List<Motorcycle> { new Motorcycle(), new Motorcycle() };
            _mockService.Setup(service => service.GetAll()).ReturnsAsync(motorcycles);
                
            // Act
            var result = await _sut.GetAllMotorcycles();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var motorcycleDtos = Assert.IsAssignableFrom<IEnumerable<MotorcycleDto>>(okObjectResult.Value);
            Assert.Equal(motorcycles.Count, motorcycleDtos.Count());
        }

        [Fact]
        public async Task Create_ReturnsOkObjectResult_WithListOfMotorcycleDtos()
        {
            // Arrange
            var motorcycleDto = GetTestMotorcycleDtoWithoutId();
            var motorcycle = _mapper.Map<Motorcycle>(motorcycleDto);
            _mockService.Setup(service => service.Add(It.IsAny<Motorcycle>())).ReturnsAsync(new List<Motorcycle> { motorcycle });            

            // Act
            var result = await _sut.Create(motorcycleDto);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var motorcycleDtos = Assert.IsAssignableFrom<IEnumerable<MotorcycleDto>>(okObjectResult.Value);
            Assert.Single(motorcycleDtos);
        }

        [Fact]
        public async Task GetMotorcycleById_ReturnsOkObjectResult_WithMotorcycleDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var motorcycle = new Motorcycle { Id = id };
            _mockService.Setup(service => service.Get(id)).ReturnsAsync(motorcycle);

            // Act
            var result = await _sut.GetMotorcycleById(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var motorcycleDto = Assert.IsAssignableFrom<MotorcycleDto>(okObjectResult.Value);
            Assert.Equal(id, motorcycleDto.Id);
        }

        [Fact]
        public async Task Update_ReturnsOkObjectResult_WithListOfMotorcycleDtos()
        {
            // Arrange
            var id = Guid.NewGuid();
            var motorcycleDto = GetTestMotorcycleDtoWithId(id);
            var motorcycle = _mapper.Map<Motorcycle>(motorcycleDto);
            _mockService.Setup(service => service.Update(It.IsAny<Motorcycle>())).ReturnsAsync(new List<Motorcycle> { motorcycle });
                       
            // Act
            var result = await _sut.Update(motorcycleDto);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var motorcycleDtos = Assert.IsAssignableFrom<IEnumerable<MotorcycleDto>>(okObjectResult.Value);
            Assert.Single(motorcycleDtos);
        }

        [Fact]
        public async Task Remove_ReturnsOkObjectResult_WithListOfMotorcycleDtos()
        {
            // Arrange
            var id = Guid.NewGuid();
            var motorcycle = new Motorcycle { Id = id };
            _mockService.Setup(service => service.Remove(id)).ReturnsAsync(new List<Motorcycle> { motorcycle });

            // Act
            var result = await _sut.Remove(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var motorcycleDtos = Assert.IsAssignableFrom<IEnumerable<MotorcycleDto>>(okObjectResult.Value);
            Assert.Single(motorcycleDtos);
        }

        private static MotorcycleDto GetTestMotorcycleDtoWithoutId()
        {
            return new MotorcycleDto
            {
                ModelName = "testmodel",
                Company = "testcompany",
                ModelType = "Sport",
                EnginePower = 65,
                Price = 9000
            };
        }

        private static MotorcycleDto GetTestMotorcycleDtoWithId(Guid id)
        {
            return new MotorcycleDto
            {
                Id = id,
                ModelName = "testmodel",
                Company = "testcompany",
                ModelType = "Sport",
                EnginePower = 65,
                Price = 9000
            };
        }
    }
}
