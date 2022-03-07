using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambdaEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FruitData> fruits = new List<FruitData>()
            {
                new FruitData{Id = "f1", Name = "Apple", Color= Color.Red, Price= 23.0},
                new FruitData{Id = "f2", Name = "Banana", Color= Color.Yellow, Price= 10.0},
                new FruitData{Id = "f3", Name = "Pineapple", Color= Color.Yellow, Price= 55.0},
                new FruitData{Id = "f4", Name = "Cherry", Color= Color.Red, Price= 40.0},
                new FruitData{Id = "f5", Name = "Watermelon", Color= Color.Green, Price= 28.0},
                new FruitData{Id = "f6", Name = "Strawberry", Color= Color.Red, Price= 33.0},

            };

            var cheapestprice = 20;
            var mostexpensiveprice = 45;
            var budget = 40;

            //1) Get ordered fruits in descending order.
            var fruitDescendingOrderedLinq = (from fruit in fruits
                                             orderby fruit.Name descending
                                             select fruit).ToList();
            var fruitDescendingOrderedLambda = fruits.OrderByDescending(fruit => fruit.Name).ToList();


            //2) Get ordered fruits in ascending order.
            var fruitAscendingOrderedLinq = (from fruit in fruits
                                              orderby fruit.Name
                                              select fruit).ToList();
            var fruitAscendingOrderedLambda = fruits.OrderBy(fruit => fruit.Name).ToList();

            //3) Get red and green fruits.
            var redAndGreenFruitLinq = (from fruit in fruits
                                         where fruit.Color == Color.Red || fruit.Color == Color.Green
                                        select fruit).ToList();
            var redAndGreenFruitLambda = fruits.Where(fruit => fruit.Color == Color.Red || fruit.Color == Color.Green).ToList();

            //4) Get cheapest fruit.
            var cheapestFruitLinq = (from fruit in fruits
                                        where fruit.Price <= cheapestprice
                                        select fruit).ToList();
            var cheapestFruitLambda = fruits.Where(fruit => fruit.Price == 10.0 ).ToList();

            //5)Get most expensive fruit.

            var expensiveFruitLinq = (from fruit in fruits
                                     where fruit.Price >= mostexpensiveprice
                                     select fruit).ToList();
            var expensiveFruitLambda = fruits.Where(fruit => fruit.Price == 55.0).ToList();

            //6)Get fruits by budget of 40 RS.

            var budgetFruitsLinq = (from fruit in fruits
                                      where fruit.Price <= budget
                                      select fruit).ToList();
            var budgetFruitsLambda = fruits.Where(fruit => fruit.Price <= budget).ToList();

            //7)Get count of red fruits.
            var countRedFruitLinq = (from fruit in fruits
                                    where fruit.Color == Color.Red
                                    select fruit).Count();
            var countRedFruitsLambda = fruits.Count(fruit => fruit.Color == Color.Red);


            //8)Group fruits with colors.
            var groupColorFruitLinq = from fruit in fruits
                                      group fruit by fruit.Color into fruitGroup
                                      select fruitGroup;

            var groupColorFruitsLambda = fruits.GroupBy(fruit => fruit.Color);

            //GetDetails(budgetFruitsLambda);
            //Console.WriteLine("Red Color Fruits are: " + countRedFruitLinq);
            //Console.WriteLine("Red Color Fruits are: " + countRedFruitsLambda);

            foreach (var fruitGroup in groupColorFruitLinq)
            {
                Console.WriteLine(fruitGroup.Key);
                foreach (var fruit in fruitGroup)
                {

                    Console.WriteLine("    "+ fruit.Name);


                }
            
            }
            Console.ReadKey();
        }

        public static void GetDetails(List<FruitData> fruits)
        {

            foreach (var fruit in fruits)
            {

                Console.WriteLine(fruit.Name);
            }

        }
    }
}
