var onSaveIntoDbButtonClick = function () {
    //var h = {
    //    Name: $("#inputName").val(),
    //    City: $("#inputCity").val(),
    //    Zip: $("#inputPostalCode").val()
    //};

    //var d = JSON.parse(h);
    var person = new Object();
    person.Name = $("#inputName").val(),
        person.City = $("#inputCity2").val(),
        person.Zip = $("#inputPostalCode").val()

    $.ajax(
        {  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
            url: "api/Person/",
            type: "POST",
            async: true,
            data: JSON.stringify(person),      //without this person = null in controler
            contentType: "application/json",   //withot this the values in person are null   in controller      
            success: function () {
                $("#MyElement1").html("success");
            }
        });
}