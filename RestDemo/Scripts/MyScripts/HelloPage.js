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

var onPersonButtonClick = function () {
    $.ajax({  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
        url: "/api/Person/GetFirstPersonByCity/get?city=" + $("#inputCity").val(),

        success: function (result) {
            $("#txtPerson").html("<strong>" + result.Name + "</strong> ");
        }
    });
}

var onPersonJsonButtonClick = function () {
    $.ajax({  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
        url: "/api/Person/GetPersonsByCityInJson/get?city=" + $("#inputCity").val(),

        success: function (result) {
            $("#txtPerson").html("<strong>" + result + "</strong> ");
        }
    });
}


$(document).ready(function ()
{
       var cuisines = ["Chinese", "Indian"];
       var sel = document.getElementById('myCombo');
       for (var i = 0; i < cuisines.length; i++) {
           var opt = document.createElement('option');
           opt.innerHTML = cuisines[i];
           opt.value = cuisines[i];
           sel.appendChild(opt);
       }
     // $.ajax({
     //     url: "/api/Values/" + $("#myinput1").val(),

     //     success: function (result)
     //     {
     //        $( "#MyElement1" ).html( "<strong>" + result + "</strong> " );
     //     }
     //});
});

