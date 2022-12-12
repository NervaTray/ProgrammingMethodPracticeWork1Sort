// Первая практическая работа по дисциплине "Технологии и методы программирования".
// Реализовать Стек.

using System;


// Класс стека.
class StackS
{
    private List<int> stack;


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
    static void Main()
    {
        StackS stack = new StackS();
        
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        
        stack.PrintStack();
        Console.WriteLine(stack.Pop());
        stack.PrintStack();
    }
}