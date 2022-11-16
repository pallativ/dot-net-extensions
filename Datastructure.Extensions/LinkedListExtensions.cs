namespace Extensions.DataStructures
{
    public static class LinkedListExtensions
    {
        /// <summary>
        /// Reverses the linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="linkedList"></param>
        /// <returns></returns>
        public static LinkedList<T> Reverse<T>(this LinkedList<T> linkedList)
        {
            var current = linkedList.First;
            while (current != null)
            {
                linkedList.AddLast(current);
                linkedList.RemoveFirst();
                current = current.Next;
            }

            return linkedList;
        }
    }
}