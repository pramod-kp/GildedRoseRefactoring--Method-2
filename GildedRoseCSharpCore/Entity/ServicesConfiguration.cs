using System.Collections.Generic;

namespace GildedRoseCSharpCore.Entity
{
    class ServicesConfiguration
    {
        public IEnumerable<ServiceItem> Singleton { get; set; }
        public IEnumerable<ServiceItem> Transient { get; set; }
    }
}
