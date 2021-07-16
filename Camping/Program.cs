using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camping
{
    class Program
    {
        static void Main(string[] args)
        {
            //initial
            DateTime start;
            DateTime finish;
            int people;
            int doge;
            int meter;
            string park;
            int countOut = 0;
            int countIn = 0;
            int rCost = 0;

            //questions
            while (true)
            {
                Console.WriteLine("Please enter your starting date.");
                try {start = Convert.ToDateTime(Console.ReadLine()); break;}
                catch (Exception){Console.WriteLine("Invalid: try again.");}
            }
            while (true)
            {
                Console.WriteLine("Please enter your end date.");
                try{finish = Convert.ToDateTime(Console.ReadLine());break;}
                catch (Exception){Console.WriteLine("Invalid: try again.");}
            }
            while (true)
            {
                Console.WriteLine("How many people?");
                try{people = Convert.ToInt32(Console.ReadLine());break;}
                catch (Exception){Console.WriteLine("Invalid: try again.");}
            }
            while (true)
            {
                Console.WriteLine("How many dogs?");
                try{doge = Convert.ToInt32(Console.ReadLine());break;}
                catch (Exception){Console.WriteLine("Invalid: try again.");}
            }
            while (true)
            {
                Console.WriteLine("How many meters?");
                try{meter = Convert.ToInt32(Console.ReadLine());break;
                }catch (Exception){Console.WriteLine("Invalid: try again.");}
            }
            while (true)
            {
                Console.WriteLine("Do you wish to park your car at the tent?");
                try{park = Console.ReadLine();break;}
                catch (Exception){Console.WriteLine("Invalid: try again.");}
            }
            
            //math for money
            CampingCosts campingCosts = new CampingCosts(start,finish,people,doge,meter,park,rCost,countOut,countIn);
            
            //answers
            int RC = campingCosts.regularCost();
            Console.WriteLine("The total cost is: " + RC);
            Console.ReadLine();
            int ID = campingCosts.cIns();
            int OD = campingCosts.cOuts();
            Console.WriteLine("The amount of days in season: " + ID);
            Console.WriteLine("The amount of days out of season: " + OD);
        }
    }
    public class CampingCosts
    {
        //all you need for a class
        DateTime begin; DateTime end; int person; int dog; int meters; string car; int rCosts; int cOut; int cIn;
        public CampingCosts(DateTime begin, DateTime end, int person, int dog, int meters, string car, int rCosts, int cOut, int cIN)
        {
            this.begin = begin; this.end = end; this.person = person; this.dog = dog; 
            this.meters = meters; this.car = car; this.rCosts = rCosts; this.cOut = cOut; this.cOut = cIn;
        }
        public DateTime getBegin() { return begin; } public DateTime getEnd() { return end; }
        public int getPerson() { return person; } public int getDog() { return dog; }
        public int getMeters() { return meters; } public string getCar() { return car; }
        public int getrCosts() { return rCosts; } public int getrcOut() { return cOut; }
        public int getrcIn() { return cIn; }
        //change
        //cost calculation
        public int regularCost()
        {
            int day1 = begin.Day;
            int month1 = begin.Month;
            int carcost = 0;
            int metercost = 0;
            double totalDays = (end - begin).TotalDays;
            int Ddays = Convert.ToInt32(totalDays) + 1;
            //loop per day
            for (int i = 0; i < Ddays; i++)
            {
                //members
                if (car == "yes"){carcost = 6;}
                else if (car == "no") {carcost = 0;}
                rCosts += (dog * 4) + (person * 5) + carcost;

                //in/out season
                if ((month1 == 7 && day1 >= 11) || (month1 == 8 && day1 <= 15))
                {rCosts += 30; cIn++;}
                else{rCosts += 25; cOut++;}
                day1++;
                if (day1 > 31 && (month1 == 1 || month1 == 3 || month1 == 5 || month1 == 7 || month1 == 8 || month1 == 10 || month1 == 12))
                { month1++; day1 = 1;}
                if (day1 > 30 && (month1 == 4 || month1 == 6 || month1 == 9 || month1 == 11))
                { month1++; day1 = 1; }
                if (day1 > 28 && month1 == 2)
                {month1++; day1 = 1;}
                if (month1 > 12)
                {month1 = 1;}
                
                //per meter
                if (meters > 10){metercost = (meters - 10) * 3;}
                else if (meters < 10){metercost = (meters - 10) * 2;}
                rCosts += metercost;
            }
            
            //return value
            return getrCosts();
        }
        public int cIns(){return cIn;}
        public int cOuts(){return cOut;}
    }
}
