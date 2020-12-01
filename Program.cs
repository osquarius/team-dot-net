using System;
using System.Globalization;

namespace Team
{
    using People;
    using Organization;
    public class Program
    {
        private static void Setup()
        {
            CultureInfo.CurrentCulture = new CultureInfo("pl-PL", false);
        }

        public static void Main(string[] args)
        {
            Setup();
            /* It would work like that if Person wasn't an abstract class

               var firstPerson = new Person(
               "Beata",
               "Nowak",
               "1992-10-22",
               "92102201347",
               Gender.Female
               );
               var secondPerson = new Person(
               "Jan",
               "Janowski",
               "1993-03-15",
               "93031507772",
               Gender.Male
               );

               Console.WriteLine(firstPerson);
               Console.WriteLine(secondPerson);
            */
            var firstMember = new Member(
                "Beata",
                "Nowak",
                "1992-10-22",
                "92102201347",
                Gender.Female,
                "projektant",
                "01-gru-2020"
            );
            var secondMember = new Member(
                "Jan",
                "Janowski",
                "1992-03-15",
                "92031507772",
                Gender.Male,
                "programista",
                "01-cze-2019"
            );
            var thirdMember = new Member(
                "Witold",
                "Adamski",
                "22.10.1992",
                "92102266738",
                Gender.Male,
                "sekretarz",
                "01-sty-2020"
            );
            var fourthMember = new Member(
                "Jan",
                "But",
                "16.05.1992",
                "92051613915",
                Gender.Male,
                "programista",
                "01-sty-2019"
            );
            var fifthMember = new Member(
                "Anna",
                "Mysza",
                "22.07.1991",
                "91072235964",
                Gender.Female,
                "projektant",
                "31-lip-2019"
            );
            var manager = new Manager(
                "Adam",
                "Kowalski",
                "1990-07-01",
                "90070100211",
                Gender.Male,
                5
            );
            var team = new Team("Grupa IT", manager);
            team.AddMember(firstMember);
            team.AddMember(secondMember);
            team.AddMember(thirdMember);
            team.AddMember(fourthMember);
            team.AddMember(fifthMember);
            Console.WriteLine(team);

            Console.WriteLine($"Zespół ma {team.MemberCount} członków");
            Console.WriteLine(
                "Czy osoba o peselu 91072235964 jest członkiem zespołu? {0}",
                team.HasMember("91072235964")
            );
            Console.WriteLine(
                "Czy osoba o peselu 01234567890 jest członkiem zespołu? {0}",
                team.HasMember("01234567890")
            );
            Console.WriteLine(
                "Czy Witold Adamski jest członkiem zespołu? {0}",
                team.HasMember("Witold", "Adamski")
            );
            Console.WriteLine(
                "Czy Adam Witoldski jest członkiem zespołu? {0}",
                team.HasMember("Adam", "Witoldski")
            );

            Console.WriteLine("\nProgramiści w zespole:");
            foreach(var programmer in team.FindMembers("programista"))
                Console.WriteLine(programmer);

            Console.WriteLine("\nW styczniu dołączyli:");
            foreach(var person in team.FindMembers(1))
                Console.WriteLine(person);

            Console.WriteLine("\nKlonujemy kierownika");
            var clonedManager = manager.Clone() as Manager;
            Console.WriteLine("Zmieniamy imię klonowi na \"Adaś\"");
            clonedManager.FirstName = "Adaś";
            Console.WriteLine("Zmiana imienia klona nie zmienia oryginału:");
            Console.WriteLine($"Oryginał: {manager}");
            Console.WriteLine($"Klon: {clonedManager}");

            Console.WriteLine("\nTeraz klonujemy cały zespół");
            var clonedTeam = team.Clone() as Team;
            Console.WriteLine("W sklonowanym zespole zmieniamy nazwę i kierownika");
            var secondManager = new Manager(
                "Rafał",
                "Marzec",
                "21.03.1988",
                "88032112357",
                Gender.Male
            );
            clonedTeam.CurrentManager = secondManager;
            clonedTeam.Name = "NowaGrupa";
            Console.WriteLine("Zmiany wpłynęły tylko na sklonowany zespół:");
            Console.WriteLine(team);
            Console.WriteLine(clonedTeam);

            Console.WriteLine("\nUkładamy wizytówki członków zespołu alfabetycznie");
            team.SortAlphabetically();
            Console.WriteLine(team);

            Console.WriteLine("\nZ zespołu odchodzi osoba o peselu 91072235964");
            team.RemoveMember("91072235964");
            Console.WriteLine(
                "Czy osoba o peselu 91072235964 dalej jest członkiem zespołu? {0}",
                team.HasMember("91072235964")
            );
            Console.WriteLine($"Liczba członków się zmniejszyła i wynosi {team.MemberCount}");
            Console.WriteLine("Z zespołu odchodzi Witold Adamski");
            team.RemoveMember("Witold", "Adamski");
            Console.WriteLine(
                "Czy Witold Adamski dalej jest członkiem zespołu? {0}",
                team.HasMember("Witold", "Adamski")
            );
            Console.WriteLine($"Liczba członków ponownie się zmniejszyła i wynosi {team.MemberCount}");

            Console.WriteLine("\nRozwiązujemy zespół");
            team.RemoveAllMembers();
            Console.WriteLine($"Liczba członków wynosi: {team.MemberCount}");
            Console.WriteLine("Rzeczywiście, został tylko kierownik:\n");
            Console.WriteLine(team);
        }

    }
}
