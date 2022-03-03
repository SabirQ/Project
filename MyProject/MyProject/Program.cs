using System;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {


            Operations operations = new Operations();
            //operations.CreateGroup(TypeGroup.Dizayn);
            //operations.CreateStudent("D-100");
            //operations.GroupStudents("D-100");
            //operations.EditGroup();
            //operations.AllGroups();
            Console.WriteLine("Console Application\n");
            int selection;
            do
            {
                Console.WriteLine($"1. Yeni qrup yarat\n2. Qrupların siyahısını göster\n3. Qrup üzerinde düzeliş etmek\n4. Qrupdakı telebelerin siyahısını göster\n5. Bütün telebelerin siyahısını göster\n6. Telebe yarat");
                Console.WriteLine("\n\n0. Cixish");
                string strSelection = Console.ReadLine();
                bool result = int.TryParse(strSelection, out selection);
                if (result)
                {
                    switch (selection)
                    {  case 1:
                            operations.CreateGroup(Helper.ChooseType());                            
                            break;
                        case 2:
                            operations.AllGroups();
                            break;
                        case 3:
                            operations.EditGroup();
                            break;
                        case 4:
                            operations.GroupStudents(Console.ReadLine());
                            break;
                        case 5:
                            operations.AllStudents();
                            break;
                        case 6:
                            Console.WriteLine("Hansi grup ucun nezerde tutuldugunu qeyd edin ");
                            operations.CreateStudent(Console.ReadLine());
                            break;
                        default:
                            break;
                    }
                }

            } while (selection!=0);
            
        }
    }
}
