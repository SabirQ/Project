using System;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {


            Operations operations = new Operations();
            Console.WriteLine("Console Application\n");
            int selection;
            do
            {
                Console.WriteLine($"1. Yeni qrup yarat\n2. Qruplarin siyahisini goster\n3. Qrup uzerinde duzelish etmek\n4. Qrupdaki telebelerin siyahisini goster\n5. Butun telebelerin siyahisini goster\n6. Telebe yarat");
                Console.WriteLine("\n\n0. Cixish");
                string strSelection = Console.ReadLine();
                bool result = int.TryParse(strSelection, out selection);
                if (result)
                {
                    switch (selection)
                    {  case 1:
                            operations.CreateGroup();                       
                            break;
                        case 2:
                            operations.AllGroups();                    
                            break;
                        case 3:
                            operations.EditGroup();
                            break;
                        case 4:
                            Console.WriteLine("Telebe siyahisini, ekrana cixartmaq istediyiniz Grupun Nomresini qeyd edin:");
                            operations.GroupStudents(Console.ReadLine());
                            break;
                        case 5:
                            operations.AllStudents();
                            break;
                        case 6:
                            
                            operations.CreateStudent();
                            break;
                        default:
                            break;
                    }
                }

            } while (selection!=0);
            
        }
    }
}
