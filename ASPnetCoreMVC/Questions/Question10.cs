//10.Bạn hãy nêu sự khác nhau giữa Array và Arraylist
//Trong một mảng (array), chúng ta chỉ có thể có các mục cùng loại, kích thước của mảng được cố định khi so sánh.
//Danh sách mảng (Arraylist) tương tự như mảng nhưng không có kích thước cố định.

using System;

class Program
{
    static void Main()
    {
        // Khởi tạo mảng kiểu int
        int[] numbers = new int[3] { 1, 2, 3 };

        // Duyệt mảng
        foreach (int number in numbers)
        {
            Console.WriteLine(number); // Kết quả: 1, 2, 3
        }

        // Thay đổi giá trị trong mảng
        numbers[1] = 10;
        Console.WriteLine(numbers[1]); // Kết quả: 10
    }
}


using System.Collections;

class Program
{
    static void Main()
    {
        // Khởi tạo ArrayList
        ArrayList list = new ArrayList();

        // Thêm các phần tử vào ArrayList
        list.Add(1);       // Số nguyên
        list.Add("Hello"); // Chuỗi
        list.Add(3.14);    // Số thực

        // Duyệt ArrayList
        foreach (var item in list)
        {
            Console.WriteLine(item);
            // Kết quả: 1, Hello, 3.14
        }

        // Truy cập và thay đổi phần tử
        list[1] = "World";
        Console.WriteLine(list[1]); // Kết quả: World
    }
}
