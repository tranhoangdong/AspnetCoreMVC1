//12.Viết cú pháp C# để xử lý (catch) một ngoại lệ (exception)
//Ta sử dụng khối try-catch. Catch blocks có thể có tham số thuộc loại system.Exception type.

//Ví dụ:

//try
//{

//    GetAllData();

//}

//catch (Exception ex)
//{

//}

using System;

class Program
{
    static void Main()
    {
        try
        {
            int a = 10;
            int b = 0;
            int result = a / b; // Lỗi chia cho 0
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Lỗi: Không thể chia cho 0.");
            Console.WriteLine("Chi tiết lỗi: " + ex.Message);
        }
    }
}
