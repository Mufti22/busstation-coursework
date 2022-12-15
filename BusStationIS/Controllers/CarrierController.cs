using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusStationIS.Data.Models;
using BusStationIS.Data.ServiceSpecification;
using BusStationIS.Models.Carrier;
using BusStationIS.Models.CarrierViewModel;
using BusStationIS.Models.City;
using Microsoft.AspNetCore.Mvc;

namespace BusStationIS.Controllers
{
    public class CarrierController : Controller
    {
        private readonly ICarrier _carrierService;
        private readonly ICity _cityService;
        private readonly IContact _contactService;
        private readonly IVehicle _vehicleService;

        public CarrierController(ICarrier carrierService,ICity cityService,IContact contactService,IVehicle vehicleService)
        {
            _carrierService = carrierService;
            _cityService = cityService;
            _contactService = contactService;
            _vehicleService = vehicleService;
        }

        public IActionResult AddContact(int id)
        {
            var contactTypes = _contactService.GetContactTypes();

            var model = new CarrierContactInputModel
            {
                ContactTypes = contactTypes,
                CarrierId = id
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _carrierService.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult AddVehicle(int id)
        {
            var vehicleType = _vehicleService.GetVehicleTypes();

            var model = new CarrierVehicleInputModel
            {
                VehicleTypes = vehicleType,
                CarrierId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddVehicle([Bind]CarrierVehicleInputModel vehicleInputModel,int id)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "Model is not valid!";
                return Index();
            }
            Vehicle vehicle = new Vehicle
            {
                RegistrationNumber = vehicleInputModel.RegistrationNumber,
                Available = vehicleInputModel.Available,
                Capacity = vehicleInputModel.Capacity,
                VehicleType = vehicleInputModel.VehicleType
            };

            Carrier carrier = _carrierService.GetById(id);
            carrier.Vehicles.Add(vehicle);

            if (_carrierService.Update(carrier))
            {
                TempData["msg"] = "Vehicle is created!";
            }
            else
            {
                TempData["msg"] = "Vehicle is not created!";
            }

            return RedirectToPage("/..");
        }

        public IActionResult Create()
        {
            var cities = _cityService.GetAll();

            var allCities = cities.Select(c => new City
            {
                Id = c.Id,
                Name = c.Name
            });

            var model = new CarrierInputModel
            {
               Cities = allCities
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult AddContact([Bind]CarrierContactInputModel carrierContact,int id)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "Model is not valid!";
                return Create();
            }
            Contact newContact = new Contact
            {
                ContactContent = carrierContact.ContactContent,
                Type = carrierContact.Type
            };

            Carrier carrier = _carrierService.GetById(id);
            carrier.Contacts.Add(newContact);

            if (_carrierService.Update(carrier))
            {
                TempData["msg"] = "Contact is created!";
            }
            else
            {
                TempData["msg"] = "Contact is not created!";
            }

            return RedirectToPage("/Index",new { area = "Carrier"});
        }

        public IActionResult Edit(int id)
        {
            Carrier carrier = _carrierService.GetById(id);

            CarrierInputModel carrierInput = new CarrierInputModel
            {
                Name = carrier.Name,
                StreetName = carrier.Address.StreetName,
                StreetNumber = carrier.Address.StreetNumber,
                Cities = _cityService.GetAll(),
                CityName = carrier.Address.City.Name
            };

            return View(carrierInput);
        }


        [HttpPost]
        public IActionResult Create([Bind]CarrierInputModel carrier)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "Model is not valid!";
                return Create();
            }
            City newCity = _cityService.GetByName(carrier.CityName);
            Address newAddress = new Address
            {
                StreetName = carrier.StreetName,
                StreetNumber = carrier.StreetNumber,
                City = newCity
            };
            Carrier newCarrier = new Carrier
            {
                Name = carrier.Name,
                Address = newAddress
            };

            if (_carrierService.AddNewCarrier(newCarrier))
            {
                TempData["msg"] = "Carrier is created!";
            }
            else
            {
                TempData["msg"] = "Carrier is not created!";
            }

            return RedirectToPage("/Home");
        }

        public IActionResult Index()
        {
            var carriers = _carrierService.GetAll();

            var carriersListing = carriers.Select(c => new CarrierDetailModel
            {
                Id = c.Id,
                Name = c.Name,
                Vehicles = c.Vehicles,
                Address = c.Address,
                Contacts = FrontHelpers.FrontHumanizeHelper.ContactsHumanize(c.Contacts)
            });

            var model = new CarrierIndexModel
            {
                Carriers = carriersListing
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var carrier = _carrierService.GetById(id);

            var model = new CarrierDetailModel
            {
                Id = carrier.Id,
                Name = carrier.Name,
                Address = carrier.Address,
                Contacts = FrontHelpers.FrontHumanizeHelper.ContactsHumanize(carrier.Contacts),
                Vehicles = carrier.Vehicles
            };

            return View(model);
        }
    }
}