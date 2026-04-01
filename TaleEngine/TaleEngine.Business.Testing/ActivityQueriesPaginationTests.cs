using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.CQRS.Queries;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class ActivityQueriesPaginationTests
    {
        [Fact]
        public void ActiveActivitiesFilteredQuery_ShouldApplyPaginationAndCalculateTotalPages()
        {
            // Arrange
            const int editionId = 1;
            const int userId = 10;

            var request = new ActivityFilterRequest
            {
                EditionId = editionId,
                Page = 1,
                Title = string.Empty,
                TimeFrames = new List<int>()
            };

            var editionServiceMock = new Mock<IEditionService>();
            var activityServiceMock = new Mock<IActivityService>();

            var allFilteredActivities = Enumerable.Range(1, 7)
                .Select(i => new ActivityEntity
                {
                    Id = i,
                    Title = $"Activity {i}",
                    EditionId = editionId
                })
                .ToList();

            editionServiceMock.Setup(x => x.GetById(editionId))
                .Returns(new EditionEntity { Id = editionId });

            activityServiceMock.Setup(x => x.GetActiveActivitiesFiltered(
                    request.TypeId,
                    editionId,
                    request.TimeFrames,
                    request.Title,
                    userId))
                .Returns(allFilteredActivities);

            var target = new ActivityQueries(activityServiceMock.Object, editionServiceMock.Object);

            // Act
            var result = target.ActiveActivitiesFilteredQuery(request, userId);

            // Assert
            result.Should().NotBeNull();
            result.CurrentPage.Should().Be(1);
            result.TotalPages.Should().Be(3);
            result.Activities.Should().NotBeNull();
            result.Activities.Should().HaveCount(3);
            result.Activities.Select(a => a.Id).Should().Equal(new[] { 4, 5, 6 });
        }
    }
}
