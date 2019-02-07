var onSaveIntoDbButtonClick = function ()
{
    $.ajax(
        {  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
            url: "/api/Person/",
            type: "POST",
            data:
            {
                Name: $("#inputName").val(),
                City: $("#inputCity").val(),
                Zip: $("#inputPostalCode").val()
            }

        },
        success: function (result)
        {
            $("#MyElement1").html("success");
        }
    });
}

