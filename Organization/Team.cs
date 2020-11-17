using System.Collections.Generic;
using System.Text;
using System.Linq;

using Team.People;

namespace Team.Organization
{
    public class Team
    {
        private int memberCount;
        public int MemberCount
        {
            get
            {
                return memberCount;
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
        }

        private List<Member> members;

        public Team()
        {
            memberCount = 0;
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
            memberCount++;
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

        public void RemoveMembers(string firstName, string lastName)
        {
            members.RemoveAll(
                member => (member.FirstName == firstName && member.LastName == lastName)
            );
        }

        public void RemoveAllMembers()
        {
            members.Clear();
            memberCount = 0;
        }

        public override string ToString()
        {
            var builder = new StringBuilder($"Zespół \"{Name}\"\n");
            builder.AppendLine(manager.ToString());
            builder.AppendLine();
            foreach(var member in members)
                builder.AppendLine(member.ToString());
            return builder.ToString();
        }
    }
}
