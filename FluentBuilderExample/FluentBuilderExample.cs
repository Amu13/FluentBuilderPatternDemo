using FluentBuilderExampleLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FluentBuilderExample
{
    public class FluentBuilderExample
    {
        private readonly ILogger<FluentBuilderExample> _logger;
        private readonly EmployeeBuilder _employeeBuilder;

        public FluentBuilderExample(ILogger<FluentBuilderExample> logger, EmployeeBuilder employeeBuilder)
        {
            _logger = logger;
            _employeeBuilder = employeeBuilder ?? throw new ArgumentNullException(nameof(employeeBuilder)); ;
        }

        [Function("FluentBuilderExample")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");


            var employee = _employeeBuilder
                .WithId(1234)
                .WithEmployeeName("Joe")
                .WithEmployeeAddress(address=> address.WithCity("London")
                    .WithCountry("UK")
                    .WithPostalCode("12345")
                    .WithStreet("Allestree Rd"))
                .Build();
            return new OkObjectResult(employee);
        }
    }
}
