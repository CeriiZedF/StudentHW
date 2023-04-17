using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentHW
{
    internal class Group : IEnumerable
    {
        private string m_nameGroup { get; set; }
        private string m_specialGroup { get; set; }
        private int m_numberGroup { get; set; }
        public List<Person> m_students = new List<Person>();
        public Person this[int index] => m_students[index];
        public Group(string name, string spec, int n)
        {          
            m_nameGroup = name;
            m_specialGroup = spec;
            m_numberGroup = n;
            Console.WriteLine("Created Group");
        }
        public Group(List<Person> arr)
        {
            m_students = arr;
        }
        public void AddGroupStudent(Student st)
        {
            try
            {
                if (st == null)
                {
                    throw new Exception("Переданный студент не имеет адреса");
                }
                m_students.Add(st);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error {e.Message}");
            }
        }
        public void AddRandomStudent(int size)
        {
            for(int i = 0; i < size; i++)
            {
                Address address = new Address(GetRandomWords(6), GetRandomWords(10), GetRandomWords(12), GetRandomWords(14));
                m_students.Add(new Student(GetRandomWords(8), GetRandomWords(9), GetRandomWords(5), address, DateTime.Now));
            }
        }
        public Person MoveToGroup(int m)
        {
            try
            {
                if (m < 0 || m > m_students.Count)
                {
                    throw new Exception("Индекс выходит за диапазон");
                }
                Person temp = m_students[m];
                m_students.Remove(m_students[m]);
                return temp;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error {e.Message}");
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
                    Console.WriteLine("\n_____________________Expulsion____________________");
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
                Console.WriteLine("\n_____________________Expulsion____________________");
                m_students.RemoveAt(id);
            }
            
        }
        public void ShowGroupStudent()
        {
            try
            {
                int temp = 0;
                if (m_students.Count == 0)
                {
                    throw new Exception("Лист студентов пуст");
                }

                ConsoleKey pressed;
                do
                {
                    Console.WriteLine($"Name Group: {m_nameGroup}\t\tSpec: {m_specialGroup}\nNumber Group: {m_numberGroup}");
                    Console.WriteLine("\t\t\tStudent #{0}", temp + 1);
                    Console.WriteLine("Count {0}", m_students.Count);
                    m_students[temp].ShowInfo();
                    pressed = Console.ReadKey(true).Key;
                    if (pressed == ConsoleKey.D && temp + 1 < m_students.Count) //Переход по массиву студентов(вправо) -> D
                    {
                        temp++;
                    }
                    if (pressed == ConsoleKey.A && temp != 0) //Переход по массиву студентов(влево) -> A
                    {
                        temp--;
                    }
                    if (pressed == ConsoleKey.X) //Изменить показаного студента(изменение) -> X
                    {
                        Console.WriteLine("Redaction: \n1)Name Group\n2)Spec Group\n3)Number Group\n4)Change Student");
                        int input = Convert.ToInt32(Console.ReadLine());
                        input--;
                        Console.WriteLine("Input Data");
                        switch (input)
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
                                    m_students[temp].SetAllInfoStudent();
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
                } while (pressed != ConsoleKey.W); //Выход -> W
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error {e.Message}");
            }
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

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumarator(m_students);
        }
    }
}
