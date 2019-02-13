//Fill Html table with database data
$(document).ready(function () {
    UpdatePersonTable();
});


var UpdatePersonTable = function () {
    $('#tabPersons').html("");
    $.ajax({  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
        url: "/api/Person/GetAllPersons",
        success: function (result) {
            var i;
            for (i = 0; i < result.length; i++) {
                $('#tabPersons').append('<tr><td>' + result[i].Name + '</td><td>'
                    + result[i].City + '</td><td>' + result[i].Zip + '</td><td>' + result[i].Country + '</td></tr>');
            }
        }
    });
}

var onPersonButtonClick = function () {
    $.ajax({  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
        url: "/api/Person/GetFirstPersonByCity/get?city=" + $("#inputCity").val(),

        success: function (result) {
            $("#txtPerson").html("<strong>" + result.Name + "</strong> ");
        }
    });
}

var onPersonJsonButtonClick = function () {
    $.ajax(
        {  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
            url: "/api/Person/GetPersonsByCityInJson/get?city=" + $("#inputCity").val(),

            success: function (result) {
                $("#txtPerson").html("<strong>" + result + "</strong> ");
            }
        });
}

//add data to combobox from js
$(document).ready(function () {
    var cars = ["Polonez (added from Js)", "Fiat 125p (added from Js)"];
    var sel = document.getElementById('myCombo');
    for (var i = 0; i < cars.length; i++) {
        var opt = document.createElement('option');
        opt.innerHTML = cars[i];
        opt.value = cars[i];
        sel.appendChild(opt);
    }
});


var OpenUrlInNewTab = function (url) {
    var win = window.open(url, '_blank');
    win.focus();
}

var onButtonClick = function () {
    $.ajax({  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
        url: "/api/Values/" + $("#myinput1").val(),

        success: function (result) {
            $("#MyElement1").html("<strong>" + result + "</strong> ");
        }
    });
}

var onButtonClick2 = function () {
    var person = prompt("Please enter your name", "Victor Paczo");
    $("#MyElement1").html("<strong>" + person + "</strong> ");
    window.alert("Your name is " + person);
}

var onCarClick = function () {
    window.alert("You selected: " + $("#myCombo option:selected").text());
}

