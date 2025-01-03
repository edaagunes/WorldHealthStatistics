using Microsoft.AspNetCore.Mvc;

namespace WorldHealthStatistics.ViewComponents
{
	public class _HeadLayout : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
