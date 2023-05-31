using Zach_Final_Project.Models;

namespace Zach_Final_Project
{
    public interface IGodRepository 
    {
        public IEnumerable<God> GetAllGods();
    }
}
