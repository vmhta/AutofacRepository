using Autofac.Interface.Interface;
using System;
using System.Text;
using Autofac.Entity;
using System.IO;

namespace Autofac.Interface
{
    public class SQLLogError : IErrorLogService
    {
        public bool LogError(string exception, DateTime datetime)
        {
            return DbOperations.LogError(exception, datetime);
        }
    }

    public class FileLogError : IErrorLogService
    {
        public bool LogError(string exception, DateTime datetime)
        {
            string path = @"C:\SampleErrorLog.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(exception);
                tw.Close();
            }
            else
            {
                File.AppendAllLines(path, new[] { exception });
            }
            return true;
        }
    }
}
