using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.DAL.Repository
{
    public abstract class ConnectionBase
    {
        protected string _connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HolyDayRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
