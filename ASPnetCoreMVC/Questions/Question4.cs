//4.Câu lệnh 'using' trong C# có tác dụng gì?
//Khối 'using' được sử dụng để giải phóng tài nguyên không cần thiết (ví dụ như kết nối CSDL, tệp, đối tượng,...),
//sau đó tự động loại bỏ khi quá trình thực thi khối hoàn tất.
//‘using’ còn được sử dụng để tạo Namespace mà bạn muốn sử dụng trong code của mình.

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!"); 
    }
}
