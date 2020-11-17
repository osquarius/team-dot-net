using System;
using System.Globalization;

namespace Team.People
{
    public abstract class Person
    {
        private const string DEFAULT_FIRST_NAME = "John";
        private const string DEFAULT_LAST_NAME = "Doe";
        private const string DEFAULT_BIRTHDATE = "1980-01-01";
        private const string DEFAULT_PESEL = "80010100010";
        private const Gender DEFAULT_GENDER = Gender.Male;

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName { get; set; }

        private DateTime birthdate;
        public DateTime Birthdate
        {
            get => birthdate;
            set => birthdate = value;
        }

        private string pesel;
        public string Pesel
        {
            get
            {
                return pesel;
            }
        }

        private Gender gender;
        public string GenderName
        {
            get
            {
                if(gender == Gender.Male)
                    return "Mężczyzna";
                else if(gender == Gender.Female)
                    return "Kobieta";
                else
                    return "Nie podaje płci";
            }
        }

        public Person()
            : this(DEFAULT_FIRST_NAME, DEFAULT_LAST_NAME)
        {
        }

        public Person(string firstName, string lastName)
            : this(firstName, lastName, DEFAULT_BIRTHDATE, DEFAULT_PESEL, DEFAULT_GENDER)
        {
        }

        public Person(string firstName, string lastName, string birthdate, string pesel, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = ParseDate(birthdate);
            this.pesel = pesel;
            this.gender = gender;
        }

        public int Age()
        {
            return DateTime.Now.Year - birthdate.Year;
        }

        public override string ToString()
        {
            var currentAge = Age();
            var plural = YearsPolishPluralForm(currentAge);
            return $"{FirstName} {LastName} ur. {birthdate.ToString("d")} (pesel: {pesel}) - {GenderName} ({currentAge} {plural})";
        }

        protected static DateTime ParseDate(string date)
        {
            DateTime result = new DateTime();
            DateTime.TryParseExact(
                date,
                new[] {
                    "yyyy-MM-dd",
                    "yyyy/MM/dd",
                    "MM/dd/yy",
                    "dd-MMM-yyyy",
                    "dd-MMM-yy",
                    "dd.MM.yyyy"
                },
                null,
                DateTimeStyles.None,
                out result
            );
            return result;
        }

        protected static string YearsPolishPluralForm(int years)
        {
            if(years == 1)
                return "rok";
            else if(years % 10 <= 4 && years % 10 > 0)
                return "lata";
            else
                return "lat";
        }
    }
}

