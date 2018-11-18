var SaveNewOrder = function () {
    
    var serviceURL = '/Service/SaveNewOrder';

    var obj = {};
    obj.category = $("#CatagoryName").val();
    obj.service = $("#ddlServices").val();
    obj.link = $("#field-orderform-fields-link").val();
    obj.quantity = $("#field-orderform-fields-quantity").val();
    obj.charge = $("#charge").val();
   // obj.userId = $("#hdnUserId").val();
   
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
$(document).ready(function () {
    var category = $("#CatagoryName").val();
    alert(category);
    BindServices(category);
})
var BindServices = function (id) {
    var serviceURL = '/Service/BindServices';
    var categoryid = $("#CatagoryName").val();// $(id).val();
    alert(categoryid);
    var obj = {};
    obj.category = categoryid;
    $.ajax({
        type: "POST",
        url: serviceURL,
        data: JSON.stringify(obj),
        dataType: "json",
        contentType: "application/json",
        success: function (res) {
            $("#ddlServices").empty();
            $.each(res, function (data, value) {

                $("#ddlServices").append($("<option></option>").val(value.SWserviceId).html(value.ServiceType));
                $("#dvDescription").html(value.Description);
            })
        }

    });  
}