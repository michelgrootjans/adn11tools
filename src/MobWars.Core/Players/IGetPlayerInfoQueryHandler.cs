using MobWars.Core.Infrastructure;
using MobWars.Core.Queries;

namespace MobWars.Core.Players
{
    public interface IGetPlayerInfoQueryHandler : IQueryHandler
    {
        ViewPlayerInfoDto HandleQuery();
    }

    public class GetPlayerInfoQueryHandler : IGetPlayerInfoQueryHandler
    {
        private readonly IGetCurrentPlayerDbQuery playerQuery;
        private readonly IGenericMapper mapper;

        public GetPlayerInfoQueryHandler(IGetCurrentPlayerDbQuery playerQuery, IGenericMapper mapper)
        {
            this.playerQuery = playerQuery;
            this.mapper = mapper;
        }

        public ViewPlayerInfoDto HandleQuery()
        {
            var player = playerQuery.GetCurrentPlayer();
            return mapper.Map(player).ToA<ViewPlayerInfoDto>();
        }
    }
}