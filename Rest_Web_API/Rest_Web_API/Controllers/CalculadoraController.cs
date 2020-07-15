using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rest_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        // GET api/values
       
        

        // GET api/values/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult Sum(string firstNumber , string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Valores Incorretos");
        }


        [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
        public ActionResult Substraction(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Valores Incorretos");
        }


        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public ActionResult Mutiplicacao(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtracao = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(subtracao.ToString());
            }

            return BadRequest("Valores Incorretos");

        }



        [HttpGet("divisao/{firstNumber}/{secondNumber}")]
        public ActionResult Divisao(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var divisao = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(divisao.ToString());
            }

            return BadRequest("Valores Incorretos");
        }


        [HttpGet("Media/{firstNumber}/{secondNumber}")]
        public ActionResult Media(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;

                return Ok(media.ToString());
            }

            return BadRequest("Valores Incorretos");
        }


        [HttpGet("square-root/{number}")]
        public ActionResult SquareRoot(string number)
        {

            if (IsNumeric(number))
            {
                var squareRoot = Math.Sqrt ((double)ConvertToDecimal(number));

                return Ok(squareRoot.ToString());
            }

            return BadRequest("Valores Incorretos");
        }





        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string strnumber)
        {

            double number;

            bool isNumber = double.TryParse(strnumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }
    }
}
