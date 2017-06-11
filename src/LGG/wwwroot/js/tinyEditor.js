var postEditor = (function () {
    return {
        articleEditor: function () {
            tinymce.init({
                selector: '#article-Editor',
                height: 240,
                menubar: false,
                plugins: [
                    'advlist autolink lists link image charmap print preview anchor',
                    'searchreplace visualblocks code fullscreen',
                    'insertdatetime media table contextmenu paste code'
                ],
                toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
                content_css: [
                    '//www.tinymce.com/css/codepen.min.css']
            });
        },
    }
})(postEditor || {})

var companyEditor = (function () {
    return {
        aboutEditor: function () {
            tinymce.init({
                selector: '#about-Editor',
                height: 240,
                menubar: false,
                plugins: [
                    'advlist autolink lists link image charmap print preview anchor',
                    'searchreplace visualblocks code fullscreen',
                    'insertdatetime media table contextmenu paste code'
                ],
                toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
                content_css: [
                    '//www.tinymce.com/css/codepen.min.css']
            });
        },
        privacyEditor: function () {
            tinymce.init({
                selector: '#privacy-Editor',
                height: 240,
                menubar: false,
                plugins: [
                    'advlist autolink lists link image charmap print preview anchor',
                    'searchreplace visualblocks code fullscreen',
                    'insertdatetime media table contextmenu paste code'
                ],
                toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
                content_css: [
                    '//www.tinymce.com/css/codepen.min.css']
            });
        },
        termsOfUseEditor: function () {
            tinymce.init({
                selector: '#termsOfUse-Editor',
                height: 240,
                menubar: false,
                plugins: [
                    'advlist autolink lists link image charmap print preview anchor',
                    'searchreplace visualblocks code fullscreen',
                    'insertdatetime media table contextmenu paste code'
                ],
                toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
                content_css: [
                    '//www.tinymce.com/css/codepen.min.css']
            });
        },
    }
})(companyEditor || {})