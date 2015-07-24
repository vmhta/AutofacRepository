using Autofac.Interface;
using Autofac.Interface.Interface;
using System;

namespace Autofac.SqlLogConsole
{
    class Program
    {
        private static IContainer container;
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SQLLogError>().As<IErrorLogService>();
            container = builder.Build();

            bool response = WriteErrorLog();
            Console.WriteLine(response);

        }

        private static bool WriteErrorLog()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IErrorLogService>();
               return writer.LogError("exception raised", DateTime.Now);
            }
        }
    }
}
