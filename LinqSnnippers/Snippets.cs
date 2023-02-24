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
            List<int> numbers = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 };

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

        // Paging with Skip & Take

        static public IEnumerable<T> GetPage<T>(IEnumerable<T> colletion, int pageNumber, int resultPerPage)
        {
            int starIndex = (pageNumber - 1) * resultPerPage;
            return colletion.Skip(starIndex).Take(resultPerPage);
        }

        // Variables
        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                                 let average = numbers.Average()
                                 let nSquared = Math.Pow(number, 2)
                                 where nSquared > average
                                 select number;

            Console.WriteLine("Average: {0}", numbers.Average());

            foreach (var number in aboveAverage)
            {
                Console.WriteLine("Number: {0} Square: {1} ", number, Math.Pow(number, 2));
            }
        } 

        // ZIP 
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);
        }

        static public void repeatRangeLinq()
        {
            // Generate colletion from 1 - 1000 --> range
            IEnumerable<int> first1000 = Enumerable.Range(1, 1000);

            // Repeat a value N time
            IEnumerable<string> fiveX = Enumerable.Repeat("X", 5);
        }

        // 
        static public void studentsLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Hector",
                    Grade = 100,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "Pedro",
                    Grade = 87,
                    Certified = false
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 55,
                    Certified = true
                },new Student
                {
                    Id = 4,
                    Name = "Luisa",
                    Grade = 65,
                    Certified = true
                },
                new Student
                {
                    Id = 5,
                    Name = "Jose",
                    Grade = 50,
                    Certified = true
                },
                new Student
                {
                    Id = 6,
                    Name = "Luis",
                    Grade = 48,
                    Certified = false
                },
            };

            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certified == false
                                       select student;

            var aprovedStudentsNames = from student in classRoom
                                       where student.Grade >= 50 && student.Certified == true
                                       select student.Name; 
        }

        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };

            bool allAreSmallerThan10 = numbers.All(x => x < 10); // true

            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); // false

            var emptyList = new List<int>();
            bool allnumbersAreGreaterThan0 = numbers.All(x => x >= 0); // true
        }

        // aggregate

        static public void aggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 5, 6, 7, 8, 9, 10 };

            // sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            // 0,1 => 1
            // 1,2 => 3 ...

            string[] words = { "hello,", "my", "name", "is", "Martin" }; // hello, my name is Martin 
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);

            // "", "hello," => hello,
            // "hello,", "my" => hello, my ...
        }

        // Distinct
        static public void distinctValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };

            IEnumerable<int> distinctValues = numbers.Distinct();

        }

        // Group By

        static public void groupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            foreach(var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); // 
                }
            }

            // another example
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Hector",
                    Grade = 100,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "Pedro",
                    Grade = 87,
                    Certified = false
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 55,
                    Certified = true
                },new Student
                {
                    Id = 4,
                    Name = "Luisa",
                    Grade = 65,
                    Certified = true
                },
                new Student
                {
                    Id = 5,
                    Name = "Jose",
                    Grade = 50,
                    Certified = true
                },
                new Student
                {
                    Id = 6,
                    Name = "Luis",
                    Grade = 48,
                    Certified = false
                },
            };

            var certifiedQuery = classRoom.GroupBy(student => student.Certified && student.Grade >= 50);

            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("-------- {0} --------", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name); // 
                }
            }
        }

        static public void relationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "My First post",
                    Content = "My first content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "my first title",
                            Content = "my first content"
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "my second title",
                            Content = "my second content"
                        },
                    }
                },
                new Post()
                {
                    Id = 2,
                    Title = "My 2 post",
                    Content = "My f2 content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "my 3 title",
                            Content = "my 3 content"
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "my 4 title",
                            Content = "my 4 content"
                        },
                    }
                },
                new Post()
                {
                    Id = 3,
                    Title = "My 3 post",
                    Content = "My 3 content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 5,
                            Created = DateTime.Now,
                            Title = "my 5 title",
                            Content = "my 5 content"
                        },
                        new Comment()
                        {
                            Id = 6,
                            Created = DateTime.Now,
                            Title = "my 6 title",
                            Content = "my 6 content"
                        },
                    }
                }
            };

            var commentsWithContent = posts.SelectMany(post => post.Comments,
                (post, comment) => new {PostId = post.Id, CommentContent = comment.Content});
        }
    }
}