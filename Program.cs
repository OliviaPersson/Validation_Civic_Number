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
            if (userInput.Substring(4, 2) != "00")
            {
                //Takes out month, remove 0 if first number, converts and places in an int variable
                month = int.Parse(userInput.Substring(4, 2).TrimStart('0'));
            } 
         
            if (userInput.Substring(6, 2) != "00")
            {
                //Takes out day, convert and store in variable
                day = int.Parse(userInput.Substring(6, 2).TrimStart('0'));
            }
           
            //Takes out last integer in birtnumber and places in variable
            birthNumber = int.Parse(userInput.Substring(10, 1));

            //Method calls
            NumberOfDigits(userInput);
            CorrectYear(year);
            checkMonth(month);
            isLeapYear = checkLeapYear(year);
            gender = GetGender(birthNumber);

            // A first draft of arrays, for loop and if-set to check days in months
            int[] longMonth = new int[] { 1, 3, 5, 7, 8, 10, 12 };
            int[] shortMonth = new int[] { 4, 6, 9, 11 };
           
            //Loop that checks months array with 31 days
            for (int i=0; i < longMonth.Length; i++)
            {
                if (longMonth[i] == month)
                {
                    if (day > 31)
                    {
                        Console.WriteLine("Felaktig dag har angetts");
                    }
                }
            }
            //Loop that checks months array with 30 days
            for (int i = 0; i < shortMonth.Length; i++)
            {
                if (shortMonth[i] == month)
                {
                    if (day > 30)
                    {
                        Console.WriteLine("Felaktig dag har angetts");
                    }
                }
            }
            //Check month if year is not leap year
            if (isLeapYear == false)
            {
                if (month == 2)
                {
                    if (day > 28)
                    {
                        Console.WriteLine("Felaktig dag har angetts");
                    }
                }
            }
            //Check month if year is leap year
            else
            {
                if (month == 2)
                {
                    if (day > 29)
                    {
                        Console.WriteLine("Felaktig dag har angetts");
                    }
                }
            }
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
        //Method that checks month
        //--------------------------------------------------------
        static void checkMonth(int month)
        {
            if (month < 1 || month > 12)
            {
                Console.WriteLine("Du har angett en felaktig månad");
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
        //Method that checks valid days in months
        //--------------------------------------------------------
    }
}
