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
        public Student[] students = new Student[20];
        public Group(TypeGroup type)
        {
            int tip;
            string tipstr = Console.ReadLine();
            bool result = int.TryParse(tipstr, out tip);
            if (result)
            {
                switch (type)
                {
                    case TypeGroup.Marketing:
                        GroupNo = $"M-{Count}";
                        break;
                    case TypeGroup.Programlashdirma:
                        GroupNo = $"P-{Count}";
                        break;
                    case TypeGroup.Dizayn:
                        GroupNo = $"D-{Count}";
                        break;
                    case TypeGroup.Sistem:
                        GroupNo = $"S-{Count}";
                        break;
                    default:
                        break;
                }
            } 
            Count++;
            Type = type;
        }
    }
}
