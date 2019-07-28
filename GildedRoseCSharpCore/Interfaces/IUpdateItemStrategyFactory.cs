using GildedRoseCSharpCore.Entity;

namespace GildedRoseCSharpCore.Interfaces
{
    public interface IUpdateItemStrategyFactory
    {
        IInventoryUpdateStrategy GetStrategy(ItemList item);
    }
}