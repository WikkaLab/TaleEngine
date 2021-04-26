using Autofac;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Repositories;

namespace TaleEngine.API.Infrastructure.AutofacModules
{
    public class ApplicationModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterDomainServices(builder);
            RegisterRepositories(builder);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ActivityService>()
                .As<IActivityService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ActivityStatusService>()
                .As<IActivityStatusService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ActivityTypeService>()
                .As<IActivityTypeService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EditionService>()
                .As<IEditionService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EventService>()
                .As<IEventService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RoleService>()
                .As<IRoleService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TimeSlotService>()
                .As<ITimeSlotService>()
                .InstancePerLifetimeScope();
        }

        private void RegisterDomainServices(ContainerBuilder builder)
        {
            builder.RegisterType<ActivityDomainService>()
                .As<IActivityDomainService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ActivityStatusDomainService>()
                .As<IActivityStatusDomainService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ActivityTypeDomainService>()
                .As<IActivityTypeDomainService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EditionDomainService>()
                .As<IEditionDomainService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EventDomainService>()
                .As<IEventDomainService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RoleDomainService>()
                .As<IRoleDomainService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TimeSlotDomainService>()
                .As<ITimeSlotDomainService>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
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