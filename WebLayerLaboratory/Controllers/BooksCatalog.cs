using AutoMapper;
using BusinessLayerLaboratory;
using Microsoft.AspNetCore.Mvc;
using ModelLayerLaboratory;
using WebLayerLaboratory.Models;

namespace WebLayerLaboratory.Controllers
{
    public class BooksCatalog : Controller
    {
        private readonly ILogger<BooksCatalog> _logger;
        private readonly IMapper _mapper;

        public BooksCatalog(ILogger<BooksCatalog> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index(int? contryId)
        {
            IEnumerable<BookViewModel> lstBookViewModel = new List<BookViewModel>();
            if (contryId > 0)
            {
                lstBookViewModel = _mapper.Map<IEnumerable<BookViewModel>>(new BookBusiness().GetBookModels(contryId.Value));
            }
            else 
            {
                lstBookViewModel = _mapper.Map<IEnumerable<BookViewModel>>(new BookBusiness().GetBookModels());
            }

            return View(new DataIndexViewModel { LstCountry = _mapper.Map<IEnumerable<CountryViewModel>>(new CountryBusiness().GetCountryModels()), LstBook = lstBookViewModel, CountryId = contryId != null ? contryId.Value : 0 });
        }

        [HttpGet]
        public IActionResult CreateView(int? id)
        {
            BookViewModel objBookViewModel = new ();
            if (id > 0) {
                objBookViewModel = _mapper.Map<BookViewModel>(new BookBusiness().GetBookModel(id.Value));
            }

            return View(new DataIndexViewModel { LstCountry = _mapper.Map<IEnumerable<CountryViewModel>>(new CountryBusiness().GetCountryModels()), ObjBook = objBookViewModel });
        }

        [HttpPost]
        public IActionResult Create(BookViewModel objBookViewModel)
        {
            BookBusiness objBookBusiness = new();
            if (objBookViewModel.Id > 0)
            {
                objBookBusiness.PutBookModel(_mapper.Map<BookModel>(objBookViewModel));
            }
            else 
            {
                objBookBusiness.PostBookModel(_mapper.Map<BookModel>(objBookViewModel));
            }
            
            return RedirectToAction("Index", "BooksCatalog");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            new BookBusiness().DelBookModel(id);

            return RedirectToAction("Index", "BooksCatalog");
        }
    }
}
