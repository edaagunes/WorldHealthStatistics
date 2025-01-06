using WorldHealthStatistics.Dtos;

namespace WorldHealthStatistics.Repositories
{
	public interface IGraphicStatisticsRepository
	{
		Task<List<ResultStatisticsDto>> GetCommonCountryByDiabetes();
		Task<List<ResultStatisticsDto>> GetLast5YearsDiseases();
		Task<List<ResultStatisticsDto>> GetMostCommonLast5YearsDiseases();
	}
}
