//3.Sự khác biệt giữa các tham số ref và out là gì?
//Nói ngắn gọn, sự khác biệt giữa ref và out nằm ở chỗ:

//Tham số ref: Biến phải được khởi tạo trước khi gọi hàm và cho phép thay đổi giá trị trong phương thức.
//Tham số out: Không yêu cầu biến được khởi tạo trước khi gọi hàm, nhưng phải gán giá trị trong phương thức trước khi kết thúc.


using System;

class Program
{
    static void UseRef(ref int number)
    {
        number += 10; 
    }

    static void UseOut(out int number)
    {
        number = 50; 
    }

    static void Main()
    {
        int refNumber = 5;
        UseRef(ref refNumber);
        Console.WriteLine("Ref Result: " + refNumber); 

        int outNumber;
        UseOut(out outNumber);
        Console.WriteLine("Out Result: " + outNumber);
    }
}
