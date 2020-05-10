using System;
using Microsoft.AspNetCore.Mvc;

namespace SqrtCalc.Controllers
{
    public class CalcController : Controller
    {
        // [HttpGet] by default uses a http get method
        public ActionResult Sqrt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sqrt(string firstNumber, string secondNumber)
        {

                try
                {
                    // ViewBag.ErrorMessageValue = "";

                    if (int.Parse(firstNumber) < 0 && int.Parse(secondNumber) < 0)
                    {
                        ViewBag.ErrorMessageValue = "Please insert a positive number!";

                    }else 
                    {
                        var num1 = double.Parse(firstNumber);
                        var num2 = double.Parse(secondNumber);
                        var firstSqrt = Math.Sqrt(num1);
                        var secondSqrt = Math.Sqrt(num2);
                        double highSqrt;

                        if (firstSqrt > secondSqrt)
                        {
                            highSqrt = firstSqrt;
                        }
                        else
                        {
                            highSqrt = secondSqrt;
                        }
                        //store values
                        ViewBag.Result = highSqrt; ViewBag.numberOneValue = num1;
                        ViewBag.numberTwoValue = num2; ViewBag.firstSqrtValue = firstSqrt;                    
                        ViewBag.secondSqrtValue = secondSqrt;
                    
                    }
                    
                }
                catch (FormatException ex)
                {
                    // Handling FormatExceptions and parsing message to User
                    var exceptionValue = ex.Message;
                    ViewBag.FormatError = "Hi Buddy, Only Numbers are accepted " + exceptionValue;
                }
                catch (ArgumentNullException ex)
                {
                    var exceptionValueNullException = ex.Message;
                    ViewBag.FormatErrorNullException = "Please Insert a Value and try again";
                }
            return View();
        }
    }
}