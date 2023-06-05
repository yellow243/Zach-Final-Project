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
        public IEnumerable<God> GetAllGods()
        {
            return _conn.Query<God>("SELECT * FROM greekgods;");
        }

        public God GetGod(int id)
        {
            return _conn.QuerySingle<God>("SELECT * FROM greekgods WHERE GodID = @id", new { id = id });
        }
    }
}
