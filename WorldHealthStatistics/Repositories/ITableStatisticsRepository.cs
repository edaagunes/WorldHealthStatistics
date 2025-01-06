using WorldHealthStatistics.Dtos;
using WorldHealthStatistics.ViewComponents;
using X.PagedList;

namespace WorldHealthStatistics.Repositories
{
	public interface ITableStatisticsRepository
	{
		Task<IPagedList<ResultStatisticsDto>> GetTotalAffectedPopulation(int pageNumber, int pageSize);
	}
}
