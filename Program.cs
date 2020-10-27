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
            string gender = "";

            int year = 0;
            int month = 0;
            int day = 0;
            int birthNumber = 0;

            bool isLeapYear = true;

            //Ask user for input
            Console.WriteLine("Skriv in ett 12-siffrigt personnummer enligt följande YYYYMMDDnnnc: ");
            userInput = Console.ReadLine();

            //Takes out year, converts and places in an int variable
            year = int.Parse(userInput.Substring(0, 4));
           
            //Checks if userinput is 00
            if(userInput.Substring(4, 2) != "00")
            {
                //Takes out month, remove 0 if first number, converts and places in an int variable
                month = int.Parse(userInput.Substring(4, 2).TrimStart('0'));
            } 
         
            //Takes out day, convert and store in variable
            day = int.Parse(userInput.Substring(6, 2));
            //Takes out last integer in birtnumber and places in variable
            birthNumber = int.Parse(userInput.Substring(10, 1));

            //Calls method NumberOfDigits and sends in string value
            NumberOfDigits(userInput);
            //Calls method CorrectYear and send in int variable
            CorrectYear(year);
            // Calls method checkLeapYear and stores true or false in variable
            isLeapYear = checkLeapYear(year);
            // Calls method checkGender and stores in variable
            gender = GetGender(birthNumber);

            checkMonth(month);
            

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
        //--------------------------------------------------------
        //Method that checks if a year is a leap year
        //--------------------------------------------------------
        static bool checkLeapYear(int year)
        {
            if (year % 400 == 0)
            {
                return true;
            }
            else if (year % 100 == 0)
            {
                return false;
            }
            else if (year % 4 == 0)
            {
                return true;
            }
            return false;
        }
        //--------------------------------------------------------
        //Method that checks gender
        //--------------------------------------------------------
        static string GetGender(int birthNumber)
        {
            if (birthNumber == 0 || birthNumber % 2 == 0)
            {
                return "kvinna";
            }
            else
            {
                return "man";
            }
        } 
        //--------------------------------------------------------
        //Method that checks month
        //--------------------------------------------------------
        static void checkMonth(int month)
        {
            if(month < 1 || month > 12)
            {
                Console.WriteLine("Du har angett en felaktig månad");
            }
        }
    }
}
