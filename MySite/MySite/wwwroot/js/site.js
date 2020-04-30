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

//function Load(name, num) {
//    alert('HELLO');
//    $(name).submit(function (event) {
//        // Предотвращаем обычную отправку формы
//        event.preventDefault();
//        $.post('/api/getComments', $(name).serialize(),
//            function () {
//                $('#comments').load('/api/getComments/' + num);
//                $(name).reset();
//            });
//    });
//}

function anonimCheck(num = -1) {
    if (num == -1) {
        var chbox = document.getElementById('anonim-checkbox');
        var nickField = document.getElementById('nickname');
    }
    else {
        var chbox = document.getElementById('anonim-checkbox-' + num);
        var nickField = document.getElementById('nickname-' + num);
    }

    if (chbox.checked) {
        nickField.setAttribute('value', 'Аноним');
        nickField.style.display = 'none';
    }
    else {
        $.get('/getUser', function (data) {
            if (data == undefined)
                data = '';
            nickField.setAttribute('value', data);
            nickField.style.display = '';
        });
    }
}