using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    partial class Operations : IGroupServices                                              //FIELD and PROPERTY
    {
        private List<Group> _groups = new List<Group>();
        public List<Group> Groups => _groups;
    }
    partial class Operations : IGroupServices                                              //MAIN  operations
    {
        public void AllGroups()                                   
        {
            if (Groups.Count==0)
            {
                Console.WriteLine("Her-hansi bir grup movcud deyil");
                return;
            }
            foreach (Group group in Groups)
            {
                Console.WriteLine(group);
            }
        }

        public void AllStudents()                                  
        {
            
            foreach (Group group in Groups)
            {
                CheckStudents(group.GroupNo);
                
            }
            if (CheckNumbersOfStudents()<= 0) 
            {
                Console.WriteLine("Hal-hazirda Academiyada telebe yoxdur");
            }
           
        }

        public void CreateGroup()                               
        {            
            Category category = Helper.ChooseCategory();
            int intresult = Helper.IsOnlineOrNot();
            bool result = false;
            if (intresult==0)
            {
                return;
            }
            if (intresult==1)
            {
                result = true;
            }
            Group group = new Group(category, result);
            CheckCreatedGroupNO(group);
            Groups.Add(group);
            Console.WriteLine(group.GroupNo + $"-adli grup yaradildi");
        }

        public void CreateStudent()                            
        {
            Console.WriteLine("Yeni telebenin hansi grup ucun nezerde tutuldugunu qeyd edin\n\n0. Esas menu ");
            string no = Console.ReadLine().Trim();
            if (no == "0")
            {
                return;
            }
            if (no.Length==0||no==null)
            {
                do
                {
                    Console.WriteLine("Duzgun deyer teyin edin\n\n0. Esas menu");
                    no = Console.ReadLine().Trim();
                    if (no == "0")
                    {
                        return;
                    }
                } while (no.Length==0 || no == null);
            }
            Group group = FindGroup(no);
            if (group == null)
            {
                Console.WriteLine("Bele bir grup movcud deyil Esas menuya kecid edildi");
                return;
            }
            
            if (group.Students.Count>=group.Limit)
            {
                do
                {
                    Console.WriteLine("Bu grupda bosh yer yoxdur zehmet olmasa Bashqa grup secin\n\n0. Esas menu ");
                    no = Console.ReadLine();                   
                    if (no==null)
                    {
                        do
                        {
                            Console.WriteLine("Duzgun deyer teyin edin\n\n0. Esas menu");
                            no= Console.ReadLine();
                        } while (no==null);        
                    }
                    if (no == "0")
                    {
                        return;
                    }
                    group = FindGroup(no);
                    if (group == null)
                    {
                        Console.WriteLine("Bele bir grup movcud deyil Esas menuya kecid edildi");
                        return;
                    }                                        
                } while (group.Students.Count >= group.Limit); 
            }
            string fullname = DetermineFullname();
            bool result = false;
            int intresult = Helper.ChooseType();
            if (intresult == 0)
            {
                return;
            }
            if (intresult == 1)
            {
                result = true;
            }
            
            Student student = new Student(fullname,group, result);
            Console.WriteLine(student+"\nTelebe yaradildi");
            group.Students.Add(student);
        }

        public void EditGroup()                             
        {
            Console.WriteLine("Deyishmek istediyiniz grupun nomresini qeyd edin\n\n0. Esas menu");
            string no = Console.ReadLine();
            no = no.Trim();
            if (no=="0")
            {
                return;
            }
            Group group = FindGroup(no);
                        
            if (group==null)
            {
                do
                {
                    Console.WriteLine("Bu adda grup movcud deyil yeniden cehd edin\n\n0. Esas menu");
                    no = Console.ReadLine();
                    if (no == "0")
                    {
                        return;
                    }
                    group = FindGroup(no);

                } while (group==null);
                
            }
            Console.WriteLine("Grup Nomresinin bash herifi novune uygun teyin edilmishdir\nYeni grup nomresinin 3 reqemli ededini daxil edin");
            string newno = CheckNewGroupName(group);
 
            foreach (Group item in Groups)
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
                    foreach (Group item in Groups)
                    {
                        if (item.GroupNo.ToLower().Trim() == newno.ToLower().Trim())
                        {
                            newno = null;
                        }
                    }
                } while (newno == null);
            }
            group.GroupNo =Capitalized(newno);
            foreach (Student student in group.Students)
            {
                student.StudentGroupNo = group.GroupNo;
            }
            Console.WriteLine(group.GroupNo);
        }

        public void GroupStudents(string no)                    
        {                                 
            Group group = FindGroup(no);
            if (group == null)
            {
                Console.WriteLine("Qeyd elediyiniz Grup Nomresi movcud deyil");
                return;               
            }
            
            if (group.Students.Count>0)
            {
                 foreach (Student student in group.Students)
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
            foreach (Group group in Groups)
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
        public int CheckDigits ()
        {
            int num;
            string numStr = Console.ReadLine();
            numStr=numStr.Trim();
            bool result = int.TryParse(numStr, out num);
            if (!result||numStr.Length!=3)
            {
                do
                {
                    Console.WriteLine("Grup Nomresinin bash herfi novune uygun teyin edilmishdir.\n3 reqemli eded daxil edin");
                    numStr = Console.ReadLine();
                    numStr = numStr.Trim();
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

                case Category.Programlashdirma:
                    newno = $"P{CheckDigits()}";
                    break;
                case Category.Dizayn:
                    newno = $"D{CheckDigits()}";
                    break;
                case Category.Sistem:
                    newno = $"S{CheckDigits()}";
                    break;
                default:
                    break;
            }
            return newno;
        }
        public void CheckStudents(string no)                    
        {
            Group group = FindGroup(no);
            if (group == null)
            {
                Console.WriteLine("Bele bir Grup Nomresi movcud deyil");
                return;
            }
            foreach (Student student in group.Students)
            {
                
                    Console.WriteLine(student);
               
            }
        }
        public int CheckNumbersOfStudents()
        {
            int number = 0;
            foreach (Group group in Groups)
            {
                number += group.Students.Count;
            }
            return number;
        }
        public bool FindGroupBoolReturn(string no)
        {
            bool result = true;
            foreach (Group group in Groups)
            {
                if (group.GroupNo.ToLower().Trim() == no.ToLower().Trim())
                {
                    result = false;

                }

            }
            return result;
        }
        public void CheckCreatedGroupNO(Group group)
        {
            if (FindGroupBoolReturn(group.GroupNo) == false)
            {
                do
                {
                    
                    switch (group.Type)
                    {

                        case Category.Programlashdirma:
                            group.GroupNo = $"P{Group.Count}";
                            break;
                        case Category.Dizayn:
                            group.GroupNo = $"D{Group.Count}";
                            break;
                        case Category.Sistem:
                            group.GroupNo = $"S{Group.Count}";
                            break;                        
                    }
                    Group.Count++;
                } while (FindGroupBoolReturn(group.GroupNo)==false);
            }
        }

}
}
