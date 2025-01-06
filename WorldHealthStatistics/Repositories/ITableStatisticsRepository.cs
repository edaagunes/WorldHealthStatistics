using WorldHealthStatistics.Dtos;
using X.PagedList;

namespace WorldHealthStatistics.Repositories
{
	public interface ITableStatisticsRepository
	{
		Task<IPagedList<ResultStatisticsDto>> GetTotalAffectedPopulation(int pageNumber, int pageSize);
	}
}
