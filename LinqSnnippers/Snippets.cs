namespace LinqSnnippers
{

    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VM Golf",
                "VM California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };

            // 1.- SELECT * FROM cars
            var carlist = from car in cars
                          select car;
            foreach (var car in carlist)
            {
                Console.WriteLine(car);
            }

            // 2.- SELECT EHERE * FROM cars
            var audilist = from car in cars
                           where car.Contains("Audi")
                           select car;

            foreach (var aud in audilist)
            {
                Console.WriteLine(aud);
            }

        }

        static public void LinqNumbers()
        {
            List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];

            // each number multiplied by 3
            // take all numbers, but 9
            // Order numbers by ascending value
            var processedNumbers = numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);

            foreach (var num in processedNumbers)
            {
                Console.WriteLine(num);
            }

        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
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

            // 1.- first all element
            var first = textList.First();
            // 2.- first element that is "c"
            var cText = textList.First(text => text.Equals("c"));
            // 3 first element that contain j
            var jText = textList.First(text => text.Contains("j"));
            // 4.- first element that contains "z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));
            // 5.- last element that contains "z" or default
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));
            // 6.- single value
            var uniqueTexts = textList.Single();
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherNumbers = { 0, 2, 6 };

            // Obtain {4,8}
            var myEven = evenNumbers.Except(otherNumbers);

        }

        static public void MultipleSelects()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, TExt 1",
                "Opinion 2, TExt 2",
                "Opinion 3, TExt 3"
            };

            var myOpinionSelection = myOpinions.SelectMany(op => op.Split(","));

            var enterprises = new[]
            {
                new Enterprise
                {
                    Id=1,
                    Name = "Enterprise 1",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Hector",
                            Email = "aux1@gmail.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Miguel",
                            Email = "aux2@gmail.com",
                            Salary = 1000
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "PEDRO",
                            Email = "aux3@gmail.com",
                            Salary = 2000
                        },
                    }

                },
                new Enterprise
                {
                    Id=2,
                    Name = "Enterprise 2",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Ana",
                            Email = "aux1@gmail.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Maria",
                            Email = "aux2@gmail.com",
                            Salary = 1400
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Marta",
                            Email = "aux3@gmail.com",
                            Salary = 4000
                        },
                    }

                }
            };

            // obtain all employees of all enterprise
            var employeeList = enterprises.SelectMany(e => e.Employees);

            // know if ana listy is empty
            bool hasEnterprise = enterprises.Any();
            bool hasEmplyees = enterprises.Any(e => e.Employees.Any());

            // all enterprises at least employees with at least 1000$ of salary
            bool hasSalary = enterprises.Any(e => e.Employees.Any(employee => employee.Salary >= 1000));
        }

        static public void linqColletions()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondtList = new List<string>() { "a", "c", "d" };

            // INNER JOIN
            var commonResult = from a in firstList
                               join b in secondtList
                               on a equals b
                               select new { a, b };

            var commonResult2 = firstList.Join(
                secondtList, 
                e => e,
                se => se,
                (e, se) => new { e, se }
                );

            // OUTER JOIN - LEFT
            var leftOuterJoin = from e in firstList
                                join es in secondtList
                                on e equals es
                                into tempList
                                from tempE in tempList.DefaultIfEmpty()
                                where e != tempE
                                select new { Element = e };

            var leftOuterJoin2 = from e in firstList
                                 from se in secondtList.Where(c => c == e).DefaultIfEmpty()
                                 select new { Element = e, SecondElement = se };

            // OUTER JOIN - right
            var rightOuterJoin = from es in secondtList
                                 join e in firstList
                                on es equals e
                                into tempList
                                from tempE in tempList.DefaultIfEmpty()
                                where es != tempE
                                select new { Element = es };

            // UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9
            };

            // SKIP

            var skipTwoFirst = myList.Skip(2);
            var skipTwoLast = myList.SkipLast(2);
            var skipWhile = myList.SkipWhile(num => num < 4);

            // TAKE

            var takefirst = myList.Take(2);
            var takeLast = myList.TakeLast(2);
            var takeWhile = myList.TakeWhile(num => num < 4);

        }

    }
}