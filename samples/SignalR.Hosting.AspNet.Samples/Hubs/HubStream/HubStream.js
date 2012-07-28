$(function () {
    var stream = $.connection.stream;

    stream.addData = function (data) {
        $('#data').append('<li>' + data + '</li>');
    };

    $.connection.hub.start();
});