using Autofac;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Repositories;

namespace TaleEngine.AutofacModules
{
    public class ApplicationModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ActivityRepository>()
                .As<IActivityRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ActivityStatusRepository>()
                .As<IActivityStatusRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ActivityTypeRepository>()
               .As<ActivityTypeRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<EditionRepository>()
                .As<IEditionRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EventRepository>()
                .As<IEventRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RoleRepository>()
               .As<IRoleRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<TimeSlotRepository>()
                .As<ITimeSlotRepository>()
                .InstancePerLifetimeScope();
        }
    }
}