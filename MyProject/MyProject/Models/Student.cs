using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    partial class Student                   //Fields
    {
        private string _fullName;
        private string _studentGroupNo;
        private bool _guarrantee;
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
        public bool Guarrantee
        {
            get
            {
                return _guarrantee;
            }
            set
            {
                _guarrantee = value;
            }
        }

    }
    partial class Student                   //Constructor
    {
        public Student(string fullname, string groupno, bool guarrantee)
        {
            FullName = fullname;
            StudentGroupNo = groupno;
            Guarrantee = guarrantee;
        }
    }
    partial class Student                  //Methods
    { 
        public string GuarranteeValue()
        {
            string result = "";
            if (Guarrantee)
            {
                result = "beli";
            }
            else
            {
                result = "xeyr";
            }
            return result;
        }
        public override string ToString()
        {
            return $"Tam adi:{FullName} Grup:{StudentGroupNo} Zemanetli Tehsil:{GuarranteeValue()}";
        }

    }
    
}
