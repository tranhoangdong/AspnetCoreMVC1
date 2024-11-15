//5.Bạn hãy cho biết, chúng ta có thể sử dụng lệnh “this” trong một phương thức tĩnh không?
//Không thể. Vì chỉ có thể sử dụng các biến/phương thức tĩnh trong một phương thức tĩnh (static method) trong C#. 
//    Trong đó, lệnh “this” được dùng để tham chiếu đến đối tượng hiện tại của một lớp (instance). 
//    Còn phương thức tĩnh thì không có đối tượng hiện tại, mà chỉ hoạt động trên lớp chính nó.

// phương thức không tĩnh 
using System;

class Example
{
    public int Number { get; set; }

    public void ShowNumber()
    {
        Console.WriteLine($"The number is: {this.Number}"); 
    }
}

class Program
{
    static void Main()
    {
        Example example = new Example { Number = 42 };
        example.ShowNumber(); 
    }
}

// phương thức tĩnh 
class Example
{
    public int Number { get; set; }

    public static void ShowNumber()
    {
        Console.WriteLine($"The number is: {this.Number}"); // Lỗi: Không thể sử dụng 'this' trong phương thức tĩnh
    }
}

