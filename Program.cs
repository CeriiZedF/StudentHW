using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentHW
{
    internal class Program
    {
        static void Main()
        {
            Address address = new Address("dsasd", "ds212323", "dsad21", "daswqwe");
            //Console.WriteLine(address);
            DateTime bd = new DateTime();

            Student student = new Student("Serhii", "Balan", "Serhii", address, bd, "12345427654");
            //Student student1 = new Student("asdasd", "B1alafdn", "Ser2h34ii", address, bd, "342646546");
            //Student student2 = new Student("asd123123", "Bsadalan", "sasdwq", address, bd, "1232dsdfsdf");
            //student.ShowInfo();
            
            Group group = new Group("P12", "IT", 12);
            group.AddGroupStudent(student);
            group.AddRandomStudent(5);
            group.ShowGroupStudent();
            Console.WriteLine("Exit");
            Group group1 = new Group("E31", "Desighn", 1);
            group1.AddGroupStudent(group.MoveToGroup(0));
            group1.ShowGroupStudent();
            group.ExpulsionOneStudent();
            group.ShowGroupStudent();
            group.ExpulsionAllStudents();
            group.ShowGroupStudent();
        }
    }
}
