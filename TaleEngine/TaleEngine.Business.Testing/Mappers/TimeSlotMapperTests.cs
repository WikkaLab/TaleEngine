//using FluentAssertions;
//using System.Diagnostics.CodeAnalysis;
//using TaleEngine.Fakes.Entities;
//using TaleEngine.Fakes.Models;
//using Xunit;

//namespace TaleEngine.Bussiness.Testing.Mappers
//{
//    [ExcludeFromCodeCoverage]
//    public class TimeSlotMapperTests
//    {
//        [Fact]
//        public void TimeSlot_EntityToModel()
//        {
//            // Arrange
//            var entity = TimeSlotBuilder.BuildTimeSlot();

//            // Act
//            var result = TimeSlotMapper.Map(entity);

//            // Assert
//            result.Id.Should().Be(entity.Id);
//            result.Name.Should().Be(entity.Name);
//        }

//        [Fact]
//        public void TimeSlot_ModelToEntity()
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
