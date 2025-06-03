using EgorovaMariaKt_31_22.Database;
using EgorovaMariaKt_31_22.Models;
using EgorovaMariaKt_31_22.Filters.LessonFilters;
using Microsoft.EntityFrameworkCore;

namespace EgorovaMariaKt_31_22.Interfaces.LessonsIntefaces
{
    public interface ILessonService
    {
        public Task<Lesson[]> GetLessonsByTeacherAsync(LessonsTeacherFilter filter, CancellationToken cancellationToken);
    }

    public class LessonService : ILessonService
    {
        private readonly LessonDbContext _dbContext;
        public LessonService(LessonDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Lesson[]> GetLessonsByTeacherAsync(LessonsTeacherFilter filter, CancellationToken cancellationToken= default)
        {
            if (filter.MinWorkTime.HasValue && filter.MaxWorkTime.HasValue && filter.MinWorkTime > filter.MaxWorkTime)
            {
                throw new ArgumentException("MinWorkTime cannot be greater than MaxWorkTime");
            }
            //var lessons = _dbContext.Set<Lesson>()
            //.Where(w => w.Teacher.TeacherId == filter.TeacherId)
            //.ToArrayAsync(cancellationToken = default);
            //return lessons;
            // Начинаем формировать запрос
            var query = _dbContext.Set<Lesson>()
                .Include(l => l.Teacher) // Включаем данные о преподавателе
                .Include(l => l.WorkTime)
                .Where(l => !l.IsDeleted); // Исключаем удаленные записи
                //.AsQueryable();

            // Применяем фильтр по преподавателю, если указан
            if (filter.TeacherId.HasValue)
            {
                query = query.Where(l => l.Teacher.TeacherId == filter.TeacherId.Value);
            }

            // Применяем фильтр по минимальной нагрузке, если указан
            if (filter.MinWorkTime.HasValue)
            {
                query = query.Where(l => l.WorkTime.WorkTimeHours >= filter.MinWorkTime.Value);
            }

            // Применяем фильтр по максимальной нагрузке, если указан
            if (filter.MaxWorkTime.HasValue)
            {
                query = query.Where(l => l.WorkTime.WorkTimeHours <= filter.MaxWorkTime.Value);
            }

            // Выполняем запрос и возвращаем результат
            return await query.ToArrayAsync(cancellationToken);



        }


    }
}

