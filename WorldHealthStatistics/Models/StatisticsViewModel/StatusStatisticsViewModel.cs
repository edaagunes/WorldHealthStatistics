﻿using WorldHealthStatistics.Dtos;

namespace WorldHealthStatistics.Models.StatisticsViewModel
{
	public class StatusStatisticsViewModel
	{
		public ResultStatisticsDto MostCommonDisease { get; set; }
		public ResultStatisticsDto TopDoctorCount { get; set; }
		public List<ResultStatisticsDto> RecoveryRate { get; set; }
		public ResultStatisticsDto FemaleMostCommonDiseases { get; set; }
		public ResultStatisticsDto MaleMostCommonDiseases { get; set; }
	}
}
