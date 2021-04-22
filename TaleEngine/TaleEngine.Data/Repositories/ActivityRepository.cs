using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DatabaseContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public ActivityRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<Activity> GetAll()
        {
            return _context.Activities.ToList();
        }

        public Activity GetById(int entityId)
        {
            return _context.Activities
                .FirstOrDefault(a => a.Id == entityId);
        }

        public void Insert(Activity entity)
        {
            _context.Activities.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Activity entity)
        {
            _context.Activities.Update(entity);
        }

        public List<Activity> GetEventActivities(int editionId)
        {
            return _context.Activities
                .Where(a => a.EditionId == editionId)
                .ToList();
        }

        public List<Activity> GetActivitiesByStatus(int edition, int status)
        {
            return _context.Activities
                .Where(a => a.EditionId == edition && a.StatusId == status)
                .ToList();
        }

        public List<Activity> GetActiveActivitiesFiltered(int status, int type, int edition,
            string title, int skipByPagination, int activitiesPerPage)
        {
            var query = GetActiveActivitiesWithFilter(status, type, edition, title);

            return query.Skip(skipByPagination).Take(activitiesPerPage).ToList();
        }

        public List<Activity> GetLastThreeActivities(int status, int edition, int numberOfActivities)
        {
            var query = GetActiveActivitiesWithFilter(status, 0, edition, null);

            return query.OrderByDescending(a => a.CreateDateTime).Take(numberOfActivities).ToList();
        }

        public int GetTotalActivities(int status, int type, int edition, string title)
        {
            var query = GetActiveActivitiesWithFilter(status, type, edition, title);

            return query.ToList().Count;
        }

        private IQueryable<Activity> GetActiveActivitiesWithFilter(int status, int type, int edition, string title)
        {
            var query = _context.Activities.Select(a => a).Where(a => a.EditionId == edition);
            if (status != 0)
            {
                query = query.Where(a => a.StatusId == status);
            }
            if (type != 0)
            {
                query = query.Where(a => a.TypeId == type);
            }
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(a => a.Title.Contains(title));
            }

            return query;
        }
    }
}