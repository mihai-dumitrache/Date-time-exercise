using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_time_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string genderType;
            int year;
            int personAge;
            byte month;
            byte date;
            var person = new Program();
            year = person.InsertYear();
            while (person.IsValidYear(year) == false)
            {
                year = person.InsertYear();
            }
            month = person.InsertMonth();
            while (person.IsValidMonth(month) == false)
            {
                month = person.InsertMonth();
            }
            date = person.InsertDate();
            while (person.IsValidDate(year, month, date) == false)
            {
                date = person.InsertDate();
            }
            Console.WriteLine("You have introduced the following date : {0}.{1}.{2}", date, month, year);
            personAge = person.AgeCalculation(year, month, date);
            Console.WriteLine("The person is {0} years old", personAge);
            Console.WriteLine("Please select a gender:");
            genderType = Console.ReadLine();
            while (person.IsValidGender(genderType) == false)
            {
                Console.WriteLine("Please select another gender:");
                genderType = Console.ReadLine();
            }
            person.CheckRetirement(genderType, personAge);

        }

        int InsertYear()
        {
            string insertedMonth;
            int monthParsed;
            Console.WriteLine("Please type a value for the year:");
            insertedMonth = Console.ReadLine();
            monthParsed = int.Parse(insertedMonth);
            return monthParsed;
        }

        bool IsValidYear(int year)
        {
            if (year > DateTime.Now.Year)
            {
                Console.WriteLine("You have typed an invalid year (the person isn't born yet)!");
                return false;
            }
            return true;
        }

        //insert the month
        byte InsertMonth()
        {
            string insertedMonth;
            byte monthParsed;
            Console.WriteLine("Please type a value for the month:");
            insertedMonth = Console.ReadLine();
            monthParsed = byte.Parse(insertedMonth);
            return monthParsed;
        }

        //check if month introduced is valid and retype until valid
        bool IsValidMonth(byte month)
        {
            if (month < 1 || month > 12)
            {
                Console.WriteLine("Your month is invalid. Please type another one");
                return false;
            }
            return true;
        }

        //insert the date
        byte InsertDate()
        {
            string insertedDate;
            byte dateParsed;
            Console.WriteLine("Please type a value for the date:");
            insertedDate = Console.ReadLine();
            dateParsed = byte.Parse(insertedDate);
            return dateParsed;
        }

        //check if date introduced is valid and retype until valid
        bool IsValidDate(int year, byte month, byte date)
        {
            //check for months with 31 days
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {

                while (date < 1 || date > 31)
                {
                    Console.WriteLine("Your date is invalid. Please type another one");
                    return false;
                }

            }

            //check for months with 30 days
            if (month == 4 || month == 6 || month == 9 || month == 11)
            {

                while (date < 1 || date > 30)
                {
                    Console.WriteLine("Your date is invalid. Please type another one");
                    return false;
                }

            }

            //check if February is in a leap year
            if (month == 2 && year % 4 == 0)
            {
                while (date < 1 || date > 29)
                {
                    Console.WriteLine("Your date is invalid. Please type another one");
                    return false;
                }
            }

            //check if February is not in a leap year
            if (month == 2 && year % 4 != 0)
            {
                while (date < 1 || date > 28)
                {
                    Console.WriteLine("Your date is invalid. Please type another one");
                    return false;
                }
            }

            return true;
        }

        //calculate age
        int AgeCalculation(int year, byte month, byte date)
        {
            int agePerson = 0;

            if (month < DateTime.Now.Month)
            {
                agePerson = DateTime.Now.Year - year;
            }
            if (month == DateTime.Now.Month)
            {
                if (date < DateTime.Now.Day)
                {
                    agePerson = DateTime.Now.Year - year - 1;
                }
                if (date == DateTime.Now.Day)
                {
                    agePerson = DateTime.Now.Year - year;
                    Console.WriteLine("HAPPY BIRTHDAY!");
                }
                if (date > DateTime.Now.Day)
                {
                    agePerson = DateTime.Now.Year - year;
                }

            }
            if (month > DateTime.Now.Month)
            {
                agePerson = DateTime.Now.Year - year - 1;
            }

            return agePerson;
        }
        enum Gender
        {
            F,//FEMALE
            M//MALE
        }

        //check if gender is valid
        bool IsValidGender(string gender)
        {
            Gender? genderType;
            if (gender == "M")
            {
                genderType = Gender.M;
                Console.WriteLine("Male");
                return true;
            }
            else if (gender == "F")
            {
                genderType = Gender.F;
                Console.WriteLine("Female");
                return true;
            }
            return false;
        }

        //check if person is retired
        void CheckRetirement(string gender, int age)
        {
            if (gender == "M" && age <= 65)
            {
                Console.WriteLine("The person is not retired yet!");
            }
            else if (gender == "M" && age > 65)
            {
                Console.WriteLine("Retired person!");
            }
            if (gender == "F" && age <= 62)
            {
                Console.WriteLine("The person is not retired yet!");
            }
            else if (gender == "F" && age > 62)
            {
                Console.WriteLine("Retired person!");
            }
        }
    }
}
