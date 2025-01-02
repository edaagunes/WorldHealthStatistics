using WorldHealthStatistics.Dtos;

namespace WorldHealthStatistics.Repositories
{
	public interface IStatisticsRepository
	{
		Task <List<ResultStatisticsDto>> Top10();
	}
}
