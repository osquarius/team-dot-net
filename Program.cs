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
        }

    }
}
