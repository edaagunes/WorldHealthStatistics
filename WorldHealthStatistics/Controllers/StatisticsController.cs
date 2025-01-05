using Microsoft.AspNetCore.Mvc;
using WorldHealthStatistics.Dtos;
using WorldHealthStatistics.Repositories;

namespace WorldHealthStatistics.Controllers
{
	public class StatisticsController : Controller
	{
		private readonly IStatusStatisticsRepository _statisticsRepository;

		public StatisticsController(IStatusStatisticsRepository statisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}

	}
}
