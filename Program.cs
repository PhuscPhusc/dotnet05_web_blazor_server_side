//Trong Program.cs thường được chia làm 2 phần: build và use
var builder = WebApplication.CreateBuilder(args);//Đây là thư viện web application(mặc định có của netcore 9)
//Phần build - phần injection thư viện
builder.Services.AddRazorPages();//DI thư viện razor web - BẮT BUỘC
builder.Services.AddServerSideBlazor();//DI thư viện server side - BẮT BUỘC



var app = builder.Build();//Trang web sẽ được quản lí bởi thằng này



app.UseHttpsRedirection();//Dòng này có ý nghĩa rằng trang web có thể chạy trên cả domain của HTTP và HTTPS. Nếu không có dòng này thì chỉ có thể chạy trên được HTTP. => HTTPS

//Phần use - phần xài, gọi các hàm để xài thư viện <=> Tương tự cơ chế dependency injection(tiêm phụ thuộc) - Viết phía dưới app.UseHttpsRedirection();

//MapBlazorHub()
app.MapBlazorHub();//middleware của blazor để làm file chạy đầu tiên - Bật lên middleware MapBlazorHub để xác định xem file nào chạy đầu tiên

//Muốn file nào chạy đầu tiên thì cấu hình dưới đây
app.MapFallbackToPage("/_Host");//file chọn chạy đầu tiên - nếu không thích _Host là file chạy đầu tiên thì có thể thay đổi theo ý thích

app.Run();//Dòng này có tác dụng khi dùng lệnh dotnet run thì sẽ chạy đến dòng này và bật web lên => Web được start



