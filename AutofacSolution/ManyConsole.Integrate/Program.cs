using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyConsole.Integrate
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = GetCommands();

            // then run them.
            ConsoleCommandDispatcher.DispatchCommand(commands, args, Console.Out);
            Console.ReadLine();
        }

        public static IEnumerable<ConsoleCommand> GetCommands()
        {
            return ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program));
        }
    }
}
