using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
   static class Helper
    {
        public static TypeGroup ChooseType()
        {
            Console.WriteLine("Grup novunu secin:\n1. Programlashdirma\n2. Dizayn\n3. Sistem ");
            int num;
            string numStr = Console.ReadLine();
            bool result = int.TryParse(numStr, out num);
            TypeGroup type = new TypeGroup();

            if (result&&num==1||num==2||num == 3)
            {               
                switch (num)
                {
                    case 1:
                        type = TypeGroup.Programlashdirma;
                        Console.WriteLine($"{TypeGroup.Programlashdirma}-novu secildi");
                        break;
                    case 2:
                        type = TypeGroup.Dizayn;
                        Console.WriteLine($"{TypeGroup.Dizayn}-novu secildi");
                        break;
                    case 3:
                        type = TypeGroup.Sistem;
                        Console.WriteLine($"{TypeGroup.Sistem}-novu secildi");
                        break;
                    
                }
                return type;
            }
            else
            {
                do
                {
                    Console.WriteLine("Duzgun deyer teyin olunamyib yeniden cehd edin");
                    Console.WriteLine("Grup novunu secin:\n1. Programlashdirma\n2. Dizayn\n3. Sistem ");
                    numStr = Console.ReadLine();
                    result = int.TryParse(numStr, out num);
                } while (!result||num!=1 && num!=2 && num != 3);
                switch (num)
                {
                    case 1:
                        type = TypeGroup.Programlashdirma;
                        Console.WriteLine($"{TypeGroup.Programlashdirma}-novu secildi");
                        break;
                    case 2:
                        type = TypeGroup.Dizayn;
                        Console.WriteLine($"{TypeGroup.Dizayn}-novu secildi");
                        break;
                    case 3:
                        type = TypeGroup.Sistem;
                        Console.WriteLine($"{TypeGroup.Sistem}-novu secildi");

                        break;
                    
                }
                return type;

            }
        }
        public static bool IsOnlineOrNot()
        {
            Console.WriteLine("Grup onlinedir?\n1. Beli\n2. Xeyr");
            bool online = Convert.ToBoolean(null);
            int num;
            string numStr = Console.ReadLine();
            bool result = int.TryParse(numStr, out num);
            if (result&&num==1||num==2)
            {
                switch (num)
                { case 1:online = true;
                        break;
                    case 2:
                        online = false;
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer qeyd edilmeyib");
                        break;
                }
            }
            else
            {
                do
                {
                    Console.WriteLine("Duzgun deyer qeyd edin");
                    Console.WriteLine("Grup onlinedir?\n1. Beli\n2. Xeyr");
                    numStr = Console.ReadLine();
                    result = int.TryParse(numStr, out num);


                } while (!result||num!=1&&num!=2);
                
                switch (num)
                {
                   case 1:
                   online = true;
                   break;
                   case 2:
                   online = false;
                   break;                       
                }                
            }
            return online;
        }
        public static bool Guarranteed()
        {
            Console.WriteLine("Telebe zemanetli tehsile haqq qazanib?\n1. Beli\n2. Xeyr");
            bool online = false;
            int num;
            string numStr = Console.ReadLine();
            bool result = int.TryParse(numStr, out num);
            if (result&&num==1||num==2)
            {
                switch (num)
                {
                    case 1:
                        online = true;
                        break;
                    case 2:
                        online = false;
                        break;                    
                }
            }
            else
            {
                do
                {
                    Console.WriteLine("Duzgun deyer qeyd edin");
                    Console.WriteLine("Telebe zemanetli tehsile haqq qazanib?\n1. Beli\n2. Xeyr");
                    numStr = Console.ReadLine();
                    result = int.TryParse(numStr, out num);


                } while (!result||num!=1&&num!=2);
                
                switch (num)
                {
                   case 1:
                      online = true;
                          break;
                    case 2:
                      online = false;
                          break;                        
                }
                
            }
            return online;
        }
    }
}
