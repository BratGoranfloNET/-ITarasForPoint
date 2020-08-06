using Microsoft.AspNetCore.Mvc;
using ITaras.Services;

namespace ITaras.Controllers
{
    public class TestController : Controller
    {
        private IServiceRepository _serviceRepository {get; set;}
        public TestController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;         
        }

        public IActionResult Index()
        {
            _serviceRepository.Execute();
            return View();
        }        
    }
}
