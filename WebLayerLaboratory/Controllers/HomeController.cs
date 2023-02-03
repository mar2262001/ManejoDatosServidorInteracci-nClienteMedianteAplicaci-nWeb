using AutoMapper;
using BusinessLayerLaboratory;
using Microsoft.AspNetCore.Mvc;
using ModelLayerLaboratory;
using System.Diagnostics;
using WebLayerLaboratory.Models;

namespace WebLayerLaboratory.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IMapper _mapper;

		public HomeController(ILogger<HomeController> logger, IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
            return View(new DataIndexViewModel { LstCountry = _mapper.Map<IEnumerable<CountryViewModel>>(new CountryBusiness().GetCountryModels()), LstBook = _mapper.Map<IEnumerable<BookViewModel>>(new BookBusiness().GetBookModels()) });
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