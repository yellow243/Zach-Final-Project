using Zach_Final_Project.Models;

namespace Zach_Final_Project
{
    public interface IGodRepository 
    {
        public IEnumerable<God> GetAllGods();
        public God GetGod(int id);
        public void UpdateGod(God god);
        public void InsertGod(God GodToInsert);
        public void DeleteGod(God god);

    }
}
