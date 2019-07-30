using System;
using System.Collections.Generic;

namespace Capstone2
{
    class Program
    {
        public static List<Tasks> productionInfo = new List<Tasks>
        {
          new Tasks("Jake","Transfer Footage",new DateTime(2019,07,24), false),
          new Tasks("Rachel","Log Footage",new DateTime(2019,07,27), false),
          new Tasks("Brad","Assemble Edit",new DateTime(2019,07,29), false),
          new Tasks("Matt","Create Graphics",new DateTime(2019,08,02), false),
          new Tasks("Tony","Make Final Edit",new DateTime(2019,08,04), false),
        };

        static void Main(string[] args)
        {
            bool loop = true;
            Prompts.WelcomeUser();

            while (loop)
            {
                Tasks.TaskToDo(productionInfo);
            }
        }

    }
}
