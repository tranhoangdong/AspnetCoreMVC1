//15.Tại sao bạn không thể chỉ định công cụ sửa đổi khả năng truy cập cho các phương thức bên trong interface?
//Trong interface, chúng ta có các phương thức ảo không có định nghĩa phương thức. Tất cả các phương thức đều được ghi đè trong lớp dẫn xuất. 
//    Đó là lý do tại sao tất cả chúng đều được công khai
//    . Ngoài ra còn các lý do khác đó là:

//Các thực thi interface không nhất thiết phải có cùng khả năng truy cập, nhưng bắt buộc có cùng tên, kiểu tham số.
//Nếu chỉ định khả năng truy cập cho phương thức trong interface có thể làm code của bạn trở nên dài dòng và hạn chế tính linh hoạt của
//    interface do các lớp thực thi bị ràng buộc bởi khả năng truy cập bị chỉ định.