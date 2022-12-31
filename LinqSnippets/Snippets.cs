using Microsoft.VisualBasic;
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

        //Paging with Skip & Take
        public static IEnumerable<T> GetPage<T>(IEnumerable<T> Collection, int pagNumber, int resultsPerPage)
        {
            int StartIndex = (pagNumber - 1) * resultsPerPage;
            return Collection.Skip(StartIndex).Take(resultsPerPage);
        }

        //variables
        public static void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine("Average: {0} ", numbers.Average());

            foreach(int number in aboveAverage)
            {
                Console.WriteLine("Query: Number: {0} Square: {1} ", number, Math.Pow(number, 2));
            }
        }

        //ZIP
        public static void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "Three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + " = " + word);

            // { "1 = one", "2 = two", ...}
        }

        //Repeat & Range
        public static void repeatRangeLinq()
        {
            //Generate collection from 1- 1000 --> RANGE
            var first1000 = Enumerable.Range(1, 1000);

            //Repeat a value N Times --> REPEAT
            var fiveXs = Enumerable.Repeat("X", 5); // {"X", "X", "X", "X", "X"}
        }

        public static void StudentsLinq()
        {
            var classRoom = new[]
            {
                new Student()
                {
                    Id = 1,
                    Name = "Erick",
                    Grade = 50, 
                    Certified = true

                },
                new Student()
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false

                },
                new Student()
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true

                },
                new Student()
                {
                    Id = 4,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = false

                },
                new Student()
                {
                    Id = 5,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false

                }
            };

            var certifiedStudents = from student in classRoom
                                   where student.Certified
                                   select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certified == false
                                       select student;

            var appovedStudentsNames = from student in classRoom
                                  where student.Grade >= 50 && student.Certified == true
                                  select student.Name;
        }

        //ALL
        public static void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };

            bool allAreSmallerThan10 = numbers.All(x => x < 10); // true
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); //false

            var emptyList = new List<int>();
            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); // true
        }

        //aggregate

        public static void AggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);
            
            // 0,1 => 1
            // 1,2 => 3
            // 3,3 => 6
        }

        //DISTINCT
        public static void DistinctLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };

            IEnumerable<int> distinctValues = numbers.Distinct();

        }

        //GROUPBY
        public static void groupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            //we will have two groups
            //1. the group that doesnt fit the condition(odd numbers)
            //2. the group thats fits the condition(even numbers)

            foreach(var group in grouped)
            {
                foreach( var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9 ... 2,3,6,8(first the odds and then the even)
                }
            }

            var classRoom = new[]
            {
                new Student()
                {
                    Id = 1,
                    Name = "Erick",
                    Grade = 50,
                    Certified = true

                },
                new Student()
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false

                },
                new Student()
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true

                },
                new Student()
                {
                    Id = 4,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = false

                },
                new Student()
                {
                    Id = 5,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false

                }
            };

            var CertifiedQuery = classRoom.GroupBy(student => student.Certified == true);

            //We obtain two groups
            //1- Not Certified students
            //2- Certified students

            foreach (var group in CertifiedQuery)
            {
                Console.WriteLine("-------------{0}-------------", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }

        public static void relationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "My first Post",
                    Content = "My first Content",
                    Created = DateTime.Now,
                    Comments= new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created= DateTime.Now,
                            Title = "My first Comment",
                            Content = "My first comment content"
                        }
                    }
                },
                new Post()
                {
                    Id = 2,
                    Title = "My second Post",
                    Content = "My second Content",
                    Created = DateTime.Now,
                    Comments= new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 2,
                            Created= DateTime.Now,
                            Title = "My second Comment",
                            Content = "My second comment content"
                        }
                    }
                }
            };

            var commenWithContent = posts.SelectMany(post => post.Comments,
                    (post, comment) => new {PostId = post.Id, CommentContent = comment.Content});

        }

    }
}