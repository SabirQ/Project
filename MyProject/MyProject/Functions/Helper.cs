using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
   static class Helper
    {
        public static Category ChooseCategory()
        {
            Console.WriteLine("Grup novunu secin:\n1. Programlashdirma\n2. Dizayn\n3. Sistem Administratorlugu ");
            int num;
            string numStr = Console.ReadLine();
            bool result = int.TryParse(numStr, out num);
            Category type = new Category();

            if (result&&num==1||num==2||num == 3)
            {               
                switch (num)
                {
                    case 1:
                        type = Category.Programlashdirma;
                        Console.WriteLine($"Programlashdirma-novu secildi");
                        break;
                    case 2:
                        type = Category.Dizayn;
                        Console.WriteLine($"Dizayn-novu secildi");
                        break;
                    case 3:
                        type = Category.Sistem;
                        Console.WriteLine($"Sistem Administratorlugu-novu secildi");
                        break;
                    
                }
                return type;
            }
            else
            {
                do
                {
                    Console.WriteLine("Duzgun deyer teyin olunamyib yeniden cehd edin");
                    Console.WriteLine("Grup novunu secin:\n1. Programlashdirma\n2. Dizayn\n3. Sistem Administratorlugu ");
                    numStr = Console.ReadLine();
                    result = int.TryParse(numStr, out num);
                } while (!result||num!=1 && num!=2 && num != 3);
                switch (num)
                {
                    case 1:
                        type = Category.Programlashdirma;
                        Console.WriteLine($"Programlashdirma-novu secildi");
                        break;
                    case 2:
                        type = Category.Dizayn;
                        Console.WriteLine($"Dizayn-novu secildi");
                        break;
                    case 3:
                        type = Category.Sistem;
                        Console.WriteLine($"Sistem Administratorlugu-novu secildi");
                        break;
                    
                }
                return type;

            }
        }
        public static int IsOnlineOrNot()
        {
            Console.WriteLine("Grup onlinedir?\n1. Beli\n2. Xeyr\n\n\n0. Esas menu");

            int num;
            string numStr = Console.ReadLine();
            bool result = int.TryParse(numStr, out num);

            if (!result||num != 0 && num != 1 && num != 2)
            {
                do
                {
                    Console.WriteLine("Duzgun deyer qeyd edin");
                    Console.WriteLine("Grup onlinedir?\n1. Beli\n2. Xeyr\n\n\n0. Esas menu");
                    numStr = Console.ReadLine();
                    result = int.TryParse(numStr, out num);


                } while (!result || num != 0 && num != 1 && num != 2);
            }
            return num;
        }
        public static int ChooseType()
        {
            Console.WriteLine("Telebe zemanetli tehsile haqq qazanib?\n1. Beli\n2. Xeyr\n\n\n0. Esas menu");
            
            int num;
            string numStr = Console.ReadLine();
            bool result = int.TryParse(numStr, out num);
            if (!result || num != 0 && num != 1 && num != 2)
            {
                do
                {
                    Console.WriteLine("Duzgun deyer qeyd edin");
                    Console.WriteLine("Telebe zemanetli tehsile haqq qazanib?\n1. Beli\n2. Xeyr\n\n\n0. Esas menu");
                    numStr = Console.ReadLine();
                    result = int.TryParse(numStr, out num);


                } while (!result || num != 0 && num != 1 && num != 2);
            }          
            return num;
        }
    }
}
