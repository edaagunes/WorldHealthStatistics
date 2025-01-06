using Microsoft.AspNetCore.Mvc;
using WorldHealthStatistics.Dtos;
using WorldHealthStatistics.Models.TableViewModel;
using WorldHealthStatistics.Repositories;

namespace WorldHealthStatistics.Controllers
{
	public class StatisticsController : Controller
	{
		private readonly IStatusStatisticsRepository _statisticsRepository;
		private readonly ITableStatisticsRepository _tableStatisticsRepository;

		public StatisticsController(IStatusStatisticsRepository statisticsRepository, ITableStatisticsRepository tableStatisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
			_tableStatisticsRepository = tableStatisticsRepository;
		}

		public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
		{

			var totalAffected = await _tableStatisticsRepository.GetTotalAffectedPopulation(pageNumber, pageSize);


			var viewModel = new TableStatisticsViewModel
			{
				TotalAffectedPopulation = totalAffected,
				PageNumber = pageNumber,
				PageSize = pageSize
			};

			return View(viewModel);
		}

	}
}

