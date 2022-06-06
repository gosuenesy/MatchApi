using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchApi.Models
{
    public class Secrets
    {
        //Remember to add this file to the .gitignore file sp you don't accidentally share yoyr azure DB username and password
        public static readonly string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Matches;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //public static readonly string ConnectionString = "Server=tcp:niko-server.database.windows.net,1433;Initial Catalog=niko-Database;Persist Security Info=False;User ID=nikoadmin;Password=Nikoserverpass!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
