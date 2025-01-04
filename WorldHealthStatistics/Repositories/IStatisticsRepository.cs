using WorldHealthStatistics.Dtos;
using WorldHealthStatistics.Models.StatisticsViewModel;

namespace WorldHealthStatistics.Repositories
{
	public interface IStatisticsRepository
	{
		Task<ResultStatisticsDto> GetMostCommonDiseaseInTurkey();
		Task<ResultStatisticsDto> GetTopDoctorCountInTurkey();
		Task<List<ResultStatisticsDto>> GetRecoveryRateEduIndexInTurkey();
		Task<StatusStatisticsViewModel> GetMostCommonDiseasesByGender();
	}
}
