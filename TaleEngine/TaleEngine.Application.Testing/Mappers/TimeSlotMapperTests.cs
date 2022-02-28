//using FluentAssertions;
//using System.Diagnostics.CodeAnalysis;
//using TaleEngine.Fakes.Dtos;
//using TaleEngine.Fakes.Models;
//using Xunit;

//namespace TaleEngine.Application.Testing.Mappers
//{
//    [ExcludeFromCodeCoverage]
//    public class TimeSlotMapperTests
//    {
//        [Fact]
//        public void TimeSlot_DtoToModel()
//        {
//            // Arrange
//            var dto = TimeSlotDtoBuilder.BuildTimeSlotDto();

//            // Act
//            var result = TimeSlotMapper.Map(dto);

//            // Assert
//            result.Id.Should().Be(dto.Id);
//            result.Name.Should().Be(dto.Name);
//        }

//        [Fact]
//        public void TimeSlot_ModelToDto()
//        {
//            // Arrange
//            var model = TimeSlotModelBuilder.BuildTimeSlotModel();

//            // Act
//            var result = TimeSlotMapper.Map(model);

//            // Assert
//            result.Id.Should().Be(model.Id);
//            result.Name.Should().Be(model.Name);
//        }

//    }
//}
