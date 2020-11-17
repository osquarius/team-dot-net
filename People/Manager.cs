namespace Team.People
{
    public class Manager : Person
    {
        private const int DEFAULT_EXPERIENCE = 0;

        private int experience;

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

        public override string ToString()
        {
            var basicInfo = base.ToString();
            var plural = YearsPolishPluralForm(experience);
            return $"Kierownik {basicInfo} ma {experience} {plural} doświadczenia";
        }
    }
}
