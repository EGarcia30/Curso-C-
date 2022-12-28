using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        public static void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };

            // 1. SELECT * of cars
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is audi
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }

        //Number Examples
        public static void LinQNumbers()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //each number multiplied by 3
            //take all numbers, but 9
            //order numbers by ascending value

            var processedNumberList =
                numbers
                .Select(num => num * 3) // {3, 6, 9, etc..}
                .Where(num => num != 9) // { all but the 9}
                .OrderBy(num => num); // at the end, we order ascending.
        }

        public static void SearchElements()
        {
            List<string> textList = new List<string>()
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            // 1. first of all elements
            var first = textList.First();

            // 2. first element that is "c"
            var cText = textList.First(num => num.Equals("c"));

            // 3. first element that contains "j"
            var jtext = textList.First(text => text.Contains("j"));

            // 4. first element that contains "z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));

            // 5. last or default that contains "z"
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            // 6. Single Values
            var uniqueText = textList.Single();
            var uniqueOrDefault = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6 };
            int[] otherEvenNumbers = { 0, 2, 6, };

            //obtain 4, 8
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers); // { 4, 8}
        }

        public static void MultipleSelects()
        {
            //select many
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionSelect = myOpinions.SelectMany(opinion => opinion.Split(','));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id= 1,
                    Name="Enterprise 1",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id= 1,
                            Name= "Erick",
                            Email= "Erick@mail.com",
                            Salary = 3000

                        },
                        new Employee()
                        {
                            Id= 2,
                            Name= "Juan",
                            Email= "Juan@mail.com",
                            Salary = 2000

                        },
                        new Employee()
                        {
                            Id= 3,
                            Name= "Pedro",
                            Email= "Pedro@mail.com",
                            Salary = 4000

                        },
                    }
                },
                new Enterprise()
                {
                    Id= 2,
                    Name="Enterprise 2",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id= 4,
                            Name= "Ana",
                            Email= "ana@mail.com",
                            Salary = 3000

                        },
                        new Employee()
                        {
                            Id= 5,
                            Name= "maria",
                            Email= "maria@mail.com",
                            Salary = 2000

                        },
                        new Employee()
                        {
                            Id= 6,
                            Name= "Jose",
                            Email= "Jose@mail.com",
                            Salary = 1000

                        }
                    }
                }
            };

            //obtain all employees of all Enterprises
            var employeesLists = enterprises.SelectMany(enterprise => enterprise.Employees);

            //know if ana list is empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            //All enterprises at least employees with at least 1000$ of salary
            bool hasEmployeeWithSalaryMoreThanOrEqual1000 =
                enterprises.Any(enterprise => enterprise.Employees.Any(employee => employee.Salary > 1000));
        }

        public static void linqColletions()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            //INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
                    secondList,
                    element => element,
                    secondElement => secondElement,
                    (element, secondElement) => new { element, secondElement });

            //OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            //OUTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                                join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };

            //UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        public static void SkipTakeLinq()
        {
            var myList = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            //SKIP

            var skipTwoFirstValues = myList.Skip(2); // { 3, 4, 5, 6, 7, 8, 9, 10 }

            var skipLastaTwoValues = myList.SkipLast(2); // { 1, 2, 3, 4, 5, 6, 7, 8 }

            var skipWhile = myList.SkipWhile(num => num < 4); // { 4, 5, 6, 7, 8, 9, 10 }

            //TAKE

            var takeFirstTwoValues = myList.Take(2); // { 1, 2 }

            var takeLastTwoValues = myList.TakeLast(2); // { 9, 10 }

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4); // { 1, 2, 3 }
        }
    }
}