using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentHW
{
    internal class Program
    {
        public delegate bool Comparer(object obj1, object obj2);
        internal static class Sorter
        {
            static public void Sort(object[] array, Comparer del)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (del(array[j], array[i]))
                        {
                            object temporary = array[i];
                            array[i] = array[j];
                            array[j] = temporary;
                        }
                    }
                }
            }
        }
        static void Main()
        {
            Address address = new Address("dsasd", "ds212323", "dsad21", "daswqwe");
            //Console.WriteLine(address);
            DateTime bd = new DateTime();

            //Student student = new Student("Serhii", "Balan", "Serhii", address, bd, "12345427654");
            //student.ShowInfo();

            //Aspirant aspirant = new Aspirant("Solid", "Balan", "Serhii", "Sehii");
            //aspirant.ShowInfo();

            //Group group = new Group("P12", "IT", 12);
            //group.AddGroupStudent(student);
            //group.AddRandomStudent(4);
            //group.ShowGroupStudent();
            //Console.WriteLine("Exit");
            //Console.WriteLine(group[0]);

            //Group group1 = new Group("E31", "Desighn", 1);
            //group1.AddGroupStudent((Student)group.MoveToGroup(0));
            //group1.ShowGroupStudent();
            //group.ExpulsionOneStudent();
            //group.ShowGroupStudent();
            //group.ExpulsionAllStudents();
            //group.ShowGroupStudent();


            //List<Person> array = new List<Person>();
            //array.Add(new Student("Serhii", "Balan", "Serhii", address, bd, "12345427654"));
            //for(int i = 0; i < 5; i++)
            //{
            //    array.Add(new Student("Serhii", "Balan", "Serhii", address, bd, "12345427654"));
            //    Console.WriteLine("\t\t\tStudent #{0}", i);
            //    //array[i].ShowInfo();
            //}
            //if(array[0].CompareTo(array[4]) > 0)
            //{
            //    Console.WriteLine("Student > Student1");
            //}
            //if (array[3].CompareTo(array[0]) > 0)
            //{
            //    Console.WriteLine("Student > Student2");
            //}
            //if (array[2].CompareTo(array[3]) > 0)
            //{
            //    Console.WriteLine("Student > Student3");
            //}
            //Console.WriteLine("Work Sort");
            //Array.Sort(array.ToArray());

            #region ArraySort
            //Student[] array1 = new Student[5];
            //array1[0] = new Student("S", "Balan", "Serhii", address, bd, "12345427654");
            //array1[1] = new Student("Aasdasdasd", "Balan", "Serhii", address, bd, "12345427654");
            //array1[2] = new Student("Uasdasdasd", "Balan", "Serhii", address, bd, "12345427654");
            //array1[3] = new Student("B", "Balan", "Serhii", address, bd, "12345427654");
            //array1[4] = new Student("a", "Balan", "Serhii", address, bd, "11111");

            //Array.Sort(array1, new Student("Serhii", "Balan", "Serhii", address, bd, "12345427654"));

            //foreach (Student student in array1)
            //{
            //    Console.WriteLine(student);
            //    Console.WriteLine("------------------------------------------------------");
            //}

            #endregion

            #region HomeWork 14.04.2023

            //Group group2 = new Group("E64", "IT", 1);
            //group2.AddRandomStudent(10);

            //foreach (Person person in group2)
            //{
            //    person.ShowInfo();
            //    Console.WriteLine("------------------------------------------------------\n");
            //}
            //Console.WriteLine("\n\n\n\nFor enumerator 2\n");

            //for(IEnumerator temp = group2.GetEnumerator(); temp.MoveNext(); )
            //{
            //    object item = temp.Current;

            //    Console.WriteLine(item);
            //}

            #endregion

            #region delegate

            Student[] arr =
            {
                new Student("1", "dasd", "asdasd", address, bd, "240250235"),
                new Student("2", "dasd", "asdasd", address, bd, "240250235"),
                new Student("3", "dasd", "asdasd", address, bd, "240250235"),
                new Student("4", "dasd", "asdasd", address, bd, "240250235"),
                new Student("5", "dasd", "asdasd", address, bd, "240250235"),
                new Student("6", "dasd", "asdasd", address, bd, "240250235"),
                new Student("7", "dasd", "asdasd", address, bd, "240250235"),
                new Student("8", "dasd", "asdasd", address, bd, "240250235"),
                new Student("9", "dasd", "asdasd", address, bd, "240250235")
            };
            //foreach (Student student in arr)
            //{
            //    Console.WriteLine(student);
            //    student.ShowAllScoresList();
            //}

            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{i+1}  -  {arr[i].GetHomeWorkScores()}");
            }

            Console.WriteLine("__________________________________________________________\n\n\n\n");
            Sorter.Sort(arr, delegate (object o1, object o2)
            {
            Person left = o1 as Person;
            Person right = o2 as Person;

            if (left == null || right == null)
            {
                throw new Exception("Вибачте, але вам би слід порівняти двох Персон, а не оце все: "
                    + o1.GetType() + " та " + o2.GetType());
            }
                return left.CompareTo(right) > 0;
            }); // сортируем по именам


            //foreach (Student student in arr)
            //{
            //    Console.WriteLine(student);
            //    student.ShowAllScoresList();
            //}
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{i + 1}  -  {arr[i].GetHomeWorkScores()}");
            }
            #endregion
        }
    }
}
