using Dapper;
using Org.BouncyCastle.Security;
using System.Data;
using Zach_Final_Project.Models;

namespace Zach_Final_Project
{
    public class GodRepository : IGodRepository
    {
        private readonly IDbConnection _conn;
        public GodRepository(IDbConnection conn)
        {
            
            _conn = conn;
        }
        public IEnumerable<God> GetAllProducts()
        {
            return _conn.Query<God>("SELECT * FROM greekgods;");
        }
    }
}
