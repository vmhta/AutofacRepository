using System;

namespace Autofac.Entity
{
    public static class DbOperations
    {
        public static bool LogError(string exception, DateTime datetime)
        {
            using (MagDBEntities entity = new MagDBEntities())
            {
                ErrorLog log = new ErrorLog();
                log.Exception = exception;
                log.LoggedOnDatetime = datetime;
                entity.ErrorLogs.Add(log);
                entity.SaveChanges();
                return true;
            }
        }
    }
}
