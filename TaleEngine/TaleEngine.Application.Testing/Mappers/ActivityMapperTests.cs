//using FluentAssertions;
//using System.Diagnostics.CodeAnalysis;
//using TaleEngine.Fakes.Dtos;
//using TaleEngine.Fakes.Models;
//using Xunit;

//namespace TaleEngine.Application.Testing.Mappers
//{
//    [ExcludeFromCodeCoverage]
//    public class ActivityMapperTests
//    {
//        [Fact]
//        public void Activity_DtoToModel()
//        {
//            // Arrange
//            var dto = ActivityDtoBuilder.BuildActivityDto();

//            // Act
//            var result = ActivityMapper.Map(dto);

//            // Assert
//            result.Id.Should().Be(dto.Id);
//            result.Title.Should().Be(dto.Title);
//            result.Description.Should().Be(dto.Description);
//            result.Places.Should().Be(dto.Places);
//            result.Image.Should().Be(dto.Image);
//            result.StatusId.Should().Be(dto.StatusId);
//            result.TimeSlotId.Should().Be(dto.TimeSlotId);
//            result.TypeId.Should().Be(dto.TypeId);
//        }

//        [Fact]
//        public void Activity_ModelToDto()
//        {
//            // Arrange
//            var model = ActivityModelBuilder.BuildActivityModel();

//            // Act
//            var result = ActivityMapper.Map(model);

//            // Assert
//            result.Id.Should().Be(model.Id);
//            result.Title.Should().Be(model.Title);
//            result.Description.Should().Be(model.Description);
//            result.Places.Should().Be(model.Places);
//            result.Image.Should().Be(model.Image);
//            result.StatusId.Should().Be(model.StatusId);
//            result.TimeSlotId.Should().Be(model.TimeSlotId);
//            result.TypeId.Should().Be(model.TypeId);
//        }

//    }
//}
