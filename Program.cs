using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation_Civic_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            int year = 0;
           
            //Ask user for input
            Console.WriteLine("Skriv in ett 12-siffrigt personnummer enligt följande YYYYMMDDnnnc: ");
            userInput = Console.ReadLine();

            //Takes out year, converts and places in an int variable
            year = int.Parse(userInput.Substring(0, 4));

            //Calls method NumberOfDigits and sends in string value
            NumberOfDigits(userInput);
            //Calls method CorrectYear and send in int variable
            CorrectYear(year);

            //Stop
            Console.ReadKey();
        }
        //--------------------------------------------------------
        //Method that checks that the number of digits is correct
        //--------------------------------------------------------
        static void NumberOfDigits(string civicNumber)
        {
            //Expression that checks if the variable contains 12 digits
            if (civicNumber.Length < 12 || civicNumber.Length > 12)
            {
                Console.WriteLine("Du har ej angett 12st siffror.");
            }
        }
        //--------------------------------------------------------
        //Method that checks that the correct year has been entered
        //--------------------------------------------------------
        static void CorrectYear(int year)
        {
            if (year < 1753 || year > 2020)
            {
                Console.WriteLine("Du har angett ett felaktigt årtal.");
            }
        }
    }
}
