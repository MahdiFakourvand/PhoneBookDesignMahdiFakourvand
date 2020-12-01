using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Program
    {



        static void Main(string[] args)
        {
        x:

            Console.Write("(Design: MahdiFakourvand); Enter: (Get, Add, Remove, Cls, Update)");
            string Cmd = Console.ReadLine();
            if (Cmd.ToLower() == "get")
            {
                Utility u = new Utility();
                Console.WriteLine();
                Console.WriteLine("List Of Numbers ==>" + DateTime.Now.ToShortDateString());
                Console.WriteLine("==============================================");
                foreach (var item in u.GetRows())
                {
                    Console.WriteLine("{0}\t{1}\t{2}", item.ID, item.Name, item.Phone);
                }
                goto x;
            }
            else if (Cmd.ToLower() == "cls")
            {
                Console.Clear();
                goto x;
            }
            else if (Cmd.ToLower() == "remove")
            {
                Utility u = new Utility();
            Rem:

                Console.Write("(Design: MahdiFakourvand); Enter ID: (Get List With 'Get' Commnd): ");
                int id = int.Parse(Console.ReadLine());

                if (u.CheckExistID(id))
                {
                    u.RemoveRow(id);
                    Console.WriteLine("{0} is Removed!!!", id);
                    goto x;
                }
                else
                {
                    Console.WriteLine("ID Not Found!!!");
                    Console.WriteLine();
                    goto Rem;
                }
            }
            else if (Cmd.ToLower() == "add")
            {
                Console.Write("Enter Name: ");
                string Name = Console.ReadLine();

                Console.Write("Enter Phone: ");
                string Phone = Console.ReadLine();

                Utility u = new Utility();
                u.AddRow(new TblNum() { Name = Name, Phone = Phone });
                Console.WriteLine("Successed !!!");
                Console.WriteLine();
                goto x;
            }
            else if (Cmd.ToLower() == "update")
            {

                Utility u = new Utility();
            Edit:
                Console.Write("(Design: MahdiFakourvand); Enter ID of Record To Edit: ");
                int ID = int.Parse(Console.ReadLine());

                if (u.CheckExistID(ID))
                {
                    TblNum t = u.GetSingleRow(ID);
                    Console.WriteLine("Old Value is: ");
                    Console.WriteLine("{0}\t{1}\t{2}",t.ID,t.Name,t.Phone);

                    TblNum tNew = new TblNum();

                    tNew.ID = t.ID;

                    Console.Write("Enter Name: ");
                    tNew.Name = Console.ReadLine();

                    Console.Write("Enter Phone: ");
                    tNew.Phone = Console.ReadLine();

                    u.Edit(tNew);

                    goto x;
                }
                else
                {
                    Console.WriteLine("{0} Not Found!!!", ID);
                    goto Edit;
                }

            }

        }
    }
}
