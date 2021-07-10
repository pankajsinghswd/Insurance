function EnableStep2() {
    //hide step 1
    $('#div1').hide();
    $('#listep1').removeAttr("class");
    //show step2
    $('#div2').show();
    $('#listep2').attr("class", "active");
}
function EnableStep3(actionName) {
    //Add quote request
    AddQuoteRequest(actionName);
}
function AddQuoteRequest(actionName) {
    var datas = new FormData($('#frminsurance').get(0));
    $.ajax({
        type: 'POST',
        url: "/Home/" + actionName+"/",
        data: datas,
        contentType: false,
        processData: false,
        success: function (data) {
            if (data == "success") {
                //hide step 1,2
                $('#div1').hide();
                $('#listep1').removeAttr("class");
                $('#div2').hide();
                $('#listep2').removeAttr("class");
                //show step3
                $('#div3').show();
                $('#listep3').attr("class", "active");
            }
            if (data == "error") {
                alert(lang.Error);
            }
            return false;
        },
        error: function (ex) {
            alert(lang.Error);
            return false;
        }
    });
}
function AccountLogin(actionname) {
    //var datas = new FormData($('#frmlogin').get(0));
    var datas = {
        Email: $('#Email').val(),
        Password: $('#Password').val(),
    }
    $.ajax({
        type: 'POST',
        url: "/Account/UserLoginQuote",
        data: JSON.stringify(datas),
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (data) {
            if (data == "success") {
                //Add request quote
                $('.header_navlink-2').attr('href', '/Account/UserLogOffs');
                $('.header_navlink-2').text(lang.logout);
                AddQuoteRequest(actionname);
            }
            else if (data == "error") {
                alert(lang.Error);
            }
            else {
                alert(data);
            }
            return false;
        },
        error: function (ex) {
            alert(lang.Error);
            return false;
        }
    });
}