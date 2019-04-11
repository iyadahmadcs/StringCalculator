using Microsoft.AspNetCore.Mvc;
using StringCalculator.Infrastructure.Models;
using StringCalculator.Services.Services;
using System.Net;

namespace StringCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        private readonly ICalculatorServices _calculatorServices;
        public CalculatorController(
            ICalculatorServices customSplitServices
            )
        {
            _calculatorServices = customSplitServices;
        }

        /// <summary>
        /// Handle a string of numbers with custom delimiters and return the sum.
        /// </summary>
        /// <param name="numbers">String of numbers with custom delimiters.</param>
        /// <returns>The sum of numbers.</returns>
        [HttpGet]
        public ActionResult<ApiResult> Get(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return new ApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "The Sum = 0"
                };
            }
            var sum = _calculatorServices.GetSum(numbers);
            var log = _calculatorServices.GetLog();
            return new ApiResult
            {
                StatusCode = HttpStatusCode.OK,
                Message = sum.ToString(),
                Log = log
            };
        }

    }
}