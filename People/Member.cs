using System;

namespace Team.People
{
    public class Member : Person
    {
        private const string DEFAULT_REGISTRATION_DATE = "2002-01-01";
        private const string DEFAULT_POSITION = "stażysta";

        private DateTime registrationDate;

        private string position;

        public Member(
            string firstName,
            string lastName,
            string birthdate,
            string pesel,
            Gender gender
        )
            : this(
                firstName,
                lastName,
                birthdate,
                pesel,
                gender,
                DEFAULT_POSITION,
                DEFAULT_REGISTRATION_DATE
            )
        {
        }

        public Member(
            string firstName,
            string lastName,
            string birthdate,
            string pesel,
            Gender gender,
            string position,
            string registrationDate
        )
            : base(firstName, lastName, birthdate, pesel, gender)
        {
            this.registrationDate = ParseDate(registrationDate);
            this.position = position;
        }

        public override string ToString()
        {
            var basicInfo = base.ToString();
            return $"Członek {basicInfo} pracuje od {registrationDate.ToString("d")} jako {position}";
        }
    }
}
