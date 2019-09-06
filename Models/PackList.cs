using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StuffPack.Models
{
    public class PackList
    {
        public long Id { get; set; }

        public Collection<PackItem> PackItems;

        public string Description { get; set; }        

        public PackList()
        {
            PackItems = new Collection<PackItem>();
        }
    }
}