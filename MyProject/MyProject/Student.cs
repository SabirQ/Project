﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    class Student
    {
        public string FullName;
        public string StudentGroupNo;
        public bool guarrantee;


        public string GuarranteeValue()
        {
            string result = "";
            if (guarrantee)
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
