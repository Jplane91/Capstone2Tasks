using System;
using System.Collections.Generic;

namespace Capstone2
{
    public class Tasks
    {
        private string name;
        private string taskInfo;
        private DateTime dueDate;
        private bool completed;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }

        }

        public string TaskInfo
        {
            get
            {
                return taskInfo;
            }
            set
            {
                taskInfo = value;
            }

        }

        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }

        public bool Completed
        {
            get
            {
                return completed;
            }
            set
            {
                completed = value;
            }
        }


        public Tasks()
        {

        }

        public Tasks(string _name, string _taskInfo, DateTime _date, bool _completed)
        {
            name = _name;
            taskInfo = _taskInfo;
            dueDate = _date;
            completed = _completed;
        }

        public static bool TaskToDo(List<Tasks> task)
        {
            int userOption = Prompts.ListTasks();
            if (userOption == 1)
            {
                int num1 = PrintEachTaskInList(task);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

            else if (userOption == 2)
            {
                bool x = UserAddTask(task);

            }

            else if (userOption == 3)
            {
                DeleteTask(task);
            }

            else if (userOption == 4)
            {
                bool complete = true;
                complete = MarkTaskComplete(task);
            }

            else if (userOption == 5)
            {
                Console.WriteLine("Have a good day!");
                System.Environment.Exit(1);
            }

            return true;
        }

        public static int PrintEachTaskInList(List<Tasks> task)
        {
          
            int numberOfTasks = 0;
            foreach (Tasks t in task)
            {
                numberOfTasks++;
                Console.WriteLine("\t"+ numberOfTasks + ". " + t.taskInfo);
            }
           
            return numberOfTasks;

        }

        public static bool UserAddTask(List<Tasks> tasks)
        {
            Tasks taskInfo = new Tasks();

            bool askUserAgain = true;

            Console.WriteLine("Who is the task assigned to?");
            string personResonsible = Console.ReadLine();
            taskInfo.name = personResonsible;

            Console.WriteLine("What is the task?");
            string newTaskInfo = Console.ReadLine();
            taskInfo.taskInfo = newTaskInfo;


            while (askUserAgain)
            {
                Console.WriteLine("When is the deadline for the task(mm/dd/yyyy)");
                string deadline = Console.ReadLine();
                if (DateTime.TryParse(deadline, out DateTime date))
                {
                    taskInfo.dueDate = date;
                    askUserAgain = false;

                }
                else
                {
                    Console.WriteLine("That is not a valid date.");
                    askUserAgain = true;
                }

            }


            Program.productionInfo.Add(taskInfo);
            taskInfo.PrintTaskInfo();

            Console.WriteLine("Hit any key to continue");
            Console.ReadKey();

            return true;
        }


        public void PrintTaskInfo()
        {
            Console.WriteLine("\tTeam member assigned: " + name);
            Console.WriteLine("\tTask info: " + taskInfo);
            Console.WriteLine("\tDue Date: " + dueDate);
            Console.WriteLine("\tIs this task is completed: " + completed +"\n");
            
        }

        public static void DeleteTask(List<Tasks>task)
        {
            Console.WriteLine("Which task would you like to delete?");
            int numOfTasks = PrintEachTaskInList(task);
            int taskToDelete = int.Parse(Console.ReadLine());


            taskToDelete = taskToDelete - 1;
            if (taskToDelete <= numOfTasks)
            {
                int taskNumber = taskToDelete;
                Console.WriteLine($"You have chosen task: {task[taskNumber].taskInfo}");
                bool deleteTaskConfirmation = true;

                while (deleteTaskConfirmation)
                {
                    Console.WriteLine($"Are you sure you want to delete task {taskNumber + 1}? yes or no");
                    string input = Console.ReadLine().ToLower();
                    if (input == "yes")
                    {
                        Console.WriteLine("You have deleted task: " + task);
                        task.Remove(task[taskNumber]);
                        deleteTaskConfirmation = false;

                    }

                    else if (input == "no")
                    {
                        DeleteTask(task);
                    }

                    else
                    {
                        Console.WriteLine("Invalid input");
                        deleteTaskConfirmation = true;
                    }
                }
            }
        }

        public static bool MarkTaskComplete(List<Tasks> task)
        {
            bool markTaskLoop = true;
            while (markTaskLoop)
            {
                Console.WriteLine("What task number would you like to mark complete?");
                int numOfTasks = PrintEachTaskInList(task);
                if (int.TryParse(Console.ReadLine(), out int taskToComplete))
                {
                    if (taskToComplete <= numOfTasks)
                    {
                        int taskIndex = taskToComplete - 1;
                        {
                            Console.WriteLine("You have chosen task: " + task[taskIndex].taskInfo);
                            Console.WriteLine("Are you sure you want to mark task " + taskToComplete + " complete? (yes or no)");
                            if (Console.ReadLine().ToLower() == "yes")
                            {
                                task[taskIndex].completed = true;
                                Console.WriteLine(taskToComplete + " was marked complete.");
                                task[taskIndex].PrintTaskInfo();
                                markTaskLoop = false;
                            }
                            else if (Console.ReadLine() == "no")
                            {
                                Console.WriteLine("Task" + taskToComplete + " was not marked complete.");
                            }
                            else
                            {
                                Console.WriteLine("That is not a valid input.");
                                markTaskLoop = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid task number.");
                        markTaskLoop = true;
                    }
                }
               
            }
            return true;
        }

    }
}
