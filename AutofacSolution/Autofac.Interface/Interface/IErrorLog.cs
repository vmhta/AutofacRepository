using System;
using System.Text;

namespace Autofac.Interface.Interface
{
    public interface IErrorLogService
    {
        bool LogError(string exception, DateTime datetime);
    }
}
