using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Team.People;
using Team.Utils;

namespace Team.Organization
{
    [Serializable]
    public class Team : ICloneable, IWritable
    {
        private class PeselComparator : IComparer<Member>
        {
            public int Compare(Member lhs, Member rhs)
            {
                return lhs.Pesel.CompareTo(rhs.Pesel);
            }
        };

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

        [XmlArray]
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

        public bool HasMember(Member potentialMember)
        {
            return members.Any(
                member => (member.Equals(potentialMember))
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

        public void SortByPesel()
        {
            members.Sort(new PeselComparator());
        }

        public object Clone()
        {
            var clone = new Team(Name, CurrentManager.Clone() as Manager);
            foreach(var member in members)
                clone.AddMember(member.Clone() as Member);
            return clone;
        }

        public void WriteBinary(string filename)
        {
            using(var stream = new FileStream(filename, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
            }
        }

        public void ReadBinary(string filename)
        {
            Team data = null;
            using(var stream = new FileStream(filename, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                data = (Team)formatter.Deserialize(stream);
            }
            Name = data.Name;
            CurrentManager = data.CurrentManager;
            members = data.members;
        }

        public void WriteXml(string filename)
        {
            using(var writer = new StreamWriter(filename))
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(writer, this);
            }
        }

        public void ReadXml(string filename)
        {
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
