﻿using Microsoft.AspNetCore.Mvc;

namespace WorldHealthStatistics.ViewComponents
{
	public class _TableStatistics : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
