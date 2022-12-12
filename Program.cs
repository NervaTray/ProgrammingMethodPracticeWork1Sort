// Первая практическая работа по дисциплине "Технологии и методы программирования".
// Реализовать Стек.

using System;


// Класс стека.
class StackS
{
    private List<int> stack;
    private int nop;


    public int Count => stack.Count;
    public int Nop => nop;


    // Конструктор по умолчанию.
    public StackS()
    {
        stack = new List<int>();
        nop = 0;
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
        var i = leftIndex; nop += 1;
        var j = rightIndex; nop += 1;
        var pivot = median(array, leftIndex, rightIndex); nop += 5;
        nop += 1;
        while (i <= j)
        {
            nop += 2;
            while (array[i] < pivot)
            {
                i++; nop += 1;
            }

            nop += 2;
            while (array[j] > pivot)
            {
                j--; nop += 1;
            }

            nop += 1;
            if (i <= j)
            {
                // Swap via Deconstruction
                (array[i], array[j]) = (array[j], array[i]); nop += 1;
                i++; nop += 1;
                j--; nop += 1;
            }
        }

        nop += 1;
        if (leftIndex < j)
            SortArray(array, leftIndex, j); nop += 4;
        nop += 1;
        if (i < rightIndex)
            SortArray(array, i, rightIndex); nop += 4;
        return array;
    }

    // Поиск медианного элемента в списке.
    private int median(List<int> tlist, int leftIndex, int rightIndex)
    {

        List<int> list = tlist.GetRange(leftIndex, rightIndex - leftIndex + 1); nop += 5;
        int ave = 0; nop += 1;

        // Поиск среднего значения.
        nop += 1;
        for (int i = 0; i < list.Count; i++)
        {
            ave += list[i]; nop += 3;
            nop += 1;
        }

        ave /= list.Count; nop += 3;
        int dif = Math.Abs(ave - list[0]); nop += 4;
        int pivot = list[0]; nop += 2;

        // Поиск медианного элемента на основе разницы между выбранным элементом и средним значением.
        nop += 2;
        for (int i = 0; i < list.Count; i++)
        {
            if (Math.Abs(ave - list[i]) < dif)
            {
                nop += 4;
                dif = Math.Abs(ave - list[i]); nop += 4;
                pivot = list[i]; nop += 2;
            }

            nop += 1;
        }

        return pivot;
    }

    // Метод сортировки обернутый в другой метод.
    public void Sort()
    {
        if (!IsExists()) return;
        nop = 0;
        stack = SortArray(stack, 0, stack.Count - 1); nop += 5;
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

    // Проверяет пуст ли список.
    public bool IsExists()
    {
        if (stack.Count > 0) return true;
        return false;
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

    static void CountNop(int n)
    {
        StackS stack = new StackS();
        Random rnd = new Random();

        Console.WriteLine("N = " + n);
        
        DateTime dt = DateTime.Now;
        for (int i = 0; i < n; i++)
        {
            stack.Push(rnd.Next(1, 10001));
        }
        stack.Sort();
        Console.WriteLine("Nop = " + stack.Nop);
        Console.WriteLine(DateTime.Now - dt);
        stack.PrintStack();
    }
    
    static void Main()
    {
        
        CountNop(20);

        // List<int> test = new List<int>() {2, 3, 4, 5, 6, 7, 8};
        //
        // print(test);
        //
        // List<int> test2 = test.GetRange(1, 3);
        // print(test2);


    }
}