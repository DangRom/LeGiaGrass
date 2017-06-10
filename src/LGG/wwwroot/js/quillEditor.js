var companyEditor = (function () {

    return {
        aboutEditor: function () {
            var quill = new Quill('#aboutEditor', {
                bounds: '#aboutEditor',
                modules: {
                    'formula': true,
                    'syntax': true,
                    'toolbar': [
                        [{ 'font': 'Roboto' }, { 'size': [] }],
                        ['bold', 'italic', 'underline', 'strike'],
                        [{ 'color': [] }, { 'background': [] }],
                        [{ 'script': 'super' }, { 'script': 'sub' }],
                        [{ 'header': '1' }, { 'header': '2' }, 'blockquote', 'code-block'],
                        [{ 'list': 'ordered' }, { 'list': 'bullet' }, { 'indent': '-1' }, { 'indent': '+1' }],
                        ['direction', { 'align': [] }],
                        ['link', 'image', 'video', 'formula'],
                        ['clean']
                    ],
                },
                theme: 'snow'
            });
        },
        privacyEditor: function () {
            var quill = new Quill('#privacyEditor', {
                bounds: '#privacyEditor',
                modules: {
                    'formula': true,
                    'syntax': true,
                    'toolbar': [
                        [{ 'font': 'Roboto' }, { 'size': [] }],
                        ['bold', 'italic', 'underline', 'strike'],
                        [{ 'color': [] }, { 'background': [] }],
                        [{ 'script': 'super' }, { 'script': 'sub' }],
                        [{ 'header': '1' }, { 'header': '2' }, 'blockquote', 'code-block'],
                        [{ 'list': 'ordered' }, { 'list': 'bullet' }, { 'indent': '-1' }, { 'indent': '+1' }],
                        ['direction', { 'align': [] }],
                        ['link', 'image', 'video', 'formula'],
                        ['clean']
                    ],
                },
                theme: 'snow'
            });
        },
        termOfUseEditor: function () {
            var quill = new Quill('#termOfUseEditor', {
                bounds: '#termOfUseEditor',
                modules: {
                    'formula': true,
                    'syntax': true,
                    'toolbar': [
                        [{ 'font': 'Roboto' }, { 'size': [] }],
                        ['bold', 'italic', 'underline', 'strike'],
                        [{ 'color': [] }, { 'background': [] }],
                        [{ 'script': 'super' }, { 'script': 'sub' }],
                        [{ 'header': '1' }, { 'header': '2' }, 'blockquote', 'code-block'],
                        [{ 'list': 'ordered' }, { 'list': 'bullet' }, { 'indent': '-1' }, { 'indent': '+1' }],
                        ['direction', { 'align': [] }],
                        ['link', 'image', 'video', 'formula'],
                        ['clean']
                    ],
                },
                theme: 'snow'
            });
        },
    }

})(companyEditor || {})

var postEditor = (function () {

    return {
        articleEditor: function () {
            var quill = new Quill('#articleEditor', {
                bounds: '#articleEditor',
                modules: {
                    'formula': true,
                    'syntax': true,
                    'toolbar': [
                        [{ 'font': 'Roboto' }, { 'size': [] }],
                        ['bold', 'italic', 'underline', 'strike'],
                        [{ 'color': [] }, { 'background': [] }],
                        [{ 'script': 'super' }, { 'script': 'sub' }],
                        [{ 'header': '1' }, { 'header': '2' }, 'blockquote', 'code-block'],
                        [{ 'list': 'ordered' }, { 'list': 'bullet' }, { 'indent': '-1' }, { 'indent': '+1' }],
                        ['direction', { 'align': [] }],
                        ['link', 'image', 'video', 'formula'],
                        ['clean']
                    ],
                },
                theme: 'snow'
            });
        },
    }

})(postEditor || {})