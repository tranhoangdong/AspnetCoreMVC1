//13.Sự khác biệt giữa phương thức Finalize() và Dispose() là gì?
//Dispose() được gọi khi chúng ta muốn release bất kỳ tài nguyên không được quản lý nào và thực hiện tác vụ dọn dẹp khác. Dispose() 
//    có kiểm soát hơn khi giải phóng tài nguyên, cho phép thực hiện các tác vụ dọn dẹp bổ sung như đóng CSDL, giải phóng cache,...
//Finalize() được gọi bởi garbage collector, dùng để thu gom các đối tượng không còn được tham chiếu (tức là những tài nguyên không còn được quả lý)
//    nhưng nó không đảm bảo việc thu gom rác của một đối tượng.


using System;

class Resource
{
    ~Resource() // Destructor
    {
        Console.WriteLine("Finalize() được gọi để giải phóng tài nguyên.");
    }
}

class Program
{
    static void Main()
    {
        Resource res = new Resource();
        res = null;

        // Bắt buộc gọi Garbage Collector để minh họa
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("Chương trình kết thúc.");
    }
}


using System;

class Resource : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Dispose() được gọi để giải phóng tài nguyên.");
    }
}

class Program
{
    static void Main()
    {
        using (Resource res = new Resource())
        {
            Console.WriteLine("Sử dụng tài nguyên.");
        }

        Console.WriteLine("Tài nguyên đã được giải phóng.");
    }
}
