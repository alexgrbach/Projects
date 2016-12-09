//if localStorage has a key theme
if (localStorage.theme) {
    //read the key and change the attribute href on the link with a class of theme
    $("link.theme").attr("href", localStorage.theme);
};

//when the document is done loading
$(document).ready(function () {
    //run these functions
    loadPages();
    ThemePicker();
});

function loadPages() {
    var uri = '/api/StaticPages';
    //get data
    $.getJSON(uri)
        //spawn an anonymonus function and pass in the data after its done loading
        .done(function (data) {
            //foreach element in data 
            $.each(data,
                function (index, pages) {
                    //build the html string 
                    $('<li><a href="/StaticPage/View/' + pages.PageID + '">' + pages.PageTitle + '</a></li>')
                        //and append it to the element with the id of staticPageDropdown
                        .appendTo($('#staticPageDropdown'));
                });
        });
};



function ThemePicker() {
    //when this element is clicked
    $("#themeSwitcher li a").click(function () {
        //read the atribute rel from the click
        //and change the attribute href on the link with a class of theme
        $("link.theme").attr("href", $(this).attr('rel'));
        //set the localStorage key theme to the value of the rel from the click
        localStorage.theme = $(this).attr('rel');      
        //hide the divs with the classes container and body-content
        //and then fade it
        $('#post_body').hide().fadeIn();
        return false;
    });
};