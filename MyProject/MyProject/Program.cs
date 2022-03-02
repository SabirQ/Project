using System;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group = new Group(TypeGroup.Dizayn); 
            Console.WriteLine(group.GroupNo); 
        }
    }
}
