//using Bogus;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;

//namespace TaleEngine.Fakes.Models
//{
//    [ExcludeFromCodeCoverage]
//    public static class EditionModelBuilder
//    {
//        public static EditionModel BuildEditionModel()
//        {
//            var faker = new Faker();

//            var model = new EditionModel
//            {
//                Id = faker.Random.Number(1),
//                EventId = faker.Random.Number(),
//                DateInit = faker.Date.Recent(),
//                DateEnd = faker.Date.Recent()
//            };
//            return model;
//        }

//        public static List<EditionModel> BuildEditionModelList()
//        {
//            return new List<EditionModel>
//            {
//                BuildEditionModel()
//            };
//        }

//        public static EditionDaysModel BuildEditionDaysModel()
//        {
//            var faker = new Faker();

//            var model = new EditionDaysModel
//            {
//                EditionDays = new List<DateTime>
//                {
//                    faker.Date.Recent(),
//                    faker.Date.Recent()
//                }
//            };
//            return model;
//        }
//    }
//}
