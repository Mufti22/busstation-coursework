using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BusStationIS.Data.Models.Weather;
using BusStationIS.Data.ServiceSpecification;
using BusStationIS.Models;
using BusStationIS.Models.City;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;

namespace BusStationIS.Controllers
{
    public class CityController : Controller
    {
        private readonly ICity _cityService;
        private readonly IBusStation _busStationService;
        private readonly ICarrier _carrierService;

        public CityController(ICity cityService,IBusStation busStationService,ICarrier carrierService)
        {
            _cityService = cityService;
            _busStationService = busStationService;
            _carrierService = carrierService;
        }
        public IActionResult Index()
        {
            var citys = _cityService.GetAll();

            var cityListing = citys.Select(c => new CityDetailModel
            {
                Id = c.Id,
                Name = c.Name,
                ImageUrl = c.ImageUrl,
                ZipCode = c.ZipCode,
                Carriers = _carrierService.GetByCity(c),
                BusStations = _busStationService.GetByCity(c.Id)
            });

            var model = new CityIndexModel
            {
                Cities = cityListing
            };

            return View(model);
        }


        public async Task<OpenWeatherResponseOutput> GetWeatherInfo(string city)
        {
            using (var client = new HttpClient()) {
                try
                {
                    client.BaseAddress = new Uri("https://api.openweathermap.org");
                    var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid=437318050e913abb8509dc60a7d150f8&units=metric");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
                    return new OpenWeatherResponseOutput{ 
                        Temp = rawWeather.Main.Temp,
                        Summary = string.Join(",",rawWeather.Weather.Select(x=>x.Main)),
                        City=rawWeather.Name,
                        WindSpeed = rawWeather.Wind.Speed,
                        MaxTemp = rawWeather.Main.TempMax,
                        MinTemp = rawWeather.Main.TempMin,
                        Pressure = rawWeather.Main.Pressure
                    };
                }
                catch(HttpRequestException httpRequestException)
                {
                    return null;

                }
            }
               
        }

        public IActionResult GenTable()
        {
            PdfDocument document;

           document = new PdfDocument();
                PdfPage page = document.Pages.Add();

                PdfGraphics graphics = page.Graphics;

                PdfLightTable pdfLightTable = new PdfLightTable();

                pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

                pdfLightTable.Columns.Add(new PdfColumn("Roll Number"));
                pdfLightTable.Columns.Add(new PdfColumn("Name"));
                pdfLightTable.Columns.Add(new PdfColumn("Class"));

                pdfLightTable.Rows.Add(new object[] { "111", "Luka", "III" });

                pdfLightTable.Draw(page, PointF.Empty);


           
            MemoryStream stream = new MemoryStream();
            document.Save(stream);

            stream.Position = 0;
            return File(stream,"application/pdf","test.pdf");
        }


        public IActionResult Detail(int id)
        {
            var city = _cityService.GetById(id);

            var model = new CityDetailModel
            {
                Id = city.Id,
                Name = city.Name,
                BusStations = _busStationService.GetByCity(id),
                Carriers = _carrierService.GetByCity(city),
                ImageUrl = city.ImageUrl,
                ZipCode = city.ZipCode
            };
            model.OpenWeather = GetWeatherInfo(model.Name);

            return View(model);
        }
    }
}