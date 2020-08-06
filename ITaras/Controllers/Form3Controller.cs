using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ITaras.Models;
using ITaras.Models.JsonReturnViewModels;
using System.Threading;
using ITaras.Services;

namespace ITaras.Controllers
{
    public class Form3Controller : Controller
    {
        private IServiceRepository _serviceRepository { get; set; }
        public Form3Controller(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpPost]
        public  IActionResult GetData()
        {
            _serviceRepository.Execute();

            JsonModelReturnViewForm json = new JsonModelReturnViewForm();
            try
            {
                Thread.Sleep(2000);
                json.messages = "Данные Формы-3 (" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + ")";
            }
            catch(Exception ex)
            {
                json.messages = ex.Message;
                return Json(json);
            }
            return Json(json);
        }


        [HttpPost]
        public IActionResult Form2()
        {
            JsonModelReturnViewForm json = new JsonModelReturnViewForm();
            try
            {
                json.messages = "Данные Формы-2";
            }
            catch (Exception ex)
            {
                json.messages = ex.Message;
                return Json(json);
            }
            return Json(json);
        }


        public IActionResult Index()
        {
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
