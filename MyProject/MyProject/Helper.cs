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

            if (result)
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
                    default:
                        Console.WriteLine("Bele bir Grup Novu movcud deyil. Esas menuye kecid edildi");
                        break;
                }
                return type;
            }
            else
            {
                do
                {
                    Console.WriteLine("Duzgun deyer teyin olunamyib yeniden cehd edin edin");
                    Console.WriteLine("Grup novunu secin:\n1. Programlashdirma\n2. Dizayn\n3. Sistem ");
                    numStr = Console.ReadLine();
                    result = int.TryParse(numStr, out num);
                } while (!result);
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
                    default:
                        Console.WriteLine("Bele bir Grup Novu movcud deyil. Esas menuye kecid edildi");
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
            if (result)
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
                    Console.WriteLine("Grup onlinedir?\n1. Beli\n 2. Xeyr");
                    numStr = Console.ReadLine();
                    result = int.TryParse(numStr, out num);


                } while (!result);
                if (result)
                {
                    switch (num)
                    {
                        case 1:
                            online = true;
                            break;
                        case 2:
                            online = false;
                            break;
                        default:
                            Console.WriteLine("Bele bir deyer movcud deyil. Esas menuya kecid edildi");
                            break;
                    }
                }
            }
            return online;
        }
        public static bool Guarranteed()
        {
            Console.WriteLine("Telebe zemanetli tehsil qazanib?\n1. Beli\n2. Xeyr");
            bool online = false;
            int num;
            string numStr = Console.ReadLine();
            bool result = int.TryParse(numStr, out num);
            if (result)
            {
                switch (num)
                {
                    case 1:
                        online = true;
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
                    Console.WriteLine("Telebe zemanetli tehsil qazanib&\n1. Beli\n 2. Xeyr");
                    numStr = Console.ReadLine();
                    result = int.TryParse(numStr, out num);


                } while (!result);
                if (result)
                {
                    switch (num)
                    {
                        case 1:
                            online = true;
                            break;
                        case 2:
                            online = false;
                            break;
                        default:
                            Console.WriteLine("Bele bir deyer movcud deyil. Esas menuya kecid edildi");
                            break;
                    }
                }
            }
            return online;
        }


    }
}
