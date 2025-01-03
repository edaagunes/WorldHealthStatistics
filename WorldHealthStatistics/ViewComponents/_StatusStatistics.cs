using Microsoft.AspNetCore.Mvc;

namespace WorldHealthStatistics.ViewComponents
{
	public class _StatusStatistics:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
