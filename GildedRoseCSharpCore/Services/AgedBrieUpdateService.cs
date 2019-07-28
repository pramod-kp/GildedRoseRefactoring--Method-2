using GildedRoseCSharpCore.Entity;
using GildedRoseCSharpCore.Interfaces;

namespace GildedRoseCSharpCore.Services
{
    public class AgedBrieUpdateService : IAgedBrieUpdateService
    {
        public void UpdateItem(ItemList item)
        {
            item.SellIn--;
            if (item.Quality < 50) item.Quality++;
        }
    }
}