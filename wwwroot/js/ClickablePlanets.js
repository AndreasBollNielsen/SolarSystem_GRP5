$('div[name="planet"]').click(function () {

    var id = this.id;
   
    //alert(id);

    $.ajax({
        type: "POST",
        url: "./test",
        data: { id: id},
        dataType: "text"
       
    });
});



