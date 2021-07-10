function EnableStep2() {
    //hide step 1
    //Swal.fire('Please login first!');
    //alert(lang.PleaseLoginFrst);
    //$('#exampleModal').modal('show'); 
    //if (ValidateCaptcha()) {
    //    ShowPopup();
    //}
    //else {
    //    //if captcah invalid
    //    alert(lang.InvalidCaptcha);
    //}
    debugger;
    ShowPopup();
}
function ShowPopup() {
    $("#dialog").dialog({
        width: "50%",
        height: 400,
        show: { effect: "explode", duration: 100 },
        resizable: false,
    });
    $('.ui-dialog-titlebar-close').text('X');
}
function HidePopup() {
    $("#dialog").dialog('close');
    $('#dialog').hide();
}
//function EnableStep2() {
//    //hide step 1
//    $('#div1').hide();
//    $('#listep1').removeAttr("class");
//    //show step2
//    $('#div2').show();
//    $('#listep2').attr("class", "active");
//}
function EnableStep3(actionName) {
    //Add quote request
    AddQuoteRequest(actionName);
}
function AddQuoteRequest(actionName) {
    var datas = new FormData($('#frminsurance').get(0));
    $.ajax({
        type: 'POST',
        url: "/Home/" + actionName + "/",
        data: datas,
        contentType: false,
        processData: false,
        success: function (data) {
            if (data == "success") {
                 alert(lang.InsuranceSubmittedQuote);
                 window.location.reload(true);
                //$('#div1').hide();
                //$('#listep1').removeAttr("class");
                //$('#div2').hide();
                //$('#listep2').removeAttr("class");
                ////show step3
                //$('#div3').show();
                //$('#listep3').attr("class", "active");
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
        async: true,
        success: function (data) {
            if (data == "success") {
                //Add request quote
                $('.header_navlink-2').attr('href', '/Account/UserLogOffs');
                $('.header_navlink-2').text(lang.logout);
                $('#userlgn').val('true');
                //hide step 1,2
                HidePopup();
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
function highlightbtn(event) {
    $('label[name="btnq"]').each(function () {
        $(this).removeAttr('class');
        $(this).attr('class', 'btn btn-default');
    });
    $(event).attr('class', 'btn btn-default active');
}
function ReloadCaptchaCode() {
    var url = "/Home/CaptchaImageReload";
    $('#divCaptcha').html("Loading Captcha....");
    $.ajax({
        url: url,
        cache: false,
        success: function (data) {
            var imag = "<img src='" + "data:image/jpg;base64,"+ data + "'/>";
            $('#divCaptcha').html(imag);
        },
        error: function (reponse) {
            alert("Error while generating captcha. Pleae refresh page and try again.");
        }

    });
}
function VerifyCaptchaCode() {
    var status = false;
    var captchacode = $("#txtCaptcha").val();
    if (captchacode != "") {
        var url = "/Home/ValidateCaptcha?Code=" + captchacode;
        $('#divVerify').html("Please wait....");
        $.ajax({
            url: url,
            cache: false,
            success: function (data) {
                if (data == "0") {
                    alert("Please enter a valid captcha");
                } else {
                    status= true;
                }
            },
            error: function (reponse) {
                alert("Error while sending detail. Pleae refresh page and try again.");
            }

        });
    } else {
        alert("Please enter captcha code.");
    }
    return status;
}