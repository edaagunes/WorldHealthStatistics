using Microsoft.AspNetCore.Mvc;
using WorldHealthStatistics.Models.GraphicsViewModel;
using WorldHealthStatistics.Models.StatisticsViewModel;
using WorldHealthStatistics.Repositories;

namespace WorldHealthStatistics.ViewComponents
{
	public class _GraphicStatistics: ViewComponent
	{
		private readonly IGraphicStatisticsRepository _graphicStatisticsRepository;

		public _GraphicStatistics(IGraphicStatisticsRepository graphicStatisticsRepository)
		{
			_graphicStatisticsRepository = graphicStatisticsRepository;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var mostCommonDiabetes = await _graphicStatisticsRepository.GetCommonCountryByDiabetes();
			var last5Diseases = await _graphicStatisticsRepository.GetLast5YearsDiseases();
			var mostCommonLast5YearsDiseases = await _graphicStatisticsRepository.GetMostCommonLast5YearsDiseases();

			var viewModel = new GraphicStatisticsViewModel
			{
				CommonCountryByDiabetes=mostCommonDiabetes,
				Last5YearsDiseases=last5Diseases,
				MostCommonLast5YearsDiseases=mostCommonLast5YearsDiseases
			};
			return View(viewModel);
		}
	}
}
