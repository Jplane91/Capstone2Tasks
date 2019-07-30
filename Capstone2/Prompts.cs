using System;
namespace Capstone2
{
    public class Prompts
    {
        public static void WelcomeUser()
        {
            Console.WriteLine("Welcome to the task manager");
        }

        public static int ListTasks()
        {
            Console.WriteLine("\nWhich item would you like?\n1.List Tasks\n2.Add Task"+
                "\n3.Delete Task\n4.Mark Task Complete\n5.Quit"); //List, Add, Delete, Completed, Quit
            int userChoosesItem = int.Parse(Console.ReadLine());
            if(userChoosesItem > 0 && userChoosesItem < 6)
            {
                return userChoosesItem;
            }

            else
            {
                Console.WriteLine("Invalid option, please choose again");
                int loop = ListTasks();
                return ListTasks();
            }


            }
    }
}
