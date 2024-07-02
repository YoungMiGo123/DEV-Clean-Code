namespace StrategyPattern
{
    public class BubbleSortStrategy : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Sorting using Bubble Sort");
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        (list[j + 1], list[j]) = (list[j], list[j + 1]);
                    }
                }
            }
        }
    }
}
