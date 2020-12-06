using Hangfire;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using sensor_reading_backend.Models.Entities;
using sensor_reading_backend.Models.Repository;
using System;

namespace sensor_reading_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static DateTime lastRequestTime;

        private IReadingRepository readingRepository;

        public ValuesController(IReadingRepository readingRepository)
        {
            this.readingRepository = readingRepository;
        }

        // GET api/values
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public ActionResult Get()
        {
            // Schedule for every 20 seconds
            RecurringJob.AddOrUpdate(
                () => GenerateReadings(), "0,20 * * * * *");

            // Cache the last request time and update it
            var cachedLastRequestTime = lastRequestTime;
            lastRequestTime = DateTime.Now;

            return Ok(readingRepository.GetReadings(cachedLastRequestTime));
        }

        public void GenerateReadings()
        {
            // Generate randim values:
            Random rnd = new Random();
            var typeNumber = rnd.Next(1, 3); // 3 is exclusive, will return 1 or 2
            var randTemp = rnd.Next(-300, 301) * 0.1f; // will produce -30f to 30f
            var randBool = rnd.Next(1, 3) == 1 ? true : false; // true or false

            var reading = new Reading
            {
                Type = typeNumber == 1 ? "temperature" : "doorOpen",
                Value = typeNumber == 1 ? randTemp.ToString() : randBool.ToString(),
                Alert = typeNumber == 1 && ( randTemp <= -20 || randTemp >=15) ? true : false,
                Timestamp = DateTime.Now
            };

            readingRepository.SaveReading(reading);

        }
    }
}
