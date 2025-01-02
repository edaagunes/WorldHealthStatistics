using Microsoft.AspNetCore.Mvc;
using WorldHealthStatistics.Repositories;

namespace WorldHealthStatistics.Controllers
{
	public class StatisticsController : Controller
	{
		private readonly IStatisticsRepository _statisticsRepository;

		public StatisticsController(IStatisticsRepository statisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _statisticsRepository.Top10();

			return View(values);
		}
	}
}
