using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class ListRocksdbResponse
    {
        public RocksDb[] Databases { set; get; }
    }
    public class RocksDb
    {
        public string tablespace { get; set; }
        public string DataDir { get; set; }
        public string DbPath { set; get; }
    }
    public class ListDatabasesResponse
    {
        public DatabaseInfo[] Databasesinfo { set; get; }
    }
    public class DatabaseInfo
    {
        public string Name { set; get; }
        public string Path { set; get; }
        public string Tablespace { set; get; }
        public string[] Tables { set; get; }
        public string[] Streams { set; get; }
    }
}
