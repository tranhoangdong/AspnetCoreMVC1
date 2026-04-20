//17.Bạn hãy phân biệt giữa Property và Field?
//Property: Là thành viên của class, dùng để quản lý cách truy cập đến Field. Trong một số trường hợp,
//    ta dùng Property để đảm bảo Field không bị gán các giá trị không hợp lệ.
//Field: Là một biến được khai báo trong class, có thể được public, protected hoặc private.

public class Person
{
    // Đây là một Field
    public string name;
}

class Program
{
    static void Main()
    {
        Person p = new Person();
        p.name = "John";  // Truy cập trực tiếp Field
        Console.WriteLine(p.name);
    }
}

public class Person
{
    private string _name;  // Field riêng tư

    // Đây là Property
    public string Name
    {
        get { return _name; }
        set
        {
            if (!string.IsNullOrEmpty(value)) // Kiểm tra giá trị nhập vào
            {
                _name = value;
            }
            else
            {
                throw new ArgumentException("Tên không thể rỗng.");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Person p = new Person();
        p.Name = "John";  // Truy cập Property, sẽ gọi set
        Console.WriteLine(p.Name);  // Truy cập Property, sẽ gọi get
    }
}
