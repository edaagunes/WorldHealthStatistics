using WorldHealthStatistics.Dtos;

namespace WorldHealthStatistics.Models.GraphicsViewModel
{
	public class GraphicStatisticsViewModel
	{
		public List<ResultStatisticsDto> CommonCountryByDiabetes { get; set; }
		public List<ResultStatisticsDto> Last5YearsDiseases { get; set; }
		public List<ResultStatisticsDto> MostCommonLast5YearsDiseases { get; set; }
	}
}
