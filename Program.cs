// Первая практическая работа по дисциплине "Технологии и методы программирования".
// Реализовать Стек.

using System;


// Класс стека.
class StackS
{
    private List<int> stack;


    public int Count => stack.Count;


    // Конструктор по умолчанию.
    public StackS()
    {
        stack = new List<int>();
    }
    
    // Добавляет элемент в конец стека.
    public void Push(int el)
    {
        stack.Add(el);
    }
    
    // Возвращает объект на вершине стека, но не удаляет его.
    public int Peek()
    {
        return stack[stack.Count - 1];
    }
    
    // Возвращает объект на вершине стека и удаляет его.
    public int Pop()
    {
        int temp = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        return temp;
    }

    
    // Алгоритм быстрой сортировки с выбором медианного pivot.
    private List<int> SortArray(List<int> array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = median(array, leftIndex, rightIndex);
        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }
        
            while (array[j] > pivot)
            {
                j--;
            }
            if (i <= j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }
    
        if (leftIndex < j)
            SortArray(array, leftIndex, j);
        if (i < rightIndex)
            SortArray(array, i, rightIndex);
        return array;
    }

    // Поиск медианного элемента в списке.
    private int median(List<int> tlist, int leftIndex, int rightIndex)
    {

        List<int> list = tlist.GetRange(leftIndex, rightIndex - leftIndex + 1);
        int ave = 0;

        // Поиск среднего значения.
        for (int i = 0; i < list.Count; i++)
        {
            ave += list[i];
        }

        ave /= list.Count;
        int dif = Math.Abs(ave - list[0]);
        int pivot = list[0];

        // Поиск медианного элемента на основе разницы между выбранным элементом и средним значением.
        for (int i = 0; i < list.Count; i++)
        {
            if (Math.Abs(ave - list[i]) < dif)
            {
                dif = Math.Abs(ave - list[i]);
                pivot = list[i];
            }
        }

        return pivot;
    }

    // Метод сортировки обернутый в другой метод.
    public void Sort()
    {
        stack = SortArray(stack, 0, stack.Count - 1);
    }

    // Выводит весь стек в консоль (элементы стека не удаляются).
    public void PrintStack()
    {
        for (int i = 0; i < stack.Count; i++)
        {
            Console.Write(stack[i] + " ");
        }
        Console.WriteLine();
    }
    
}


class Program
{

    static void print(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
            
        }
        Console.WriteLine();
    }
    static void Main()
    {
        StackS stack = new StackS();
        
        stack.Push(52);
        stack.Push(14);
        stack.Push(67);
        stack.Push(71);
        stack.Push(42);
        stack.Push(38);
        stack.Push(39);
        stack.Push(40);
        stack.Push(96);
        stack.Push(56);
        
        stack.PrintStack();
        stack.Sort();
        stack.PrintStack();

        // List<int> test = new List<int>() {2, 3, 4, 5, 6, 7, 8};
        //
        // print(test);
        //
        // List<int> test2 = test.GetRange(1, 3);
        // print(test2);

    }
}