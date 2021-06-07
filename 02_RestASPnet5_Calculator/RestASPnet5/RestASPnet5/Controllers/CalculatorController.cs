using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestASPnet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
  
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondeNumber}")]
        public IActionResult GetSum(string firstNumber, string secondeNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondeNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalide Input");
        }

        [HttpGet("sub/{firstNumber}/{secondeNumber}")]
        public IActionResult GetSub(string firstNumber, string secondeNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondeNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalide Input");
        }

        [HttpGet("mult/{firstNumber}/{secondeNumber}")]
        public IActionResult GetMult(string firstNumber, string secondeNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondeNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalide Input");
        }

        [HttpGet("div/{firstNumber}/{secondeNumber}")]
        public IActionResult GetDiv(string firstNumber, string secondeNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondeNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalide Input");
        }

        [HttpGet("avg/{firstNumber}/{secondeNumber}")]
        public IActionResult GetAvg(string firstNumber, string secondeNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondeNumber))/2;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalide Input");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult GetSqrt(string firstNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
            {
                var sum = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(sum.ToString());
            }
            return BadRequest("Invalide Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }


    }
}
