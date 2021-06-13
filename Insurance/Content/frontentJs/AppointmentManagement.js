$(document).ready(function () {
    getTherapistList();
});


$('#ddlFromTime').change(function () {
    if ($('#ddlFromTime').val() != '' && $('#ddlToTime').val() != '') {
        checkFromToDateValidation($('#ddlFromTime').val(), $('#ddlToTime').val());
    }
});
$('#ddlToTime').change(function () {
    if ($('#ddlFromTime').val() != '' && $('#ddlToTime').val() != '') {
        checkFromToDateValidation($('#ddlFromTime').val(), $('#ddlToTime').val());
    }
});
$('#ddlTherapist').change(function () {
    $('#ddlFromTime').html("");
    $('#ddlToTime').html("");
    $("#ddlFromTime").append($("<option></option>").val('').html('Choose...'));
    $("#ddlToTime").append($("<option></option>").val('').html('Choose...'));

    $('#txtDate').val('');
    $('#btnSave').prop('disabled', false);
    $('#errorMsg').html('');
});

$('#btnSave').click(function () {
    if ($('#ddlTherapist').val() == '') {
        swal("Select Therapist first!");
        return false;
    }
    if ($('#txtDate').val() == '') {
        swal("Date is required!");
        return false;
    }
    if ($('#ddlFromTime').val() == '') {
        swal("Select FromTime first!");
        return false;
    }
    if ($('#ddlToTime').val() == '') {
        swal("Select ToTime first!");
        return false;
    }
    updateAppointment();
});
function DoAction(id) {
    $('#errorMsg').html('');

    $.ajax({
        url: "/api/insurance/GetPatientById",
        type: "GET",
        data: { id: id },
        contentType: "application/json; charset=utf-8",
        datatype: JSON,
        success: function (result) {
            var data = JSON.parse(result);
            clearControlPreviousVal();
            $("#first").html(data.responseData.FullName);
            $("#middle").html(data.responseData.MiddleName);
            $("#last").html(data.responseData.LastName);
            $("#gender").html(data.responseData.Gender);
            $("#dob").html(data.responseData.Age);
            $("#fatherName").html(data.responseData.FatherName);
            $("#motherName").html(data.responseData.MotherName);
            $("#address").html(data.responseData.Address + ',' + data.responseData.State + ',' + data.responseData.ZipCode);
            $("#mobile").html(data.responseData.Mobile);
            $("#email").html(data.responseData.Email);
            $("#therapistType").html(data.responseData.TherapistType);
            $("#ConsultationType").html(data.responseData.ConsultationType);
            $("#date").html(data.responseData.Date);

            $("#modal-default").addClass("modal fade in show");
            $("#modal-default").css("display", "block!important");
        },
        error: function (data) { }
    });
}
function clearControlPreviousVal() {
    $("#first").html('');
    $("#middle").html('');
    $("#last").html('');
    $("#gender").html('');
    $("#dob").html('');
    $("#fatherName").html('');
    $("#motherName").html('');
    $("#address").html('');
    $("#mobile").html('');
    $("#email").html('');
    $("#therapistType").html('');
    $("#ConsultationType").html('');
    $("#date").html('');
}

$('#btnClose').click(function () {
    clearDropDown();

    $("#modal-default").removeClass("modal fade in show");
    $("#modal-default").addClass("modal fade");
    $("#modal-default").css("display", "none!important");
});
$('#btnClosebutton').click(function () {
    clearDropDown();
    $("#modal-default").removeClass("modal fade in show");
    $("#modal-default").addClass("modal fade");
    $("#modal-default").css("display", "none");
});
function getTherapistList() {
    $.ajax({
        type: "POST",
        url: "/AppointmentManagement/TherapistList",
        //data: '{id: "' + id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $(response).each(function () {
                $("#ddlTherapist").append($("<option></option>").val(this.Value).html(this.Text));
            });
        },
        failure: function (response) {

        },
        error: function (response) {

        }
    });
}
function getTiming(id, date) {
    $.ajax({
        type: "POST",
        url: "/AppointmentManagement/Timing",
        data: '{id: "' + id + '",date: "' + date + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $('#ddlFromTime').html("");
            $('#ddlToTime').html("");
            $("#ddlFromTime").append($("<option></option>").val('').html('Choose...'));
            $("#ddlToTime").append($("<option></option>").val('').html('Choose...'));

            $(response).each(function () {
                $("#ddlFromTime").append($("<option></option>").val(this.Text).html(this.Text));
                $("#ddlToTime").append($("<option></option>").val(this.Text).html(this.Text));
            });
        },
        failure: function (response) {

        },
        error: function (response) {

        }
    });
}

$('#txtDate').change(function () {
    if ($('#ddlTherapist').val() != '') {
        getTiming($('#ddlTherapist').val(), $('#txtDate').val());
        $('#btnSave').prop('disabled', false);
        $('#errorMsg').html('');
    }
    else {
        $('#btnSave').prop('disabled', true);
        $('#errorMsg').html('Kindly select therapist first!');
        return false;
    }
});
function clearDropDown() {
    $('#ddlFromTime').html("");
    $('#ddlToTime').html("");
    $("#ddlFromTime").append($("<option></option>").val('').html('Choose...'));
    $("#ddlToTime").append($("<option></option>").val('').html('Choose...'));

    $('#txtDate').val('');
    $("#ddlTherapist")[0].selectedIndex = 0;
}
function checkFromToDateValidation(fTime, tTime) {
    $.ajax({
        type: "POST",
        url: "/AppointmentManagement/CheckTimeValidation",
        data: '{fromTime: "' + fTime + '",toTime: "' + tTime + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response == "date") {
                $('#btnSave').prop('disabled', true);
                $('#errorMsg').html('ToTime must be greater than FromTime!');
                return false;
            }
            else if (response == "minute") {
                $('#btnSave').prop('disabled', true);
                $('#errorMsg').html('The time difference must be 15 minutes!');
                return false;
            }
            else {
                $('#btnSave').prop('disabled', false);
                $('#errorMsg').html('');
            }
        },
        failure: function (response) {

        },
        error: function (response) {

        }
    });
}

