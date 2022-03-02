using System;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Operations operations = new Operations();
            operations.CreateGroup(TypeGroup.Dizayn);
            operations.CreateStudent("D-100");
            operations.GroupStudents("D-100");
            //operations.EditGroup();
            operations.AllGroups();
            
        }
    }
}
