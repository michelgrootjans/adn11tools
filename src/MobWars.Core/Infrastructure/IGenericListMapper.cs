using System.Collections.Generic;
using AutoMapper;

namespace MobWars.Core.Infrastructure
{
    public interface IGenericListMapper
    {
        IEnumerable<TTo> ToAListOf<TTo>();
    }

    public class GenericListMapper<TFrom> : IGenericListMapper
    {
        private readonly IEnumerable<TFrom> items;

        public GenericListMapper(IEnumerable<TFrom> items)
        {
            this.items = items;
        }

        public IEnumerable<TTo> ToAListOf<TTo>()
        {
            return Mapper.Map<IEnumerable<TFrom>, IEnumerable<TTo>>(items);
        }
    }
}