$(document).ready(function () {

    document.getElementById("progress").hidden = true;

    var submitSearchCode = $("input[type=button].searchCode");
    var submitSearchDesc = $("input[type=button].searchDesc");
   
    $(submitSearchCode).on("click", function (ev) {

        console.log(1);
        event.preventDefault();
        
        var code = $("#TextCodice").val();

        formSubmit(code, "TextCodice")
        
    });

    $(submitSearchDesc).on("click", function (ev) {

        console.log(2);
        event.preventDefault();

        var desc = $("#TextDescrizione").val();

        formSubmit(desc, "TextDescrizione");

    });

});

function formSubmit(keyword, text) {

    document.getElementById("progress").hidden = false;

    $.ajax({
        url: 'Home/Keyword',
        type: 'POST',
        data: { key: keyword, filter: text },
        dataType: 'text', 
        success: function (data) {

            console.log(data);
            document.getElementById("progress").hidden = true;

        },
        error: function () {

            console.log(data);
            document.getElementById("progress").hidden = false;

        }
    });

}