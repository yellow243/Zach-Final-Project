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
        public void UpdateGod(God god)
        {
            _conn.Execute("UPDATE greekgods SET Name = @name, Description = @description WHERE GodID = @id",
             new { name = god.Name, description = god.Description, id = god.GodID });
        }

        public void InsertGod(God GodToInsert)
        {
            _conn.Execute("INSERT INTO greekgods (NAME, Description) VALUES (@name, @description);",
                new { name = GodToInsert.Name, description = GodToInsert.Description });
        }

        public void DeleteGod(God god)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE GodID = @id;", new { id = god.GodID });
            _conn.Execute("DELETE FROM Sales WHERE GodID = @id;", new { id = god.GodID });
            _conn.Execute("DELETE FROM Gods WHERE GodID = @id;", new { id = god.GodID });
        }

    }
}
