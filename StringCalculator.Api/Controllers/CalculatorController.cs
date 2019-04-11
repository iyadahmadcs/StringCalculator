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
        private readonly ICustomSplitServices _calculatorServices;

        public CalculatorController(
            ICustomSplitServices calculatorServices
            )
        {
            _calculatorServices = calculatorServices;
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
            var data = _calculatorServices.GetNumbers(numbers);

            return new ApiResult
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Processing"
            };
        }
    }
}