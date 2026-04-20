//18.Nêu sự khác nhau giữa interface và abstract class?
//Interface được dùng để mô tả hành vi chung của class mà không cần cung cấp methods thực thi. Một class hoặc class con có thể triển khai nhiều interface.
//Abstract class có thể chứa phân hàm và các phương thức trừu tượng, được dùng để cung cấp tinh năng chung mà class con có thể kế thừa và bổ sung thêm tính 
//    năng riêng. 
//    Abstract class không có tính kế thừa.


using System;

public interface IDriveable
{
    void Drive();  // Chỉ có khai báo, không có triển khai
}

public class Car : IDriveable
{
    public void Drive()
    {
        Console.WriteLine("Car is driving");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo đối tượng Car và gọi phương thức Drive
        Car car = new Car();
        car.Drive();
    }
}
using System;

public abstract class Animal
{
    public abstract void MakeSound();  // Phương thức abstract

    public void Eat()  // Phương thức đã triển khai
    {
        Console.WriteLine("Eating...");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bark");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo đối tượng Dog và gọi các phương thức
        Dog dog = new Dog();
        dog.MakeSound();  // In ra "Bark"
        dog.Eat();        // In ra "Eating..."
    }
}
