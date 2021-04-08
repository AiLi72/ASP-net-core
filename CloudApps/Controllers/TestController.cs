using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApps.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase {

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ConfigurationValues> Get() {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ConfigurationValues {
                date = DateTime.Now.AddDays(index),
                ID = rng.Next(100, 1000),
                description = "Test"
            })
            .ToArray();
        }
    }
}
