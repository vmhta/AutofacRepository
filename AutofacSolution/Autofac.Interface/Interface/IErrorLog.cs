using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Interface.Interface
{
    public interface IErrorLogService
    {
        bool LogError(string exception, DateTime datetime);
    }
}
