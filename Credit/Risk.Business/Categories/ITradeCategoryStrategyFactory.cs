using Risk.Persistence;

namespace Risk.Business
{
    public interface ITradeCategoryStrategyFactory
    {
        ITradeCategoryStrategy? GetStrategy(ITrade trade);
    }
}