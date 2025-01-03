using Microsoft.AspNetCore.Mvc;

namespace WorldHealthStatistics.ViewComponents
{
	public class _GraphicStatistics: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
