//// Các cách selector

// 1. Lấy theo id: Dùng dấu #
$("#btnXoa")

// 2. Lấy theo class: Dùng dấu .
$(".btnClass")

// 3. Theo tên thẻ HTML
$("a") // Lấy tất cả các thẻ <a>

// 4. Lấy theo giá trị thuộc tính
$("[data-iddonhang=1]")

// 5. Tổ hợp selector
// Lấy nhiều class
$(".btn.btn-add")

// Thẻ cha, thẻ con
$("#btn-box a") // Lấy tất cả thẻ <a> bên trong thẻ có id là btn-box

// 2 thẻ không phải cha con => viết dính lại không cách ra
$(".btn.btn-add")

// Hàm trong JavaScript
function HamXoa(id) {
    // Logic để xóa
    console.log("Xóa phần tử với id: " + id);
}

// GET giá trị

// 1. GET value từ input
function Submit() {
    var username = $("input[name=username]").val(); // Lấy giá trị từ input có name là username
    alert("User = " + username);
}

// 2. GET nội dung text hoặc HTML
function GetText() {
    var content = $("form").text(); // Lấy toàn bộ nội dung text bên trong form
    alert("Nội dung form: " + content);
}

// SET giá trị

// 1. SET value cho input
/*$("input[name=username]").val("Giá trị mới");*/

// 2. Append: Chèn nội dung vào cuối phần tử được chọn
// Ngược lại dùng Prepend() để chèn vào đầu
//$("ul").append("<li>Phần tử mới</li>");

// 3. after() chèn nội dung sau phần tử được chọn, ngược lại dùng before()
function Submit() {
    //Bước 1: Lấy dữ liệu trong 2 input
    var user = $("input[name= username]").val();
    var pass = $("input[name= password]").val();
    //Bước 2: Gửi dữ liệu lênn server: Ajax
    var json = {
        username: user,
        password:pass

    }
    $.ajax({
        url: '/Admin/Home/DangNhapJS', // Make sure the URL starts with '/'
        type: "POST",
        data: json,
        dataType: 'JSON',
        success: function (res) {
            // Handle response from the server
            if (!res.ketqua) { // Check if the login failed
                $("#error").remove(); // Remove any existing error message
                $("form").append("<p id='error' style='color: red;'>" + res.thongbao + "</p>"); // Add error message
            } else {
                location.href = "/Admin/Home"; // Redirect on success
            }
        },
        error: function () {
            // Optional: Handle server or network errors here
            alert("Có lỗi xảy ra khi gửi yêu cầu. Vui lòng thử lại.");
        }
    });

   
}
$('input[name=password]').keypress(function (event) {

    if (event.which === 13) { // Enter key
        Submit()

    }
});