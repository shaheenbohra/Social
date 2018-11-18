var SaveNewOrder = function () {
    
    var serviceURL = '/Service/SaveNewOrder';

    var obj = {};
    obj.category = $("#orderform-category").val();
    obj.service = $("#orderform-service").val();
    obj.link = $("#field-orderform-fields-link").val();
    obj.quantity = $("#field-orderform-fields-quantity").val();
    obj.charge = $("#charge").val();
    obj.userId = $("#hdnUserId").val();
   
        $.ajax({
            type: "POST",
            url: serviceURL,
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });

        function successFunc(data, status) {
            if (data[0] == "1") {
                alert("New order saved.");
                location.reload(true);
            }
            else {
                alert("Something went wrong!")
            }
        }

        function errorFunc(err) {
            alert(err.responseText);
        }
   
}