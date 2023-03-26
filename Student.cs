using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentHW
{
    internal class Student
    {
        private string m_firstName;
        private string m_lastName;
        private string m_surName;
        private string m_phoneNumber;

        DateTime m_birthDate;
        Address m_address;
        
        List<int> m_subjectReports = new List<int>();
        List<int> m_homeWork = new List<int>();
        List<int> m_exams = new List<int>();

        public Student(string firstName, string lastName, string surName) : this(firstName, lastName, surName, new Address(), new DateTime()) 
        {

        }
        public Student(string firstName, string lastName, string surName, Address address, DateTime birthDate) : this(firstName, lastName, surName, address, birthDate, "")
        {

        }
        public Student(string firstName, string lastName, string surName, Address address, DateTime birthDate, string phoneNumber) 
        {
            m_firstName = firstName;
            m_lastName = lastName;
            m_surName = surName;
            m_address = address;
            m_birthDate = birthDate;
            m_phoneNumber = phoneNumber;
            for (int d = 0; d < 12; d++)
            {
                SetSubjectReports(GetRandomNumber(12));
                SetHomeWork(GetRandomNumber(12));
                SetExams(GetRandomNumber(12));
            }
            
        }

        public string GetFirstName() { return m_firstName; }
        public string GetLastName() { return m_lastName; }
        public string GetSurName() { return m_surName; }
        public Address GetAddress() { return m_address; }
        public DateTime GetBirthDate() { return m_birthDate; }
        public string GetPhoneNumber() { return m_phoneNumber; }
        public int GetExams(int id) { return m_exams[id]; }


        public void SetFirstName(string fisrtName) { m_firstName = fisrtName; }
        public void SetLastName(string lastName) { m_lastName = lastName; }
        public void SetSurName(string surName) { m_surName = surName; }
        public void SetAddress(Address address) { m_address = address; }
        public void SetBirthDate(DateTime birthDate) { m_birthDate = birthDate; }
        public void SetPhoneNumber(string phoneNumber) { m_phoneNumber = phoneNumber; }
        public void SetSubjectReports(int t) { m_subjectReports.Add(t); }
        public void SetHomeWork(int t) { m_homeWork.Add(t); }
        public void SetExams(int t) { m_exams.Add(t); }
        public void ShowInfo()
        {
            Console.WriteLine($"First Name: {m_firstName}\t\tBirth Date: {m_birthDate.ToString("MM/dd/yyyy")}\nLast Name: {m_lastName}\t\tPhoneNumber: {m_phoneNumber}\nSur Name: {m_surName}\n{m_address}");
            ShowAllScoresList();
        }
        public void ShowAllScoresList()
        {
            Console.WriteLine();
            string[] temp = new string[3]{"Subject Reports: ", "HomeWork: ", "Exams: "};
            if(m_subjectReports != null)
            {
                Console.Write(temp[0]);
                for (int i = 0; i < m_subjectReports.Count; i++)
                {
                    Console.Write($" {m_subjectReports[i]} ");
                }
                Console.WriteLine();
            }
            if (m_homeWork != null)
            {
                Console.Write(temp[1]);
                for (int i = 0; i < m_homeWork.Count; i++)
                {
                    Console.Write($" {m_homeWork[i]} ");
                }
                Console.WriteLine();
            }
            if (m_subjectReports != null)
            {
                Console.WriteLine();
                Console.Write(temp[2]);
                for (int i = 0; i < m_exams.Count; i++)
                {
                    Console.Write($" {m_exams[i]} ");
                }
            }
        }

        public int GetRandomNumber(int max)
        {
            int temp;
            Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            Thread.Sleep(1);
            temp = rand.Next(0, (int)max);
            return temp;
        }
    }

}
