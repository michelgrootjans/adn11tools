using AutoMapper;

namespace MobWars.Core.Infrastructure
{
    public interface IGenericItemMapper
    {
        TTo ToA<TTo>();
    }

    public class GenericItemMapper<TFrom> : IGenericItemMapper
    {
        private readonly TFrom item;

        public GenericItemMapper(TFrom item)
        {
            this.item = item;
        }

        public TTo ToA<TTo>()
        {
            return Mapper.Map<TFrom, TTo>(item);
        }
    }
}