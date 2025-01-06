using Microsoft.AspNetCore.Mvc;
using WorldHealthStatistics.Models.TableViewModel;
using WorldHealthStatistics.Repositories;

namespace WorldHealthStatistics.ViewComponents
{
	public class _TableStatistics : ViewComponent
	{
		private readonly ITableStatisticsRepository _tableStatisticsRepository;

		public _TableStatistics(ITableStatisticsRepository tableStatisticsRepository)
		{
			_tableStatisticsRepository = tableStatisticsRepository;
		}

		public async Task<IViewComponentResult> InvokeAsync(int pageNumber = 1, int pageSize = 10)
		{
			//var totalAffected = await _tableStatisticsRepository.GetTotalAffectedPopulation(pageNumber, pageSize);

			//var viewModel = new TableStatisticsViewModel
			//{
			//	TotalAffectedPopulation = totalAffected,
			//	PageNumber = pageNumber,
			//	PageSize = pageSize
			//};
			return View();
		}

		
	}
}
