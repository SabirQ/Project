using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    partial class Group                                         //Fields
    {
        private string _groupNo;
        private static int _count = 100;
        private TypeGroup _type;
        private List<Student> _students = new List<Student>();
        private bool _isOnline;
        private int _limit;
    }
    partial class Group                                        //Properties
    {
        public string GroupNo
        {
            get
            {
                return _groupNo;
            }
            set
            {
                _groupNo = value;
            }
        }
        public static int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }
        public TypeGroup Type
        {
            get
            {
                return _type;
            }
        }
        public List<Student> Students
        {
            get
            {
                return _students;
            }
        }
        public bool isOnline
        {
            get
            {
                return _isOnline;
            }
        }
        public int Limit
        {
            get
            {
                return _limit;
            }
        }
    }
    partial class Group                                        //Constructor
    {
        public Group(TypeGroup type, bool online)
        {
            switch (type)
            {

                case TypeGroup.Programlashdirma:
                    _groupNo = $"P{Count}";
                    break;
                case TypeGroup.Dizayn:
                    _groupNo = $"D{Count}";
                    break;
                case TypeGroup.Sistem:
                    _groupNo = $"S{Count}";
                    break;
                default:
                    break;
            }

            _isOnline = online;
            _type = type;
            _count++;
            if (isOnline)
            {
                _limit = 15;
            }
            else
            {
                _limit = 10;
            }
        }
    }
    partial class Group                                        //Methods
    {

        public override string ToString()
        {
            return $"Grup Nomresi:{GroupNo} Novu:{Type} Telebeler:{_students.Count} Online:{OnlineValue()}";
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
