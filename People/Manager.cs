using System;

namespace Team.People
{
    [Serializable]
    public class Manager : Person
    {
        private const int DEFAULT_EXPERIENCE = 0;

        private int experience;

        private Manager()
            : base()
        {
        }

        public Manager(
            string firstName,
            string lastName,
            string birthdate,
            string pesel,
            Gender gender
        )
            : this(firstName, lastName, birthdate, pesel, gender, DEFAULT_EXPERIENCE)
        {
        }

        public Manager(
            string firstName,
            string lastName,
            string birthdate,
            string pesel,
            Gender gender,
            int experience
        )
            : base(firstName, lastName, birthdate, pesel, gender)
        {
            this.experience = experience;
        }

        public override object Clone()
        {
            return new Manager(
                FirstName,
                LastName,
                Birthdate.ToString("d"),
                Pesel,
                gender,
                experience
            );
        }

        public override string ToString()
        {
            var basicInfo = base.ToString();
            var plural = YearsPolishPluralForm(experience);
            return $"Kierownik {basicInfo} ma {experience} {plural} doświadczenia";
        }
    }
}
