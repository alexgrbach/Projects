

$(document).ready(function () {
    loadCategory();
    
});

function loadCategory() {
    var url = '/api/CategorySelector';
    $.getJSON(url)
        .done(function (data) {
            $.each(data,
                function (index, category) {
                    $('#categoryID').append('<option value="' + category.CategoryID + '">' + category.CategoryName + '</option>');
                    $('#categoryName').append('<option value="' + category.CategoryName + '">' + category.CategoryName + '</option>');
                });
        });
};