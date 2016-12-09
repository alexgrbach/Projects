$(document)
.ready(function () {
    $("#pageform")
        .validate({
            rules: {
                PageTitle: {
                    required: true,
                    rangelength: [1, 50]
                },
                PageBody: {
                    required: true

                }
            },
            messages: {
                PageTitle: {
                    required: "Please enter a title for this page.",
                    rangelength: "Title must be between 1 and 50 characters long."
                },
                PageBody: {
                    required: "You need to type something for the body!"
                }
            }
        });
})