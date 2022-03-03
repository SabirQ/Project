using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    interface IGroupServices
    {
        public List<Group> Groups {get;}

        public void CreateGroup();
        public void EditGroup();
        public void AllGroups();
        public void CreateStudent();
        public void GroupStudents(string no);
        public void AllStudents();

    }
}
