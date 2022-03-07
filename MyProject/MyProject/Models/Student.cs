using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    partial class Student                   //Fields
    {
        private string _fullName;
        private string _studentGroupNo;
        private bool _type;
        private string _isonline;
    }
    partial class Student                   //Properties 
    {
        public string FullName
        { 
            get 
            {
                return _fullName;
            } 
            set 
            {
                _fullName = value;
            }
        }
        public string StudentGroupNo
        {
            get
            {
                return _studentGroupNo;
            }
            set
            {
                 _studentGroupNo= value;
            }
        }
        public bool Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public string OnlineOrNot
        {
            get
            {
                return _isonline;
            }
            set
            {
                _isonline = value;
            }
        }
    }
    partial class Student                   //Constructor
    {
        public Student(string fullname, Group group, bool type)
        {
            FullName = fullname;
            StudentGroupNo = group.GroupNo;
            Type = type;
            if (group.isOnline)
            {
                OnlineOrNot = "Beli";
            }
            else
            {
                OnlineOrNot = "Xeyr";
            }
            
        }
    }
    partial class Student                  //Methods
    { 
        public string GuarranteeValue()
        {
            string result = "";
            if (Type)
            {
                result = "Beli";
            }
            else
            {
                result = "Xeyr";
            }
            return result;
        }
        public override string ToString()
        {
            return $"Tam adi:{FullName} Grup:{StudentGroupNo} Zemanetli Tehsil:{GuarranteeValue()} Online:{OnlineOrNot}";
        }
       
    }
    
}
