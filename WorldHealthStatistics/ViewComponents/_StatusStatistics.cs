using Microsoft.AspNetCore.Mvc;
using WorldHealthStatistics.Dtos;
using WorldHealthStatistics.Models.StatisticsViewModel;
using WorldHealthStatistics.Repositories;

namespace WorldHealthStatistics.ViewComponents
{
	public class _StatusStatistics : ViewComponent
	{
		private readonly IStatisticsRepository _statisticsRepository;

		public _StatusStatistics(IStatisticsRepository statisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var mostCommonDisease = await _statisticsRepository.GetMostCommonDiseaseInTurkey();

			var topDoctorCount = await _statisticsRepository.GetTopDoctorCountInTurkey();

			var recoveryRate = await _statisticsRepository.GetRecoveryRateEduIndexInTurkey();

			var mostCommonDiseases = await _statisticsRepository.GetMostCommonDiseasesByGender();

			var viewModel = new StatusStatisticsViewModel
			{
				MostCommonDisease = mostCommonDisease,
				TopDoctorCount = topDoctorCount,
				RecoveryRate = recoveryRate,
				FemaleMostCommonDiseases = mostCommonDiseases.FemaleMostCommonDiseases,
				MaleMostCommonDiseases = mostCommonDiseases.MaleMostCommonDiseases
			};
			return View(viewModel); 
		}
	}
}
