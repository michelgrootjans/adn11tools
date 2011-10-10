using AutoMapper;

namespace MobWars.Core.Infrastructure
{
    public interface IMapperConfigurator
    {
        void Configure();
    }

    public abstract class AutomaticMapper<TFrom, TTo> : IMapperConfigurator
    {
        public void Configure()
        {
            ConfigureExceptions(Mapper.CreateMap<TFrom, TTo>());
        }


        protected virtual void ConfigureExceptions(IMappingExpression<TFrom, TTo> mappingExpression)
        {
        }
    }
}