$('#datepicker.input-daterange').datepicker({
    todayBtn: "linked",
    container: '#searchDrawer',
    todayHighlight: true
});

$(document).ready(function () {
    loadTags();
});

function loadTags() {
    var url = '/api/Tags';
    $.getJSON(url)
        .done(function (data) {
            $.each(data,
                function (index, tag) {
                    $('#tagName').append('<span id="' + tag.TagID + '"><input type="checkbox" name="' + tag.TagName + '" ng-model="tag.key" ng-true-value="' + tag.TagName + '" value="' + tag.TagName + '">' + tag.TagName + '</span>');
                });
        });
};