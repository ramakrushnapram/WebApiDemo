






var serviceUrl = 'http://localhost:29481';

$('#GetAll').on('click', function () {

    debugger


    $.ajax({

        url: serviceUrl + '/Book',
        method: 'GET',
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            LoadBooks(data);
        }

    });

});


function LoadBooks(data) {
    $.each(data, function (i, item) {
        var tableRow = '<tr>' +
            '<td>' + item.id + '<td>' +
            '<td>' + item.title + '<td>' +
            '<td>' + item.author + '<td>' +
            '<td>' + item.publicationYear + '<td>' +
            '<td>' + item.isAvilable + '<td>' +
            '<td>' + item.callNumber + '<td>' +
            '</tr>';
        $('#customerTable').append(tableRow);
    });

};