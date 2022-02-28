//using FluentAssertions;
//using System.Diagnostics.CodeAnalysis;
//using TaleEngine.Fakes.Entities;
//using TaleEngine.Fakes.Models;
//using Xunit;

//namespace TaleEngine.Bussiness.Testing.Mappers
//{
//    [ExcludeFromCodeCoverage]
//    public class ActivityTypesMapperTests
//    {
//        [Fact]
//        public void ActivityType_EntityToModel()
//        {
//            // Arrange
//            var entity = ActivityBuilder.BuildActivityType();

//            // Act
//            var result = ActivityTypeMapper.Map(entity);

//            // Assert
//            result.Id.Should().Be(entity.Id);
//            result.Name.Should().Be(entity.Name);
//        }

//        [Fact]
//        public void ActivityType_ModelToEntity()
//        {
//            // Arrange
//            var model = ActivityModelBuilder.BuildActivityTypeModel();

//            // Act
//            var result = ActivityTypeMapper.Map(model);

//            // Assert
//            result.Id.Should().Be(model.Id);
//            result.Name.Should().Be(model.Name);
//        }

//    }
//}
