using System.Collections.Generic;

namespace MobWars.Core.Infrastructure
{
    public interface IGenericMapper
    {
        IGenericItemMapper Map<TFrom>(TFrom item);
        IGenericListMapper Map<TFrom>(IEnumerable<TFrom> items);
    }

    public class GenericMapper : IGenericMapper
    {
        public IGenericItemMapper Map<TFrom>(TFrom item)
        {
            return new GenericItemMapper<TFrom>(item);
        }

        public IGenericListMapper Map<TFrom>(IEnumerable<TFrom> items)
        {
            return new GenericListMapper<TFrom>(items);
        }
    }
}