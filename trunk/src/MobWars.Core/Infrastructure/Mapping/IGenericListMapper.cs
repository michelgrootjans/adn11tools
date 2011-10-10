using System.Collections.Generic;
using AutoMapper;

namespace MobWars.Core.Infrastructure
{
    public interface IGenericListMapper
    {
        List<TTo> ToAListOf<TTo>();
    }

    public class GenericListMapper<TFrom> : IGenericListMapper
    {
        private readonly IEnumerable<TFrom> items;

        public GenericListMapper(IEnumerable<TFrom> items)
        {
            this.items = items;
        }

        public List<TTo> ToAListOf<TTo>()
        {
            return Mapper.Map<IEnumerable<TFrom>, List<TTo>>(items);
        }
    }
}