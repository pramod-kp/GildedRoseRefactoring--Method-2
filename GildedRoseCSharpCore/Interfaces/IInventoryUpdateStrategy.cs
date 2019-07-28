using GildedRoseCSharpCore.Entity;

namespace GildedRoseCSharpCore.Interfaces
{
    public interface IInventoryUpdateStrategy
    {
        void UpdateItem(ItemList item);
    }
}