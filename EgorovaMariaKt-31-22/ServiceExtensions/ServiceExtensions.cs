using EgorovaMariaKt_31_22.Interfaces.LessonsIntefaces;
using EgorovaMariaKt_31_22.Interfaces.WorkTimesInterfaces;
namespace EgorovaMariaKt_31_22.ServiceExtensions

{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IWorkTimeService, WorkTimeService>();

            return services;
        }


    }
}
