namespace StrategyPattern
{
    public class OrderBySortStrategy : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            list = list.OrderBy(x => x).ToList();
        }
    }
}
