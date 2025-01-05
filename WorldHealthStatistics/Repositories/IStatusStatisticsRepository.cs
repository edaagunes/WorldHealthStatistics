using WorldHealthStatistics.Dtos;
using WorldHealthStatistics.Models.StatisticsViewModel;

namespace WorldHealthStatistics.Repositories
{
	public interface IStatusStatisticsRepository
	{
		Task<ResultStatisticsDto> GetMostCommonDiseaseInTurkey();
		Task<ResultStatisticsDto> GetTopDoctorCountInTurkey();
		Task<List<ResultStatisticsDto>> GetRecoveryRateEduIndexInTurkey();
		Task<StatusStatisticsViewModel> GetMostCommonDiseasesByGender();
		Task<ResultStatisticsDto> GetMostCommonDiseasesByWorld();
		Task<ResultStatisticsDto> GetLeastCommonDiseasesByWorldWithCost();
		Task<List<ResultStatisticsDto>> GetMostCommonDiseaseCategoryByWorldWithUrbanization();
		Task<ResultStatisticsDto> GetMostCommonDiseasesByWorldWithAgeGroup();
		Task<List<ResultStatisticsDto>> GetMostCommonDiseasesByAgeGroup();
	}
}
