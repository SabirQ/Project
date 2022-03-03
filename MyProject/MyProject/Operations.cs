using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    partial class Operations : IGroupServices                                              //MAIN  operations
    {
        private List<Group> _groups = new List<Group>();
        public List<Group> Groups => _groups;

        public void AllGroups()                                     //hazir
        {
            if (_groups.Count==0)
            {
                Console.WriteLine("Her-hansi bir grup movcud deyil");
                return;
            }
            foreach (Group group in _groups)
            {
                Console.WriteLine(group);
            }
        }

        public void AllStudents()                                 //hazir
        {
            
            foreach (Group group in _groups)
            {
                CheckStudents(group.GroupNo);
                
            }
            if (CheckNumbersOfStudents()<= 0)
            {
                Console.WriteLine("Hal-hazirda Academiyada telebe yoxdur");
            }
        }

        public void CreateGroup()                                //hazir
        {
            Group group = new Group(Helper.ChooseType(), Helper.IsOnlineOrNot());           
            _groups.Add(group);
            Console.WriteLine(group.GroupNo + $"-adli grup yaradildi");            
        }

        public void CreateStudent()                             //hazir
        {
            Console.WriteLine("Yeni telebenin hansi grup ucun nezerde tutuldugunu qeyd edin ");
            string no = Console.ReadLine();
            if (no.Length==0||no==null)
            {
                do
                {
                    Console.WriteLine("Duzgun deyer teyin edin");
                    no = Console.ReadLine();
                } while (no.Length==0 || no == null);
            }
            Group group = FindGroup(no);
            if (group == null)
            {
                Console.WriteLine("bele bir grup movcud deyil Esas menuya kecid edildi");
                return;
            }
            
            if (group.students.Count>=group.Limit)
            {
                do
                {
                    Console.WriteLine("Bu grupda bosh yer yoxdur zehmet olmasa Bashqa grup secin");
                    no = Console.ReadLine();
                    group = FindGroup(no);
                } while (group.students.Count >= group.Limit); 
            }
            Student student = new Student(DetermineFullname(),group.GroupNo, Helper.Guarranteed());
            Console.WriteLine(student+"\nTelebe yaradildi");
            group.students.Add(student);
        }

        public void EditGroup()                             //hazir
        {
            Console.WriteLine("Deyishmek istediyiniz grupun nomresini qeyd edin");
            string no = Console.ReadLine();
            Group group = FindGroup(no);
                        
            if (group==null)
            {
                do
                {
                    Console.WriteLine("Bu adda grup movcud deyil yeniden cehd edin");
                    no = Console.ReadLine();
                    group = FindGroup(no);

                } while (group==null);
                
            }
            Console.WriteLine("Grup Nomresinin bash herifi novune uygun teyin edilmishdir\nYeni grup nomresinin 3 reqemli ededini daxil edin");
            string newno = CheckNewGroupName(group);
 
            foreach (Group item in _groups)
            {
                if (item.GroupNo.ToLower().Trim() == newno.ToLower().Trim())
                {
                    newno = null;
                }
            }
            if (newno == null)
            {
                do
                {
                    Console.WriteLine("Bu nomreli grup artiq movcuddur bashqa nomre daxil edin");
                    newno = CheckNewGroupName(group);
                    foreach (Group item in _groups)
                    {
                        if (item.GroupNo.ToLower().Trim() == newno.ToLower().Trim())
                        {
                            newno = null;
                        }
                    }
                } while (newno == null);
            }
            group.GroupNo =Capitalized(newno);
            Console.WriteLine(group.GroupNo);
        }

        public void GroupStudents(string no)                    //hazir
        {                                 
            Group group = FindGroup(no);
            if (group == null)
            {
                Console.WriteLine("Qeyd elediyiniz Grup Nomresi movcud deyil");
                return;               
            }
            
            if (group.students.Count>0)
            {
                 foreach (Student student in group.students)
                 {
                        Console.WriteLine(student);
                 }                       
            }
            else
            {
               Console.WriteLine(group.GroupNo+"-adli Grupda telebe movcud deyil");
            }
            
        }
       
    }
    partial class Operations:IGroupServices                                                //ADDITIONAL operations
    {
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
        public string DetermineFullname()
        {
            Console.WriteLine("Telebenin adini qeyd edin");
            string name = Console.ReadLine();
            name = NameLength(name);

            if (!CheckLetters(name))
            {
                do
                {
                    Console.WriteLine("Telebe adi herflerden ibaret olmalidir");
                    name = Console.ReadLine();
                    name = NameLength(name);


                } while (!CheckLetters(name));
            }
           
            Console.WriteLine("Telebenin soyadini qeyd edin");
            string surname = Console.ReadLine();
            surname = NameLength(surname);
            if (!CheckLetters(surname))
            {
                do
                {
                    Console.WriteLine("Telebenin soyadi herflerden ibaret olmalidir");
                    surname = Console.ReadLine();
                    surname = NameLength(surname);


                } while (!CheckLetters(surname));
            }
            
            return Capitalized(name) + " " + Capitalized(surname);

        }
        public string Capitalized(string sentence)
        {
            StringBuilder capitalized = new StringBuilder();
            sentence = sentence.ToLower().Trim();
            capitalized.Append(Char.ToUpper(sentence[0]));
            for (int i = 1; i < sentence.Length; i++)
            {
                capitalized.Append(sentence[i]);
            }
            return Convert.ToString(capitalized);
        }
        public string NameLength(string name)
        {
            name = name.Trim();
            if (name.Length >= 3)
            {
                return name;
            }
            else
            {
                do
                {
                    Console.WriteLine("Adlarin ve soyadalarin uzunlugu en azi 3 herfden ibaret olmalidir");
                    name = Console.ReadLine();
                    name = name.Trim();
                } while (name.Length < 3);
            }
            return name;
        }
        public bool CheckLetters(string name)
        {
            bool result = true;
            name = NameLength(name);
            for (int i = 0; i < name.Length; i++)
            {
                if (!Char.IsLetter(name[i]))
                {
                    result = false;
                    return result;

                }
            }
            return result;
        }
       
        public int CheckDigits()
        {
            int num;
            string numStr = Console.ReadLine();
            bool result = int.TryParse(numStr, out num);
            if (!result||numStr.Length!=3)
            {
                do
                {
                    Console.WriteLine("Grup Nomresinin bash herfi novune uygun teyin edilmishdir.\n3 reqemli eded daxil edin");
                    numStr = Console.ReadLine();
                    result = int.TryParse(numStr, out num);
                } while (!result || numStr.Length != 3);
                
            }
            return num;
        }
        public string CheckNewGroupName(Group group)
        {
            string newno = "";
            switch (group.Type)
            {

                case TypeGroup.Programlashdirma:
                    newno = $"P{CheckDigits()}";
                    break;
                case TypeGroup.Dizayn:
                    newno = $"D{CheckDigits()}";
                    break;
                case TypeGroup.Sistem:
                    newno = $"S{CheckDigits()}";
                    break;
                default:
                    break;
            }
            return newno;
        }
        public void CheckStudents(string no)                    //hazir
        {
            Group group = FindGroup(no);
            if (group == null)
            {
                Console.WriteLine("Bele bir Grup Nomresi movcud deyil");
                return;
            }
            foreach (Student student in group.students)
            {
                
                    Console.WriteLine(student);
               
            }
        }
        public int CheckNumbersOfStudents()
        {
            int number = 0;
            foreach (Group group in _groups)
            {
                number += group.students.Count;
            }
            return number;
        }

    }
}
