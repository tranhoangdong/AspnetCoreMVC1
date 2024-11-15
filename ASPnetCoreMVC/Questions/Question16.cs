//Sự khác biệt chi tiết:
//""(Chuỗi rỗng):

//Đây là một chuỗi ký tự rỗng được xác định bởi hai dấu nháy kép không có ký tự gì ở giữa.
//Mỗi lần sử dụng "", một đối tượng mới của chuỗi sẽ được tạo ra.
//Sử dụng "" rất phổ biến và dễ hiểu trong lập trình.
//String.Empty:

//Đây là một trường tĩnh được định nghĩa trong lớp String và luôn luôn giữ giá trị là chuỗi rỗng.
//Bởi vì String.Empty là một giá trị tĩnh, nó không tạo ra đối tượng mới mỗi khi được sử dụng, giúp tiết kiệm bộ nhớ và hiệu suất khi sử dụng nhiều lần trong ứng dụng.
//Việc sử dụng String.Empty có thể giúp mã rõ ràng và dễ hiểu hơn khi bạn muốn làm rõ ý định là đang sử dụng chuỗi rỗng.

class Program
{
    static void Main()
    {
        string str = "";  // Chuỗi rỗng
        Console.WriteLine("Chuỗi rỗng là: '" + str + "'");
    }
}


class Program
{
    static void Main()
    {
        string str = String.Empty;  // Chuỗi rỗng
        Console.WriteLine("Chuỗi rỗng là: '" + str + "'");
    }
}
