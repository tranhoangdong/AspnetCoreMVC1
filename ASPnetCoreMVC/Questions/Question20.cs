//20.Phân biệt == và phương thức Equals
//Equals là phương thức được kế thừa từ class cơ sở Object và có thể bị ghi đè trong các class con. Equal so sánh theo kiểu tham chiếu nội dung của đối tượng.
//== là toán tử so sánh bằng, dùng để so sánh theo kiểu dữ liệu giá trị như số nguyên, số thực, chuỗi, các kiểu dữ liệu nguyên thủy,...

using System;

class Program
{
    static void Main()
    {
        // So sánh kiểu giá trị
        int a = 5;
        int b = 5;
        Console.WriteLine(a == b);           // True
        Console.WriteLine(a.Equals(b));      // True

        // So sánh kiểu tham chiếu
        string str1 = "Hello";
        string str2 = "Hello";
        Console.WriteLine(str1 == str2);     // True (so sánh giá trị trong string)
        Console.WriteLine(str1.Equals(str2)); // True (so sánh giá trị trong string)

        // So sánh đối tượng (chưa ghi đè Equals)
        object obj1 = new object();
        object obj2 = new object();
        Console.WriteLine(obj1 == obj2);     // False (so sánh tham chiếu)
        Console.WriteLine(obj1.Equals(obj2)); // False (so sánh tham chiếu)

        // Ghi đè Equals trong lớp của người dùng
        Person person1 = new Person { Name = "John" };
        Person person2 = new Person { Name = "John" };
        Console.WriteLine(person1.Equals(person2)); // True (nếu ghi đè Equals trong Person)
    }
}

class Person
{
    public string Name { get; set; }

    // Ghi đè phương thức Equals
    public override bool Equals(object obj)
    {
        if (obj is Person)
        {
            Person other = (Person)obj;
            return this.Name == other.Name;
        }
        return false;
    }

    // Ghi đè phương thức GetHashCode (nếu ghi đè Equals)
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
