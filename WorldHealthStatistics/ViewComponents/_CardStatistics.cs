using Microsoft.AspNetCore.Mvc;

namespace WorldHealthStatistics.ViewComponents
{
	public class _CardStatistics : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
