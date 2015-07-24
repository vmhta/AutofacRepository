using Autofac;
using Autofac.Interface;
using Autofac.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyConsole.Integrate
{
    public class ErrorLogCommand : ConsoleCommand
    {
        private static IContainer container;
        public string _error;
        public ErrorLogCommand()
        {
            IsCommand("log");

            HasOption("e|error=", "enter the error", error => _error = error);
            HasOption("s|sql", "select sql as a provider", x => RegisterSQL());
            HasOption("f|file", "select file as a provider", x => RegisterFile());

        }

        private void RegisterSQL()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SQLLogError>().As<IErrorLogService>();
            container = builder.Build();
        }

        private void RegisterFile()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileLogError>().As<IErrorLogService>();
            container = builder.Build();
        }

        public override int Run(string[] remainingArguments)
        {
            if (string.IsNullOrWhiteSpace(_error))
            {
                Console.WriteLine("You did not specify error");
            }
            else
            {
                WriteErrorLog(_error);
                Console.WriteLine("Your error is: " + _error);
            }

            //Console.WriteLine("The remaining arguments were " + Newtonsoft.Json.JsonConvert.SerializeObject(remainingArguments));

            return 0;
        }

        private static bool WriteErrorLog(string _error)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IErrorLogService>();
                return writer.LogError(_error, DateTime.Now);
            }
        }
    }
}
