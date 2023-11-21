using System;


using System;

class Program
{
    static void Main()
    {
        MyArrayList<int> myList = new MyArrayList<int>(5);
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        Console.WriteLine("ArrayList Count: " + myList.Count);
    }
}

public class MyArrayList<T>
{
    private T[] array;
    public int Capacity { get; private set; }
    public int Count { get; private set; }

    public MyArrayList(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("Capasity must be great.");
        }

        Capacity = capacity;
        array = new T[Capacity];
        Count = 0;
    }

    public void Add(T item)
    {
        if (Count == Capacity)
        {
            EnsureCapacity();
        }

        array[Count] = item;
        Count++;
    }

    public void AddRange(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    public void Remove(T item)
    {
        int index = IndexOf(item);
        if (index != -1)
        {
            RemoveAt(index);
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        for (int i = index; i < Count - 1; i++)
        {
            array[i] = array[i + 1];
        }

        Count--;
    }

    public void TrimToSize()
    {
        Capacity = Count;
        T[] newArray = new T[Capacity];
        Array.Copy(array, newArray, Count);
        array = newArray;
    }

    private void EnsureCapacity()
    {
        int newCapacity = Capacity * 2;
        T[] newArray = new T[newCapacity];
        Array.Copy(array, newArray, Count);
        array = newArray;
        Capacity = newCapacity;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(array[i], item))
            {
                return i;
            }
        }
        return -1;
    }
}

