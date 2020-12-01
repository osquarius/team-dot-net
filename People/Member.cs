using System;

namespace Team.People
{
    public class Member : Person, IComparable<Member>
    {
        private const string DEFAULT_REGISTRATION_DATE = "2002-01-01";
        private const string DEFAULT_POSITION = "stażysta";

        private DateTime registrationDate;
        public DateTime RegistrationDate
        {
            get
            {
                return registrationDate;
            }
        }

        private string position;
        public string Position
        {
            get
            {
                return position;
            }
        }

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

        public override object Clone()
        {
            return new Member(
                FirstName,
                LastName,
                Birthdate.ToString("d"),
                Pesel,
                gender,
                position,
                registrationDate.ToString("d")
            );
        }

        public int CompareTo(Member other)
        {
            var comparisonResult = string.Compare(LastName, other.LastName);
            if(comparisonResult != 0)
                return comparisonResult;
            return string.Compare(FirstName, other.FirstName);
        }

        public override string ToString()
        {
            var basicInfo = base.ToString();
            return $"Członek {basicInfo} pracuje od {registrationDate.ToString("d")} jako {position}";
        }
    }
}
