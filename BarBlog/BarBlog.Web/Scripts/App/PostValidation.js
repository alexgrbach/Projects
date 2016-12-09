$(document)
.ready(function() {
        $("#postform")
            .validate({
                rules: {
                    PostTitle: {
                        required: true,
                        rangelength: [1, 50]
                    },
                    PostBody: {
                        required: true
                        
                    }
                },
                messages: {
                    PostTitle: {
                        required: "Please enter a title for this post.",
                        rangelength: "Title must be between 1 and 50 characters long."
                    },
                    PostBody: {
                        required: "You need to type something for the body!"
                    }
                }
            });
    })