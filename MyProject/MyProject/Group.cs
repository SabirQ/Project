using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    class Group
    {
        public string GroupNo;
        public static int Count = 100;
        public TypeGroup Type;
        public List<Student> students = new List<Student>();
        public bool isOnline;
        public int Limit;
        public Group(TypeGroup type)
        {
            //int tip;
            //string tipstr = Console.ReadLine();
            //bool result = int.TryParse(tipstr, out tip);

            
            switch (type)
                {

                    case TypeGroup.Programlashdirma:
                        GroupNo = $"P{Count}";
                        break;
                    case TypeGroup.Dizayn:
                        GroupNo = $"D{Count}";
                        break;
                    case TypeGroup.Sistem:
                        GroupNo = $"S{Count}";
                        break;
                    default:
                        break;
                }
            Type = type;
            Count++;
            
            
        }
        public override string ToString()
        {
            return $"Grup Nomresi:{GroupNo} Novu:{Type} Shagirdler:{students.Count} Online:{OnlineValue()}";
        }
        public string OnlineValue()
        {
            string result = "";
            if (isOnline)
            {
                result = "beli";
            }
            else
            {
                result = "xeyr";
            }
            return result;
        }

    }
}
