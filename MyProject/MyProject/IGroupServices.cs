using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    interface IGroupServices
    {
        public List<Group> Groups {get;}

        public string CreateGroup(TypeGroup typeGroup);
        public void EditGroup(string group, string newgroup);
        public void AllGroups();
        public void CreateStudent();
        public void GroupStudents();
        public void AllStudents();

    }
}
