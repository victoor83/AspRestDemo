var onSaveIntoDbButtonClick = function () {
    $("#txtResultDB").html("no success by inserting");

    var person = new Object();
    person.Name = $("#inputName1").val(),
    person.City = $("#inputCity1").val(),
    person.Zip = $("#inputPostalCode1").val(),
    person.Country = $("#inputCountry1").val()
    $.ajax(
        {  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
            url: "api/Person/",
            type: "POST",
            async: true,
            data: JSON.stringify(person),      //without this person = null in controler
            contentType: "application/json",   //withot this the values in person are null   in controller      
            success: function ()
            {
                UpdatePersonTable();
                $("#txtInsert").html("inserting succeeded");
            }
        });
}

