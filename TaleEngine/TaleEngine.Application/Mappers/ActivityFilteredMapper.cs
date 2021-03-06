﻿using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Dtos.Results;
using TaleEngine.Bussiness.Contracts.Models.Results;

namespace TaleEngine.Application.Mappers
{
    public static class ActivityFilteredMapper
    {
        public static ActivityFilteredResult Map(ActivityFilteredResultModel model)
        {
            if (model == null) return null;

            var mappedActivities = new List<ActivityDto>();

            if (model == null || model.Activities == null)
            {
                return null;
            }

            foreach (var act in model.Activities)
            {
                mappedActivities.Add(ActivityMapper.Map(act));
            }

            var result = new ActivityFilteredResult
            {
                Activities = mappedActivities,
                CurrentPage = model.CurrentPage,
                TotalPages = model.TotalPages
            };

            return result;
        }
    }
}
