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
                GroupStudents(group.GroupNo);
            }
        }

        public void CreateGroup(TypeGroup typeGroup)           //hazir
        {
            Group group = new Group(typeGroup);
            if (group.Type!=TypeGroup.Dizayn&&group.Type != TypeGroup.Programlashdirma&&group.Type != TypeGroup.Sistem)
            {                
                return ;
            }
            else
            {
                group.isOnline = Helper.IsOnlineOrNot();
                if (group.isOnline == null)
                {
                    Console.WriteLine("bele bir grup movcud deyil Esas menuya kecid edildi");
                    return;
                }
                else
                {
                    if (group.isOnline)
                    {
                        group.Limit = 15;
                        _groups.Add(group);
                        Console.WriteLine(group.GroupNo + $"-adli grup yaradildi");
                    }
                    else
                    {
                        group.Limit = 10;
                        _groups.Add(group);
                        Console.WriteLine(group.GroupNo + $"-adli grup yaradildi");
                    }
                    
                }
            }
            
        }

        public void CreateStudent(string no)
        {
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
            Student student = new Student();
            student.FullName = DetermineFullname();
            student.guarrantee = Helper.Guarranteed();
            group.students.Add(student);
            student.StudentGroupNo = group.GroupNo;







        }

        public void EditGroup()                             //hazir
        {
            Console.WriteLine("Deyishmek istediyiniz grupun adini qeyd edin");
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
            Console.WriteLine("Yeni grup nomresini daxil edin");
            string newno= Console.ReadLine();
            foreach (Group item in _groups)
            {
                if (item.GroupNo.ToLower().Trim() == newno.ToLower().Trim())
                {
                    newno = null;
                }
            }
            if (newno==null)
            {
                do
                {
                    Console.WriteLine("Bu nomreli grup artiq movcuddur bashqa nomre daxil edin");
                    newno = Console.ReadLine();
                    foreach (Group item in _groups)
                    {
                        if (item.GroupNo.ToLower().Trim() == newno.ToLower().Trim())
                        {
                            newno = null;
                        }
                    }
                } while (newno==null);
            }
            group.GroupNo =Capitalized(newno);
            Console.WriteLine(group.GroupNo);
        }

        public void GroupStudents(string no)                    //hazir
        {                                  
            Group group = FindGroup(no);
            if (group == null)
            {
                do
                {
                    Console.WriteLine("Bu nomreli bir grup movcud deyil yeniden cehd edin");
                    no = Console.ReadLine();
                    group = FindGroup(no);

                } while (group == null);
            }
            foreach (Student student in group.students)
            {
                Console.WriteLine(student.FullName);
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
                //else
                //{
                //    group = null;
                //    do
                //    {
                //        group = null;
                //        Console.WriteLine("Duzgun deyer secin");
                //        no = Console.ReadLine();
                //    } while (group==null);
                    
                //}
                
            }            
            return null;
        }
        public string DetermineFullname()
        {
            Console.WriteLine("ad elave et");
            string name = Console.ReadLine();
            name = NameLength(name);

            if (!CheckLetters(name))
            {
                do
                {
                    Console.WriteLine("herflerden ibaret olmalidir");
                    name = Console.ReadLine();
                    name = NameLength(name);


                } while (!CheckLetters(name));
            }
           
            Console.WriteLine("soyad elave et");
            string surname = Console.ReadLine();
            surname = NameLength(surname);
            if (!CheckLetters(surname))
            {
                do
                {
                    Console.WriteLine("herflerden ibaret olmalidir");
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
                    Console.WriteLine("uzunluq 3 olmalidir");
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
        //public TypeGroup ChooseType()
        //{
        //    Console.WriteLine("Grup novunu secin:\n1. Programlashdirma\n2. Dizayn\n3. Sistem ");
        //    int num;
        //    string numStr = Console.ReadLine();
        //    bool result = int.TryParse(numStr, out num);
        //    TypeGroup type = new TypeGroup();
           
        //    if (true)
        //    {
        //        switch (num)
        //        {
        //            case 1:
        //                type = TypeGroup.Programlashdirma;
        //                break;
        //            case 2:
        //                type = TypeGroup.Dizayn;
        //                break;
        //            case 3:
        //                type = TypeGroup.Sistem;
        //                break;
        //            default:
        //                break;
        //        }
        //        return type;
        //    }
        //    else
        //    {
        //        do
        //        {
        //            Console.WriteLine("Duzgun deyer teyin olunamyib yeniden cehd edin edin");
        //            Console.WriteLine("Grup novunu secin:\n1. Programlashdirma\n2. Dizayn\n3. Sistem ");
        //            numStr = Console.ReadLine();
        //             result = int.TryParse(numStr, out num);
        //        } while (!result);
        //        switch (num)
        //        {
        //            case 1:
        //                type = TypeGroup.Programlashdirma;
        //                break;
        //            case 2:
        //                type = TypeGroup.Dizayn;
        //                break;
        //            case 3:
        //                type = TypeGroup.Sistem;
        //                break;
        //            default:
        //                break;
        //        }
        //        return type;

        //    }
        //}
        
    }
}
