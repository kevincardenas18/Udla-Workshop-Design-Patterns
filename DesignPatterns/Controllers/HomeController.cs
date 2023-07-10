using DesignPatterns.ModelBuilder;
using DesignPatterns.Models;
using DesignPatterns.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DesignPatterns.Infraestructure.FactoryMethod;

namespace DesignPatterns.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IVehicleRepository _vehicleRepository;

        public HomeController(IVehicleRepository vehicleRepository,ILogger<HomeController> logger)
        {
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();
            model.Vehicles = _vehicleRepository.GetVehicles();
            string error = Request.Query.ContainsKey("error") ? Request.Query["error"].ToString() : null;
            ViewBag.ErrorMessage = error;

            return View(model);
        }

        [HttpGet]
        public IActionResult AddMustang()
        {
            Vehicle v = VehicleFactory.CreateVehicle("");
            v.Color = "Azul";
            _vehicleRepository.AddVehicle(v);

            ICollection<Vehicle> vehicles = _vehicleRepository.GetVehicles();

            foreach (Vehicle vehicle in vehicles)
            {
                Debug.WriteLine("Vehicle: " + vehicle.Color);
            }

            return Redirect("/");
        }

        [HttpGet]
        public IActionResult AddExplorer()
        {
            _vehicleRepository.AddVehicle(VehicleFactory.CreateVehicle("Explorer"));
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult AddEscape()
        {
            _vehicleRepository.AddVehicle(VehicleFactory.CreateVehicle("Escape"));
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult StartEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StartEngine();
                return Redirect("/");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
          
        }

        [HttpGet]
        public IActionResult AddGas(string id)
        {

            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.AddGas();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult StopEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StopEngine();
                return Redirect("/");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
           
           
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
