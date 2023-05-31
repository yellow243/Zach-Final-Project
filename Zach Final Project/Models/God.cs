using System.Reflection.Metadata;

namespace Zach_Final_Project.Models
{
    public class God
    {
        public int GodID { get; set; }
        public char Name { get; set; }
        public char Description { get; set; }
        public char Temple_Location { get; set; }
        public string Parents { get; set; }
        public Blob Symbol { get; set; }
    }
}
