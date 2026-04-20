//11.Bạn làm thế nào để sắp xếp các phần tử của mảng theo thứ tự giảm dần?
//Sử dụng phương thức Sort() sau đó dùng phương thức Reverse().


using System;
using System.Linq;
using System;

class Program
{
    static void Main()
    {
        // Khởi tạo mảng
        int[] numbers = { 5, 3, 8, 1, 4 };

        // Sắp xếp theo thứ tự tăng dần
        Array.Sort(numbers);

        // Đảo ngược mảng để có thứ tự giảm dần
        Array.Reverse(numbers);

        // Hiển thị mảng đã sắp xếp
        Console.WriteLine("Mảng sau khi sắp xếp giảm dần:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}



class Program
{
    static void Main()
    {
        // Khởi tạo mảng
        int[] numbers = { 5, 3, 8, 1, 4 };

        // Sắp xếp giảm dần với LINQ
        var sortedNumbers = numbers.OrderByDescending(n => n).ToArray();

        // Hiển thị mảng đã sắp xếp
        Console.WriteLine("Mảng sau khi sắp xếp giảm dần:");
        foreach (int number in sortedNumbers)
        {
            Console.WriteLine(number);
        }
    }
}
