using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentHW
{
    internal class Group
    {
        private string m_nameGroup;
        private string m_specialGroup;
        private int m_numberGroup;
        private List<Student> m_students = new List<Student>();

        public Group(string name, string spec, int n)
        {          
            m_nameGroup = name;
            m_specialGroup = spec;
            m_numberGroup = n;
            Console.WriteLine("Created Group");
        }
        public Group(List<Student> arr)
        {
            m_students = arr;
        }
        public void AddGroupStudent(Student st)
        {
            if(st == null)
            {
                Console.WriteLine("NULL");
            }
            m_students.Add(st);
        }
        public void AddRandomStudent(int size)
        {
            for(int i = 0; i < size; i++)
            {
                Address address = new Address(GetRandomWords(6), GetRandomWords(10), GetRandomWords(12), GetRandomWords(14));
                m_students.Add(new Student(GetRandomWords(8), GetRandomWords(9), GetRandomWords(5), address, DateTime.Now));
            }
        }
        public Student MoveToGroup(int m)
        {
            if(m > 0 || m < m_students.Count)
            {
                Student temp = m_students[m];
                m_students.Remove(m_students[m]);
                return temp;
            }
            return null;
        }
        public void ExpulsionAllStudents()
        {
            int sum = 0;
            for(int j = 0; j < m_students.Count; j++)
            {
                sum = 0;
                for(int i = 0; i < 12; i++)
                {
                    sum += m_students[j].GetExams(i); 
                }
                sum = sum / 12;
                Console.WriteLine($"Sum: {sum} - Student #{j}");
                if(sum < 7)
                {
                    m_students[j].ShowInfo();
                    Console.WriteLine("_____________________Expulsion____________________");
                    m_students.RemoveAt(j);
                }
            }
        }
        public void ExpulsionOneStudent()
        {
            int sum = 0;
            int temp = 12;
            int id = -1;
            for (int j = 0; j < m_students.Count; j++)
            {
                sum = 0;
                for (int i = 0; i < 12; i++)
                {
                    sum += m_students[j].GetExams(i);
                }
                sum = sum / 12;
                if (temp > sum)
                {
                    id = j;
                    temp = sum;
                }
            }
            if(id != -1)
            {
                m_students[id].ShowInfo();
                Console.WriteLine("_____________________Expulsion____________________");
                m_students.RemoveAt(id);
            }
            
        }
        public void ShowGroupStudent()
        {
            if(m_students[0] == null)
            {
                Console.WriteLine("None arr Student");
                return;
            }
            int temp = 0;
            ConsoleKey pressed;
            do
            {
                Console.WriteLine($"Name Group: {m_nameGroup}\t\tSpec: {m_specialGroup}\nNumber Group: {m_numberGroup}");
                Console.WriteLine("\t\t\tStudent #{0}", temp + 1);
                m_students[temp].ShowInfo();
                pressed = Console.ReadKey(true).Key;
                if (pressed == ConsoleKey.D && temp + 1 < m_students.Count)
                {
                    temp++;
                }
                if(pressed == ConsoleKey.A && temp != 0)
                {
                    temp--;
                }
                if(pressed == ConsoleKey.X)
                {
                    Console.WriteLine("Redaction: \n1)Name Group\n2)Spec Group\n3)Number Group\n4)First Name\n5)Last Name\n6)Sur Name\n7)Birth Date\n8)Phone Number");
                    int input = Convert.ToInt32(Console.ReadLine());
                    input--;
                    switch(input)
                    {
                        case 0:
                            {
                                m_nameGroup = Convert.ToString(Console.ReadLine());
                                break;
                            }
                        case 1:
                            {
                                m_specialGroup = Convert.ToString(Console.ReadLine());
                                break;
                            }
                        case 2:
                            {
                                m_numberGroup = Convert.ToInt32(Console.ReadLine());
                                break;
                            }
                        case 3:
                            {
                                m_students[temp].SetFirstName(Console.ReadLine());
                                break;
                            }
                        case 4:
                            {
                                m_students[temp].SetLastName(Console.ReadLine());
                                break;
                            }
                        case 5:
                            {
                                m_students[temp].SetSurName(Console.ReadLine());
                                break;
                            }
                        case 6:
                            {
                                m_students[temp].SetBirthDate(Convert.ToDateTime(Console.ReadLine()));
                                break;
                            }
                        case 7:
                            {
                                m_students[temp].SetPhoneNumber(Convert.ToString(Console.ReadLine()));
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Exit or Range error");
                                break;
                            }
                    }
                }
                Console.Clear();
            } while (pressed != ConsoleKey.W);
            
        }
        public string GetRandomWords(uint length)
        {
            string temp = "";
            var arr = new StringBuilder("qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM");
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                Thread.Sleep(1);
                temp = temp + arr[rand.Next(0, arr.Length - i)];
            }

            return temp;
        }
        
    }
}
