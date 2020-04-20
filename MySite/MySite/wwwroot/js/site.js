// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function show(name, num) {
    var div = document.getElementsByClassName(name)[num]

    if (div.style.display == '')
        div.style.display = 'none'
    else
        div.style.display = ''
}

function Load(name, num) {
    alert('HELLO');
    $(name).submit(function (event) {
        // Предотвращаем обычную отправку формы
        event.preventDefault();
        $.post('/api/getComments', $(name).serialize(),
            function () {
                $('#comments').load('/api/getComments/' + num);
                $(name).reset();
            });
    });
}