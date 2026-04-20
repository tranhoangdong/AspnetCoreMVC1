//9.Method overloading là gì?
//Method overloading là một tính năng trong C# cho phép tạo nhiều phương thức có cùng tên với các chữ ký duy nhất trong cùng một lớp (class). Hãy nói đơn giản là Method overloading cho phép có nhiều phương thức cùng tên trong một lớp nhưng phải có các tham số khác nhau.

//Khi biên dịch, trình biên dịch sử dụng overload resolution để xác định phương thức cụ thể sẽ được gọi.

//Ví dụ về Method overloading:

//public class Calculator

//{

//    public int Add(int a, int b)

//    {

//        return a + b;

//    }



//    public double Add(double a, double b)

//    {

//        return a + b;

//    }



//    public string Add(string str1, string str2)

//    {

//        return str1 + str2;

//    }

//}