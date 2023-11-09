// Listen for the change event of the category select box
document.getElementById('category').addEventListener('change', function () {
    // Get the values from the input and select boxes
    var keyword = document.querySelector('input[name="keyword"]').value;
    var category = document.getElementById('category').value;
    var sortOrder = document.getElementById('sortOrder').value;

    // Send data to the controller using Ajax
    $.ajax({
        url: '/Home/Product',
        type: 'GET',
        data: { keyword: keyword, category: category, sortOrder: sortOrder, page: 1 },
        success: function (result) {
            // Handle the data returned from the controller
            document.getElementById('productList').innerHTML = result;
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
});

// Listen for the change event of the sortOrder select box
document.getElementById('sortOrder').addEventListener('change', function () {
    // Get the values from the input and select boxes
    var keyword = document.querySelector('input[name="keyword"]').value;
    var category = document.getElementById('category').value;
    var sortOrder = document.getElementById('sortOrder').value;

    // Send data to the controller using Ajax
    $.ajax({
        url: '/Home/Product',
        type: 'GET',
        data: { keyword: keyword, category: category, sortOrder: sortOrder, page: 1 },
        success: function (result) {
            // Handle the data returned from the controller
            document.getElementById('productList').innerHTML = result;
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
});

// Immediately update the product list when the page loads
updateTable();