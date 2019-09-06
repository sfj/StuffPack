using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StuffPack.Models
{
    public class PackList
    {
        public long Id { get; set; }

        public Collection<PackItem> PackItems;

        public string Description { get; set; }

        public decimal TotalWeight { get 
            {
                return PackItems.Sum(item => item.Weight);
            }
        }

         public decimal TotalVolume { get 
            {
                return PackItems.Sum(item => item.Volume);
            }
        }

        public PackList()
        {
            PackItems = new Collection<PackItem>();
        }
    }
}