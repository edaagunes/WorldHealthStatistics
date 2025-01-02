using Dapper;
using NuGet.Protocol.Plugins;
using WorldHealthStatistics.Context;
using WorldHealthStatistics.Dtos;

namespace WorldHealthStatistics.Repositories
{
	public class StatisticsRepository : IStatisticsRepository
	{
		private readonly HealthContext _context;

		public StatisticsRepository(HealthContext context)
		{
			_context = context;
		}

		public async Task<List<ResultStatisticsDto>> Top10()
		{
			string query = "SELECT TOP 10 * FROM HealthData";
			var connection = _context.CreateConnection();
			var results = await connection.QueryAsync<ResultStatisticsDto>(query);
			return results.ToList();
		}
	}
}
