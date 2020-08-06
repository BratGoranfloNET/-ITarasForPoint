using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITaras.Models;
using ITaras.Models.JsonReturnViewModels;
using System.Threading;
using ITaras.Services;

namespace ITaras.Controllers
{   
    public class Form1Controller : Controller
    {
        private IServiceRepository _serviceRepository { get; set; }
        public Form1Controller(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        

        [HttpPost]
        public  IActionResult GetData ()
        {
            _serviceRepository.Execute();

            JsonModelReturnViewForm json = new JsonModelReturnViewForm();
            try
            {
                Thread.Sleep(2000);
                json.messages = "Данные Формы-1 (" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() +")";
            }
            catch(Exception ex)
            {
                json.messages = ex.Message;
                return Json(json);
            }
            return Json(json);
        }
    }
}
