using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Team.People;

namespace Team.Organization
{
    public class Team : ICloneable
    {
        public int MemberCount
        {
            get
            {
                return members.Count;
            }
        }

        public string Name { get; set; }

        private Manager manager;
        public Manager CurrentManager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
            }
        }

        private List<Member> members;

        public Team()
        {
            Name = null;
            manager = null;
            members = new List<Member>();
        }

        public Team(string name, Manager manager)
            : this()
        {
            Name = name;
            this.manager = manager;
        }

        public void AddMember(Member member)
        {
            members.Add(member);
        }

        public bool HasMember(string pesel)
        {
            return members.Any(member => member.Pesel == pesel);
        }

        public bool HasMember(string firstName, string lastName)
        {
            return members.Any(
                member => (member.FirstName == firstName && member.LastName == lastName)
            );
        }

        public void RemoveMember(string pesel)
        {
            members.RemoveAll(member => member.Pesel == pesel);
        }

        public void RemoveMember(string firstName, string lastName)
        {
            members.RemoveAll(
                member => (member.FirstName == firstName && member.LastName == lastName)
            );
        }

        public void RemoveAllMembers()
        {
            members.Clear();
        }

        public List<Member> FindMembers(string position)
        {
            return members.FindAll(
                member => member.Position == position
            );
        }

        public List<Member> FindMembers(int monthNumber)
        {
            return members.FindAll(
                member => member.RegistrationDate.Month == monthNumber
            );
        }

        public void SortAlphabetically()
        {
            members.Sort();
        }

        public object Clone()
        {
            var clone = new Team(Name, CurrentManager.Clone() as Manager);
            foreach(var member in members)
                clone.AddMember(member.Clone() as Member);
            return clone;
        }

        public override string ToString()
        {
            var builder = new StringBuilder($"Zespół \"{Name}\"\n");
            builder.AppendLine(manager.ToString());
            builder.AppendJoin("\n", members);
            return builder.ToString();
        }
    }
}
