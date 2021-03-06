# Phần mềm Quản lý học sinh THPT

<p align="center"><img src='https://github.com/18520339/quan-ly-hoc-sinh/blob/main/image/demo.png?raw=true' /></p>

## Giới thiệu

Phần mềm được xây dựng lại từ sản phẩm [Phần mềm quản lý điểm học sinh](https://github.com/18520339/quan-ly-hoc-sinh/tree/main/Original) của anh [Nguyễn Hoàng Tùng](mailto:hoangtung@inbox.com) với các cải tiến mới:

-   Kiến trúc:
    -   Xây dựng theo mô hình 3 layers: **BUS**, **DAO**, **DTO**
    -   Sử dụng đối tượng **Data Provider** để tạo các kết nối, tương tác với CSDL bằng `ADO.NET`
    -   Thiết kế các đối tượng trong **BUS** và **DAO** theo Design Pattern `Singleton`
-   Cơ sở dữ liệu:
    -   Xây dựng CSDL trên Cloud với [Azure SQL Database](https://docs.microsoft.com/vi-vn/azure/azure-sql/database/sql-database-paas-overview)
    -   Sử dụng **Procedure** cho các tác vụ phức tạp lên CSDL, đồng thời hạn chế lỗi **SQL Injection**
-   Thêm các chức năng:
    -   Mã hóa mật khẩu người dùng
    -   Đóng gói và cập nhật phần mềm tự động với [Squirrel.Windows](https://github.com/Squirrel/Squirrel.Windows)
-   Sửa các lỗi:
    -   Vẫn có thể sử dụng tab đang bật dù đã đăng xuất
    -   **ReportViewer** không hiển thị giá trị

## Cách sử dụng

1.  Tạo tài khoản [Microsoft Azure](https://azure.microsoft.com/en-us/)
2.  Tiến hành tạo **Azure SQL Database** theo [hướng dẫn](https://docs.microsoft.com/vi-vn/azure/azure-sql/database/single-database-create-quickstart)
3.  Tạo các Table và Procedure tương ứng cho **Azure SQL Database**:

    -   Copy nội dụng file [Scripts.sql](https://github.com/18520339/quan-ly-hoc-sinh/blob/main/DATABASE/Scripts.sql) vào **Query editor (preview)** và bấm **Run**:
    -   Ngoài ra, có thể thực hiện trên [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (**SSMS**) với tên và tài khoản Server đã tạo:

    <p align="center"><img src='https://github.com/18520339/quan-ly-hoc-sinh/blob/main/image/ssms.png?raw=true' /></p>

    -   Lưu ý:
        -   [Scripts.sql](https://github.com/18520339/quan-ly-hoc-sinh/blob/main/DATABASE/Scripts.sql) được tổng hợp từ 3 files: [Procedures.sql](https://github.com/18520339/quan-ly-hoc-sinh/blob/main/DATABASE/Procedures.sql), [Tables.sql](https://github.com/18520339/quan-ly-hoc-sinh/blob/main/DATABASE/Tables.sql), [Users.sql](https://github.com/18520339/quan-ly-hoc-sinh/blob/main/DATABASE/Users.sql) và được tạo nên bằng chức năng **Generates Scripts** của **SSMS**
        -   Nếu sử dụng file [Scripts.sql](https://github.com/18520339/quan-ly-hoc-sinh/blob/main/DATABASE/Scripts.sql) trên **SSMS** sẽ không chạy hết được do **Azure SQL Database** không cho phép ghi với quyền của database **master**, phải tạo database **QuanLyHocSinh** trước rồi truy cập vào đó và chạy scripts để tạo các thành phần tương ứng

4.  Copy **Connection Strings** của `ADO.NET (SQL authentication)` tại mục **Settings** của **Azure SQL Database** và gán giá trị này cho biến **connectionString** trong file [DataProvider.cs](https://github.com/18520339/quan-ly-hoc-sinh/blob/main/DAO/DataProvider.cs)

5.  Download [bản cập nhật mới nhất](https://github.com/18520339/quan-ly-hoc-sinh/releases/latest) và chạy file **Setup.exe** để tiến hành cài đặt

6.  Đăng nhập với tài khoản Admin đã tạo trong **Azure SQL Database**, ở đây là:

    -   Tên đăng nhập: admin
    -   Mật khẩu: 123456

    => Có thể xem chi tiết các User tại file [Users.sql](https://github.com/18520339/quan-ly-hoc-sinh/blob/main/DATABASE/Users.sql)

## Tham khảo

-   [Lập trình phần mềm Quản lý quán cafe với C# Winform](https://www.howkteam.vn/course/lap-trinh-phan-mem-quan-ly-quan-cafe-voi-c-winform-24)
-   [Quickstart: Create an Azure SQL Database single database](https://docs.microsoft.com/en-us/azure/azure-sql/database/single-database-create-quickstart)
-   [Microsoft ADO.NET for SQL Server](https://docs.microsoft.com/en-us/sql/connect/ado-net/microsoft-ado-net-sql-server?view=sql-server-ver15)
-   [Tutorial: Design a relational database in Azure SQL Database using SSMS](https://docs.microsoft.com/en-us/azure/azure-sql/database/design-first-database-tutorial)
