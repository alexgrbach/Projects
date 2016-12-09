$(document).ready(function () {
    loadTags();
    });

function loadTags() {
    var url = '/api/Tags';
    $.getJSON(url)
        .done(function (data) {
            $.each(data,
                function (index, tag) {
                    $('#tagName').append('<span id="' + tag.TagId + '"><input type="checkbox" value="' + tag.TagName + '">' + tag.TagName + '</span>');
                });
        });
};