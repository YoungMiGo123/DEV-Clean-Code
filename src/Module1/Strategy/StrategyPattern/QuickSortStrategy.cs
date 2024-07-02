namespace StrategyPattern
{
    public class QuickSortStrategy : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Sorting using Quick Sort");
            QuickSort(list, 0, list.Count - 1);
        }

        private void QuickSort(List<int> list, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(list, low, high);

                QuickSort(list, low, pi - 1);
                QuickSort(list, pi + 1, high);
            }
        }

        private int Partition(List<int> list, int low, int high)
        {
            int pivot = list[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (list[j] < pivot)
                {
                    i++;
                    (list[j], list[i]) = (list[i], list[j]);
                }
            }
            (list[high], list[i + 1]) = (list[i + 1], list[high]);
            return i + 1;
        }
    }
}
