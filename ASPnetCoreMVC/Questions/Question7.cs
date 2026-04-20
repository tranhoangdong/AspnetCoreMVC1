//7.Loại giá trị(value types) và loại tham chiếu (reference types) là gì?
//Loại giá trị (value types): Lưu trữ giá trị của chúng trực tiếp trong biến ở trong không gian bộ nhớ của chính nó. Kiểu dữ liệu số nguyên, số thực, bool, char,... đều là loại giá trị (value types).
//Ví dụ: 

//int a = 30;

//Kiểu tham chiếu (reference types) lưu trữ địa chỉ của đối tượng nơi giá trị đang được lưu trữ. Hay nói cách khác, kiểu tham chiếu là một con trỏ tới vị trí bộ nhớ khác. Kiểu dữ liệu lớp, interface, array,... là loại tham chiếu (reference types).
//Ví du:

//string b = "Hello ITNavi với câu hỏi phỏng vấn C# hay!!";

using System;

class Program
{
    static void Main()
    {
        int x = 10;
        int y = x; // Sao chép giá trị của x vào y
        y = 20;

        Console.WriteLine($"x = {x}"); // Kết quả: x = 10
        Console.WriteLine($"y = {y}"); // Kết quả: y = 20
    }
}
class Program
{
    static void Main()
    {
        int[] arr1 = { 1, 2, 3 };
        int[] arr2 = arr1; // arr2 trỏ đến cùng vùng nhớ với arr1
        arr2[0] = 10;

        Console.WriteLine($"arr1[0] = {arr1[0]}"); // Kết quả: arr1[0] = 10
        Console.WriteLine($"arr2[0] = {arr2[0]}"); // Kết quả: arr2[0] = 10
    }
}
