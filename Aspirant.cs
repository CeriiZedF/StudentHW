using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHW
{
    internal class Aspirant : Student
    {
        private string m_dissertationTopic;
        public Aspirant(string disT, string firstName, string lastName, string surName) : base(firstName, lastName, surName, new Address(), new DateTime())
        {
            m_dissertationTopic = disT;
        }
        public Aspirant(string disT, string firstName, string lastName, string surName, Address address, DateTime birthDate) : base(firstName, lastName, surName, address, birthDate, "")
        {
            m_dissertationTopic = disT;

        }
        public Aspirant(string disT, string firstName, string lastName, string surName, Address address, DateTime birthDate, string phoneNumber) : base(firstName, lastName, surName, address, birthDate, phoneNumber)
        {
            m_dissertationTopic = disT;

        }
        public override int GetExams(int id) { return m_exams[id]; }
        public override void SetExams(int t) { m_exams.Add(t); }
        public override void ShowInfo()
        {
            Console.WriteLine($"Dissertation Topic: {m_dissertationTopic}\tFirst Name: {m_firstName}\t\tBirth Date: {m_birthDate.ToString("MM/dd/yyyy")}\nLast Name: {m_lastName}\t\tPhoneNumber: {m_phoneNumber}\nSur Name: {m_surName}\n{m_address}");
            ShowAllScoresList();
        }
        public override string ToString()
        {
            return $"Dissertation Topic: {m_dissertationTopic}\tFirst Name: {m_firstName}\t\tBirth Date: {m_birthDate.ToString("MM / dd / yyyy")}\nLast Name: {m_lastName}\t\tPhoneNumber: {m_phoneNumber}\nSur Name: {m_surName}\n{m_address}";
        }
    }
}
