using Dapper;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
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
            _conn.Execute("UPDATE greekgods SET " +
                "Name = @name, " +
                "Description = @description, " +
                "Temple_Location = @temple_location, " +
                "Parents = @parents "+
                "WHERE GodID = @id",
             new { name = god.Name, 
                 description = god.Description, 
                 temple_location = god.Temple_Location,
                 parents = god.Parents,
                 id = god.GodID });
        }

        public void InsertGod(God GodToInsert)
        {
            _conn.Execute("INSERT INTO greekgods (NAME, Description, Temple_Location, Parents) VALUES (@name, @description, @temple_location, @parents);",
                new
                {
                    name = GodToInsert.Name,
                    description = GodToInsert.Description,
                    temple_location = GodToInsert.Temple_Location,
                    parents = GodToInsert.Parents
                });
        }

        public void DeleteGod(God god)
        {
            
            _conn.Execute("DELETE FROM greekgods WHERE GodID = @id;", new { id = god.GodID });
        }

    }
}
