using WorldHealthStatistics.Dtos;
using X.PagedList;

namespace WorldHealthStatistics.Models.TableViewModel
{
	public class TableStatisticsViewModel
	{
		public IPagedList<ResultStatisticsDto> TotalAffectedPopulation { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}
