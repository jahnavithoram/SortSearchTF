using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SortSearchTFile
{
    
   public class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            

            
           
            {
                string strdata = File.ReadAllText(@"C:\Users\thoram\Desktop\stuDetails.txt");
                string[] rowdata = strdata.Split("\r\n\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                List<Student> stulist = new List<Student>();
                foreach (string sturecord in rowdata)
                {
                    Student stuobj = new Student(); 
                    string[] splitdata = sturecord.Split(',');
                    stuobj.Name = splitdata[0];
                    stuobj.Class = splitdata[1];
                 //   Console.WriteLine(stuobj.Class);
                    stulist.Add(stuobj);
                }
                //You will have the sorted data here
                int flag = 0;
                var sortedlist = stulist.OrderBy(s => s.Name);
              //  Console.WriteLine(sortedlist.ToString());
                TextWriter twriter = new StreamWriter(@"C:\Users\thoram\Desktop\stuDetails.txt");
                Console.WriteLine("Enter Name:");
                string NAME_search = Console.ReadLine();
                foreach (var kk in sortedlist)
                {
                    if (flag != 1)
                    {
                      
                        if (kk.Name.ToString()== NAME_search)
                        {
                            Console.WriteLine(string.Format("{0},{1}\n", kk.Name, kk.Class));
                            flag = 1;
                        }
                    }
                    twriter.Write(string.Format("{0},{1}\n", kk.Name, kk.Class));
                }
                twriter.Close();

                Console.WriteLine("THE DATA IS NOW SORTED");
            }
        }
    }
}
