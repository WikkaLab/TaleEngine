using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Fakes.Models
{
    [ExcludeFromCodeCoverage]
    public static class TimeSlotModelBuilder
    {
        public static TimeSlotModel BuildTimeSlotModel()
        {
            var faker = new Faker();

            var model = new TimeSlotModel
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return model;
        }

        public static List<TimeSlotModel> BuildTimeSlotModelList()
        {
            List<TimeSlotModel> list = new List<TimeSlotModel>
            {
                BuildTimeSlotModel()
            };
            return list;
        }
    }
}
