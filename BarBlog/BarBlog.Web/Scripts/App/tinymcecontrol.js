tinymce.init({
    selector: 'textarea#tinyMCE',
    plugins: "image imagetools link textcolor",
    toolbar: "image link"

})

$(document).ready(function () {
    $('#savepost').on('click', function (e) {
        e.preventDefault;
        tinyMCE.triggerSave();
    });
});