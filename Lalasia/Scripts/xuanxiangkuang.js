// 监听选项框的change事件
document.getElementById('category').addEventListener('change', function () {
    // 获取选项框的值
    var keyword = document.querySelector('input[name="keyword"]').value;
    var category = this.value;
    var sortOrder = document.getElementById('sortOrder').value;

    // 使用Ajax向控制器发送数据
    $.ajax({
        url: '/Home/Product',
        type: 'GET',
        data: { keyword: keyword, category: category, sortOrder: sortOrder, page: 1 },
        success: function (result) {
            document.getElementById('productList').innerHTML = result;
            //document.getElementById('table').innerHTML = result;
            // 处理从控制器返回的数据
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
});

document.getElementById('sortOrder').addEventListener('change', function () {
    // 获取选项框的值
    var keyword = document.querySelector('input[name="keyword"]').value;
    var category = document.getElementById('category').value;
    var sortOrder = this.value;

    // 使用Ajax向控制器发送数据
    $.ajax({
        url: '/Home/Product',
        type: 'GET',
        data: { keyword: keyword, category: category, sortOrder: sortOrder, page: 1 },
        success: function (result) {
            document.getElementById('productList').innerHTML = result;
            //document.getElementById('table').innerHTML = result;
            // 处理从控制器返回的数据
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
});

// 页面加载时立即更新产品列表
updateTable();






//// 监听选项框的change事件
//document.getElementById('category').addEventListener('change', function () {
//    // 获取选项框的值
//    var keyword = document.querySelector('input[name="keyword"]').value;
//    var category = this.value;
//    var sortOrder = document.getElementById('sortOrder').value;

//    // 使用Ajax向控制器发送数据
//    $.ajax({
//        url: '/Home/Product',
//        type: 'GET',
//        data: { keyword: keyword, category: category, sortOrder: sortOrder, page: 1 },
//        success: function (result) {
//            document.getElementById('table').innerHTML = result;
//            // 处理从控制器返回的数据
//        },
//        error: function (error) {
//            console.error('Error:', error);
//        }
//    });
//});

//document.getElementById('sortOrder').addEventListener('change', function () {
//    // 获取选项框的值
//    var keyword = document.querySelector('input[name="keyword"]').value;
//    var category = document.getElementById('category').value;
//    var sortOrder = this.value;

//    // 使用Ajax向控制器发送数据
//    $.ajax({
//        url: '@Url.Action("Product", "HomeController.cs")',
//        type: 'GET',
//        data: { keyword: keyword, category: category, sortOrder: sortOrder, page: 1 },
//        success: function (result) {
//            document.getElementById('productList').innerHTML = result;
//            // 处理从控制器返回的数据
//        },
//        error: function (error) {
//            console.error('Error:', error);
//        }
//    });
//});
//// 页面加载时立即更新产品列表
//updateTable();