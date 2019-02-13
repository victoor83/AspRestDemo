var onDeleteButtonClick = function () {
    $("#txtResultDB").html("no success by deleting");

    $.ajax(
        {  //ajax braucht man um backend function aufzurufen um z.B. etwas in 'DB' zu speichern (mit ajax ruft man Controller)
            url: "api/Person/DeleteLastPerson",
            type: "DELETE",
            async: true,
            success: function ()
            {
                UpdatePersonTable();
                $("#txtDelete").html("deleting succeeded");
            }
        });
}