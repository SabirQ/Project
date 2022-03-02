using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    class Operations : IGroupServices
    {
        private List<Group> _groups = new List<Group>();
        public List<Group> Groups => _groups;

        public void AllGroups()
        {
            if (_groups.Count==0)
            {
                Console.WriteLine("thereisnogroup");
                return;
            }
            foreach (Group group in _groups)
            {
                Console.WriteLine(group);
            }
        }

        public void AllStudents()
        {
            throw new NotImplementedException();
        }

        public string CreateGroup(TypeGroup typeGroup)
        {
            Group group = new Group(typeGroup);
            _groups.Add(group);
            return group.GroupNo;
        }

        public void CreateStudent()
        {
            throw new NotImplementedException();
        }

        public void EditGroup(string no,string newno)
        {
            Group group = FindGroup(no);
            int counter = 0;
            foreach (Group item in _groups)
            {                
                if (item.GroupNo.ToLower().Trim() == newno.ToLower().Trim())
                {
                    counter++;
                }
            }
            if (group==null)
            {
                Console.WriteLine("please choose correct");
                return;
            }
            if (counter>0)
            {
                Console.WriteLine("this name already exist");
            }
            group.GroupNo = newno.ToUpper();
        }

        public void GroupStudents()
        {
            throw new NotImplementedException();
        }
        public Group FindGroup(string no)
        {
            foreach (Group group in _groups)
            {
                if (group.GroupNo.ToLower().Trim() == no.ToLower().Trim())
                {
                    return group;
                }
                
            }
            return null;
        }
    }
}
