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
            bool correctNumberOfDigits = true;
            bool correctYear = true;
            bool correctMonth = true;
            bool correctValidDays = true;

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

            //Method calls that returns true, false and a string and stores in variable
            correctNumberOfDigits = NumberOfDigits(userInput);
            correctYear = CorrectYear(year);
            correctMonth = checkMonth(month);
            isLeapYear = checkLeapYear(year);
            correctValidDays = CheckValidDaysInMonth(isLeapYear, month, day);
            gender = GetGender(birthNumber);

            //Checks if all variables are true and then print to cmd
            if (correctNumberOfDigits && correctYear && correctMonth && correctValidDays)
            {
                Console.WriteLine("Personnumret är korrekt och du är {0} (juridiskt)", gender);
            }
       
            //Stop
            Console.ReadKey();
        }
        //--------------------------------------------------------
        // Method that checks that the number of digits is correct
        //--------------------------------------------------------
        static bool NumberOfDigits(string civicNumber)
        {
            //Expression that checks if the variable contains 12 digits
            if (civicNumber.Length < 12 || civicNumber.Length > 12)
            {
                Console.WriteLine("Du har ej angett 12st siffror.");
                return false;
            }
            return true;
        }
        //--------------------------------------------------------
        // Method that checks that the correct year has been entered
        //--------------------------------------------------------
        static bool CorrectYear(int year)
        {
            if (year < 1753 || year > 2020)
            {
                Console.WriteLine("Du har angett ett felaktigt årtal.");
                return false;
            }
            return true;
        }
        //--------------------------------------------------------
        // Method that checks month
        //--------------------------------------------------------
        static bool checkMonth(int month)
        {
            if (month < 1 || month > 12)
            {
                Console.WriteLine("Du har angett en felaktig månad");
                return false;
            }
            return true;
        }
        //--------------------------------------------------------
        // Method that checks if a year is a leap year
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
        // Method that checks gender
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
        // Method that checks valid days in months
        //--------------------------------------------------------
        static bool CheckValidDaysInMonth(bool isLeapYear, int month, int day)
        {
            //Months divided into variables based on days
            int[] longMonth = new int[] { 1, 3, 5, 7, 8, 10, 12 };
            int[] shortMonth = new int[] { 4, 6, 9, 11 };

            //Two method calls that return true or false and stores in variables
            bool correctLongMonth = LongMonthShortMonth(longMonth, month, day, 31);
            bool correctShortMonth = LongMonthShortMonth(shortMonth, month, day, 30);

            //checks if one of the two variables is false and if then return false
            if(correctLongMonth == false || correctShortMonth == false)
            {
                return false;
            }

            //Check month if year is not leap year
            if (isLeapYear == false)
            {
                //Checks February
                if (month == 2)
                {
                    //If day is greater than 28 print to cmd
                    if (day > 28)
                    {
                        Console.WriteLine("Felaktig dag har angetts");
                        return false;
                    }
                }
            }
            //Check February if year is leap year
            else
            {
                if (month == 2)
                {
                    if (day > 29)
                    {
                        Console.WriteLine("Felaktig dag har angetts");
                        return false;
                    }
                }
            }
            return true;
        }
        //--------------------------------------------------------
        //Method that checks LongMonth and shortMonth
        //--------------------------------------------------------
        static bool LongMonthShortMonth(int[] array, int month, int day, int daysInMonth)
        {
            //Loop to go through the array
            for (int i = 0; i < array.Length; i++)
            {
                //Checks if number i i position is equal to month
                if (array[i] == month)
                {
                    //If day is greater than daysInMonth print to cmd
                    if (day > daysInMonth)
                    {
                        Console.WriteLine("Felaktig dag har angetts");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
