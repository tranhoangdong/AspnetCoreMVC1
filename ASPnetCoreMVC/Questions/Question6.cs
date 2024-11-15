//6.Bạn hãy phân biệt hằng số (constants) và biến chỉ đọc (read-only)
//Hằng số(Constants) được khai báo và khởi tạo tại thời điểm biên dịch, không thể thay đổi giá trị sau đó. Ví dụ như để định nghĩa các
//    giá trị không thay đổi như số PI (π),...
//Biến chỉ đọc (readonly) là giá trị không thay đổi, chỉ được sử dụng khi chúng ta muốn gán giá trị tại thời điểm khởi tạo.

using System;

class ConstantsExample
{
    public const double Pi = 3.14159;        // Hằng số kiểu double
    public const string AppName = "MyApp";  // Hằng số kiểu chuỗi
}

class Program
{
    static void Main()
    {
        Console.WriteLine($"Pi: {ConstantsExample.Pi}");          // Kết quả: 3.14159
        Console.WriteLine($"AppName: {ConstantsExample.AppName}");// Kết quả: MyApp

        // ConstantsExample.Pi = 3.14;  // Lỗi: Không thể gán lại giá trị hằng
    }
}


class ReadOnlyExample
{
    public readonly double Radius;
    public readonly double Circumference;

    public ReadOnlyExample(double radius)
    {
        Radius = radius;
        Circumference = 2 * ConstantsExample.Pi * Radius; 
    }
}

class Program
{
    static void Main()
    {
        ReadOnlyExample circle = new ReadOnlyExample(5); 
        Console.WriteLine($"Radius: {circle.Radius}");          
        Console.WriteLine($"Circumference: {circle.Circumference}");

    }
}
