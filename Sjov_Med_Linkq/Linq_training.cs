namespace Sjov_Med_Linkq
{
    class Linq_training
    {
        static void Main(string[] args)
        {
            List<ClubMember> memberList = new List<ClubMember>();

            memberList.Add(new ClubMember { Id = 1, FirstName = "Farrand", LastName = "Semkins", Gender = Gender.Female, Age = 77 });
            memberList.Add(new ClubMember { Id = 2, FirstName = "Trev", LastName = "Quail", Gender = Gender.Male, Age = 84 });
            memberList.Add(new ClubMember { Id = 3, FirstName = "Dani", LastName = "Ballister", Gender = Gender.Female, Age = 76 });
            memberList.Add(new ClubMember { Id = 4, FirstName = "Hyacinthe", LastName = "Mish", Gender = Gender.Female, Age = 70 });
            memberList.Add(new ClubMember { Id = 5, FirstName = "Jarib", LastName = "Boustred", Gender = Gender.Male, Age = 32 });
            memberList.Add(new ClubMember { Id = 6, FirstName = "Erl", LastName = "Meeson", Gender = Gender.Male, Age = 62 });
            memberList.Add(new ClubMember { Id = 7, FirstName = "Aile", LastName = "Highman", Gender = Gender.Female, Age = 79 });
            memberList.Add(new ClubMember { Id = 8, FirstName = "Rheta", LastName = "Battelle", Gender = Gender.Female, Age = 42 });
            memberList.Add(new ClubMember { Id = 9, FirstName = "Olimpia", LastName = "Foulsham", Gender = Gender.Female, Age = 60 });
            memberList.Add(new ClubMember { Id = 10, FirstName = "Dagny", LastName = "Ilchenko", Gender = Gender.Male, Age = 34 });
            memberList.Add(new ClubMember { Id = 11, FirstName = "Davis", LastName = "Gilbrid", Gender = Gender.Male, Age = 46 });
            memberList.Add(new ClubMember { Id = 12, FirstName = "Kamillah", LastName = "Bahls", Gender = Gender.Female, Age = 24 });
            memberList.Add(new ClubMember { Id = 13, FirstName = "Flore", LastName = "Ansley", Gender = Gender.Female, Age = 89 });
            memberList.Add(new ClubMember { Id = 14, FirstName = "Glad", LastName = "Clowser", Gender = Gender.Female, Age = 48 });
            memberList.Add(new ClubMember { Id = 15, FirstName = "Christian", LastName = "Congram", Gender = Gender.Female, Age = 33 });
            memberList.Add(new ClubMember { Id = 16, FirstName = "Tore", LastName = "Saggs", Gender = Gender.Male, Age = 28 });
            memberList.Add(new ClubMember { Id = 17, FirstName = "Vevay", LastName = "Klezmski", Gender = Gender.Female, Age = 43 });
            memberList.Add(new ClubMember { Id = 18, FirstName = "Bren", LastName = "Merrikin", Gender = Gender.Female, Age = 46 });
            memberList.Add(new ClubMember { Id = 19, FirstName = "Benoit", LastName = "Filler", Gender = Gender.Male, Age = 16 });
            memberList.Add(new ClubMember { Id = 20, FirstName = "Lucien", LastName = "Bottrell", Gender = Gender.Male, Age = 41 });
            memberList.Add(new ClubMember { Id = 21, FirstName = "Emmy", LastName = "Pechell", Gender = Gender.Male, Age = 61 });
            memberList.Add(new ClubMember { Id = 22, FirstName = "Merle", LastName = "Bennett", Gender = Gender.Female, Age = 42 });
            memberList.Add(new ClubMember { Id = 23, FirstName = "Solomon", LastName = "Sarrell", Gender = Gender.Male, Age = 61 });
            memberList.Add(new ClubMember { Id = 24, FirstName = "Shurrock", LastName = "Shreenan", Gender = Gender.Male, Age = 84 });
            memberList.Add(new ClubMember { Id = 25, FirstName = "Chadd", LastName = "Hanney", Gender = Gender.Male, Age = 80 });

            //List<ClubMember> list = memberList.OrderBy(x => x.Age).ToList();
            
            IEnumerable<ClubMember> list = memberList.Where(x => x.Age > 50).OrderBy(x => x.Age);

            //foreach (ClubMember cm in list)
            //{
            //    Console.WriteLine(cm);
            //}

            //list.ToList().ForEach(cm => Console.WriteLine(cm));

            IEnumerable<string> names = memberList.Where(x => x.Age > 50)
                                                  .OrderBy(x => x.Age)
                                                  .Select(x => x.FirstName + "" + x.LastName)
                                                  .OrderBy(x => x);

            names.ToList().ForEach(cm => Console.WriteLine(cm));

            double average = memberList.Average(x => x.Age);
            Console.WriteLine("\naverage age is " + average);

            Console.ReadLine();
        }
    }
}
