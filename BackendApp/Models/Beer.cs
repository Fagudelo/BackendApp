using Newtonsoft.Json;

namespace BackendApp.Models
{
    public class Beer
    {
        public int BeerId { get; set; }
        public Required Name { get; set; }
    }
}
