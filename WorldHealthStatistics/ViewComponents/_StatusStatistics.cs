﻿using Microsoft.AspNetCore.Mvc;
using WorldHealthStatistics.Dtos;
using WorldHealthStatistics.Models.StatisticsViewModel;
using WorldHealthStatistics.Repositories;

namespace WorldHealthStatistics.ViewComponents
{
	public class _StatusStatistics : ViewComponent
	{
		private readonly IStatusStatisticsRepository _statisticsRepository;

		public _StatusStatistics(IStatusStatisticsRepository statisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var mostCommonDisease = await _statisticsRepository.GetMostCommonDiseaseInTurkey();

			var topDoctorCount = await _statisticsRepository.GetTopDoctorCountInTurkey();

			var recoveryRate = await _statisticsRepository.GetRecoveryRateEduIndexInTurkey();

			var mostCommonDiseases = await _statisticsRepository.GetMostCommonDiseasesByGender();

			var mostCommonDiseaseInWorld = await _statisticsRepository.GetMostCommonDiseasesByWorld();

			var leastCommonDiseaseInWorldWithCost = await _statisticsRepository.GetLeastCommonDiseasesByWorldWithCost();

			var mostCommonDiseaseCategoryInWorldWithUrbanization = await _statisticsRepository.GetMostCommonDiseaseCategoryByWorldWithUrbanization();

			var mostCommonDiseasesByWorldWithAgeGroup = await _statisticsRepository.GetMostCommonDiseasesByWorldWithAgeGroup();



			var viewModel = new StatusStatisticsViewModel
			{
				MostCommonDisease = mostCommonDisease,
				TopDoctorCount = topDoctorCount,
				RecoveryRate = recoveryRate,
				FemaleMostCommonDiseases = mostCommonDiseases.FemaleMostCommonDiseases,
				MaleMostCommonDiseases = mostCommonDiseases.MaleMostCommonDiseases,
				MostCommonDiseaseInWorld= mostCommonDiseaseInWorld,
				LeastCommonDiseaseInWorldWithCost=leastCommonDiseaseInWorldWithCost,
				MostCommonDiseaseCategoryInWorldWithUrbanization=mostCommonDiseaseCategoryInWorldWithUrbanization,
				MostCommonDiseasesByWorldWithAgeGroup = mostCommonDiseasesByWorldWithAgeGroup
			};
			return View(viewModel); 
		}
	}
}
