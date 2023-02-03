using BusinessLayerLaboratory;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebLayerLaboratory.Models;

namespace WebLayerLaboratory.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var objCountryBusiness = new CountryBusiness();
			var x = objCountryBusiness.GetCountryModels();
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}