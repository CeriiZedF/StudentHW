using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHW
{
    internal class Person : IComparable
    {
        protected string m_firstName { get; set; }
        protected string m_lastName { get; set; }
        protected string m_surName { get; set; }
        protected string m_phoneNumber { get; set; }
        protected DateTime m_birthDate { get; set; }
        protected Address m_address { get; set; }

        public List<int> m_subjectReports = new List<int>();
        public List<int> m_homeWork = new List<int>();
        public List<int> m_exams = new List<int>();
        virtual public void ShowInfo()
        {
            Console.WriteLine($"First Name: {m_firstName}\t\tBirth Date: {m_birthDate.ToString("MM/dd/yyyy")}\nLast Name: {m_lastName}\t\tPhoneNumber: {m_phoneNumber}\nSur Name: {m_surName}\n{m_address}");
        }

        virtual public int GetExams(int id) { return m_exams[id]; }

        virtual public void SetExams(int t) { m_exams.Add(t); }
        virtual public void SetAllInfoStudent()
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

        virtual public int CompareTo(object obj)
        {
            if(obj is Person person)
            {
                int sum = 0, sum1 = 0;
                for (int i = 0; i < m_homeWork.Count; i++)
                {
                    sum += m_homeWork[i];
                    sum1 += person.m_homeWork[i];
                    //Console.WriteLine("Value1 - {0} : Value2 - {1}", m_exams[i], person.m_exams[i]);
                }
                sum = sum / m_homeWork.Count;
                sum1 = sum1 / m_homeWork.Count;
                Console.WriteLine("1 - {0} : 2 - {1}", sum, sum1);

                if (sum > sum1) { return 1; }
                else if (sum < sum1) { return -1; }
                else { return 0; }            }
            else
            {
                throw new ArgumentException("Некорректное значение параметра");
            }




        }
    }
}
