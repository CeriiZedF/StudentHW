using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentHW
{
    internal class Student : Person, IComparer<Student>
    {
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
                try
                {
                    m_subjectReports.Add(GetRandomNumber(12));
                    m_homeWork.Add(GetRandomNumber(12));
                    m_exams.Add(GetRandomNumber(12));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e.Message}");
                }
            }
            
        }

        //public string GetFirstName() { return m_firstName; }
        //public string GetLastName() { return m_lastName; }
        //public string GetSurName() { return m_surName; }
        //public Address GetAddress() { return m_address; }
        //public DateTime GetBirthDate() { return m_birthDate; }
        //public string GetPhoneNumber() { return m_phoneNumber; }
        public override int GetExams(int id) { return m_exams[id]; }


        //public void SetFirstName(string fisrtName) { m_firstName = fisrtName; }
        //public void SetLastName(string lastName) { m_lastName = lastName; }
        //public void SetSurName(string surName) { m_surName = surName; }
        //public void SetAddress(Address address) { m_address = address; }
        //public void SetBirthDate(DateTime birthDate) { m_birthDate = birthDate; }
        //public void SetPhoneNumber(string phoneNumber) { m_phoneNumber = phoneNumber; }
        //public void SetSubjectReports(int t) { m_subjectReports.Add(t); }
        //public void SetHomeWork(int t) { m_homeWork.Add(t); }
        public override void SetExams(int t) { m_exams.Add(t); }
        public override void ShowInfo()
        {
            Console.WriteLine($"First Name: {m_firstName}\t\tBirth Date: {m_birthDate.ToString("MM/dd/yyyy")}\nLast Name: {m_lastName}\t\tPhoneNumber: {m_phoneNumber}\nSur Name: {m_surName}\n{m_address}");
            ShowAllScoresList();
        }
        public override string ToString()
        {
            return $"First Name: {m_firstName}\t\tBirth Date: {m_birthDate.ToString("MM / dd / yyyy")}\nLast Name: {m_lastName}\t\tPhoneNumber: {m_phoneNumber}\nSur Name: {m_surName}\n{m_address}";
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
            }
            if (m_subjectReports != null)
            {
                Console.WriteLine();
                Console.Write(temp[2]);
                for (int i = 0; i < m_exams.Count; i++)
                {
                    Console.Write($" {m_exams[i]} ");
                }
                Console.WriteLine();
            }
        }

        public int GetRandomNumber(int max)
        {
            try
            {
                if(max > 30 || max <= 0)
                {
                    throw new Exception("Неверный диапазон количества студентов");
                }
                int temp;
                Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                Thread.Sleep(2);
                temp = rand.Next(6, (int)max);
                return temp;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error {e.Message}");
            }
            return 0;
        }
        public override void SetAllInfoStudent()
        {
            Console.WriteLine("Redaction: \n1)First Name\n2)Last Name\n3)Sur Name\n4)Birth Date\n5)Phone Number");
            int input = Convert.ToInt32(Console.ReadLine());
            input--;
            Console.WriteLine("Input Data");
            switch (input)
            {
                case 0:
                    {
                        m_firstName = Convert.ToString(Console.ReadLine());
                        break;
                    }
                case 1:
                    {
                        m_lastName = Convert.ToString(Console.ReadLine());
                        break;
                    }
                case 2:
                    {
                        m_surName = Convert.ToString(Console.ReadLine());
                        break;
                    }
                case 3:
                    {
                        m_birthDate = Convert.ToDateTime(Console.ReadLine());
                        break;
                    }
                case 4:
                    {
                        m_phoneNumber = Convert.ToString(Console.ReadLine());
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Exit or Range error");
                        break;
                    }
            }
        }

        public int Compare(Student x, Student y)
        {
            if(x == null || y == null)
            {
                return 0;
            }
            return string.CompareOrdinal(x.m_firstName.ToLower(), y.m_firstName.ToLower());
            

        }
    }

}
