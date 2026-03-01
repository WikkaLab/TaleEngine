using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IDatabaseContext _context;

        public ActivityRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            var entity = _context.Activities
                .FirstOrDefault(a => a.Id == entityId && !a.IsDeleted);
            
            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.Activities.Update(entity);
            }
        }

        public List<ActivityEntity> GetAll()
        {
            return _context.Activities.Where(a => !a.IsDeleted).ToList();
        }

        public ActivityEntity GetById(int entityId)
        {
            return _context.Activities
                .FirstOrDefault(a => a.Id == entityId && !a.IsDeleted);
        }

        public void Insert(ActivityEntity entity)
        {
            _context.Activities.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ActivityEntity entity)
        {
            _context.Activities.Update(entity);
        }

        public List<ActivityEntity> GetEventActivities(int editionId)
        {
            return _context.Activities
                .Where(a => a.EditionId == editionId && !a.IsDeleted)
                .ToList();
        }

        public List<ActivityEntity> GetActivitiesByStatus(int edition, int status)
        {
            return _context.Activities
                .Where(a => a.EditionId == edition && a.StatusId == status && !a.IsDeleted)
                .ToList();
        }

        public List<ActivityEntity> GetActiveActivitiesFiltered(int status, int type, int edition,
            string title, int skip, int activitiesPerPage)
        {
            return _context.Activities
                .Where(a => a.EditionId == edition && a.StatusId == status && !a.IsDeleted)
                .Where(a => a.Title.Contains(title))
                .Skip(skip)
                .Take(activitiesPerPage)
                .ToList();
        }

        public List<ActivityEntity> GetLastThreeActivities(int status, int edition, int numberOfActivities)
        {
            return _context.Activities
                .Where(a => a.EditionId == edition && a.StatusId == status && !a.IsDeleted)
                .OrderByDescending(a => a.CreateDateTime)
                .Take(numberOfActivities)
                .ToList();
        }

        public int GetTotalActivities(int status, int type, int edition, string title)
        {
            throw new System.NotImplementedException();
        }

        public List<ActivityEntity> GetAllIncludeFavs(int eventId)
        {
            return _context.Activities
                .Include(a => a.UsersFav)
                .Where(a => !a.IsDeleted)
                .ToList();
        }
    }
}
