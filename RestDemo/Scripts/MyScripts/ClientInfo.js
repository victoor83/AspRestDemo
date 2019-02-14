var getClientData = function () {
    $('#lstClient').html("");
    $.ajax({  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
        url: "/api/Client/GetClientData",
        success: function (data) {
            $('#lstClient').append('<li>' + data[0] + '</li>');
            $('#lstClient').append('<li>' + data[1] + '</li>');            
        }
    });
}

$(document).ready(function () {
    $.ajax({  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
        url: "/api/Client/GetClientData",
        success: function (data) {
            $("#txtWelcome").html("Hello " + data[2] + "!!!");
        }
    });
});