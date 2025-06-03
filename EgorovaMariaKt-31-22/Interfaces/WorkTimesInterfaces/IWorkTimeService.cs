using EgorovaMariaKt_31_22.Database;
using EgorovaMariaKt_31_22.Models;
using EgorovaMariaKt_31_22.Filters.WorkTimeFilter;
using Microsoft.EntityFrameworkCore;

namespace EgorovaMariaKt_31_22.Interfaces.WorkTimesInterfaces
{
    public interface IWorkTimeService
    {
        Task<WorkTime[]> GetWorkTimesAsync(WorkTimesFilter filter, CancellationToken cancellationToken);
        Task<WorkTime> AddWorkTimeAsync(int workTimeHours, CancellationToken cancellationToken); 
        Task<WorkTime> UpdateWorkTimeAsync(int id, int workTimeHours, CancellationToken cancellationToken);
        Task DeleteWorkTimeAsync(int id, CancellationToken cancellationToken);
    }

    public class WorkTimeService : IWorkTimeService
    {
        private readonly LessonDbContext _dbContext;

        public WorkTimeService(LessonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WorkTime[]> GetWorkTimesAsync(WorkTimesFilter filter, CancellationToken cancellationToken)
        {
            var query = _dbContext.WorkTimes.Where(w => !w.IsDeleted);

            if (filter.WorkTimeId > 0)
            {
                query = query.Where(w => w.WorkTimeId == filter.WorkTimeId);
            }

            return await query.ToArrayAsync(cancellationToken);
        }

        public async Task<WorkTime> AddWorkTimeAsync(int workTimeHours, CancellationToken cancellationToken)
        {
            var workTime = new WorkTime
            {
                WorkTimeHours = workTimeHours,
                IsDeleted = false // Явно указываем, что запись не удалена
            };

            await _dbContext.WorkTimes.AddAsync(workTime, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return workTime;
        }

        public async Task<WorkTime> UpdateWorkTimeAsync(int id, int workTimeHours, CancellationToken cancellationToken)
        {
            var existingWorkTime = await _dbContext.WorkTimes
                .FirstOrDefaultAsync(w => w.WorkTimeId == id && !w.IsDeleted, cancellationToken);

            if (existingWorkTime == null)
                throw new Exception("Нагрузка не найдена");

            existingWorkTime.WorkTimeHours = workTimeHours;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return existingWorkTime;
        }

        public async Task DeleteWorkTimeAsync(int id, CancellationToken cancellationToken)
        {
            var workTime = await _dbContext.WorkTimes
                .FirstOrDefaultAsync(w => w.WorkTimeId == id && !w.IsDeleted, cancellationToken);

            if (workTime == null)
                throw new Exception("Нагрузка не найдена");

            workTime.IsDeleted = true;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

