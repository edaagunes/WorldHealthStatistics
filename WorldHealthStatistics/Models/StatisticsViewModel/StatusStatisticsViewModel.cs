using WorldHealthStatistics.Dtos;

namespace WorldHealthStatistics.Models.StatisticsViewModel
{
	public class StatusStatisticsViewModel
	{
		public ResultStatisticsDto MostCommonDisease { get; set; }
		public ResultStatisticsDto TopDoctorCount { get; set; }
		public List<ResultStatisticsDto> RecoveryRate { get; set; }
		public ResultStatisticsDto FemaleMostCommonDiseases { get; set; }
		public ResultStatisticsDto MaleMostCommonDiseases { get; set; }
		public ResultStatisticsDto MostCommonDiseaseInWorld { get; set; }
		public ResultStatisticsDto LeastCommonDiseaseInWorldWithCost { get; set; }
		public List<ResultStatisticsDto> MostCommonDiseaseCategoryInWorldWithUrbanization { get; set; }
		public ResultStatisticsDto MostCommonDiseasesByWorldWithAgeGroup { get; set; }
		public List<ResultStatisticsDto> MostCommonDiseasesByAgeGroup { get; set; }
	}
}
