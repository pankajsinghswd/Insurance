$(document).ready(function () {

});

function View(id) {
    $.ajax({
        type: "POST",
        url: "/TherapistManage/TherapistProfile",
        data: '{id: "' + id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $(response).each(function () {
                $("#specialisttype").html(this.SpecialistType);
                $("#first").html(this.FullName);
                $('#img').attr('src', this.ProfilePath == '' ? 'avtar.png' : this.ProfilePath);
                $("#Mobile").html(this.Mobile);
                $("#Email").html(this.Email);
                $("#timings").html(this.Timing);
                $("#consultationfee").html(this.ConsultationFee);
                $("#about").html(this.About);

                $("#view").addClass("modal fade in");
                $("#view").css("display", "block");
            });
        },
        failure: function (response) {

        },
        error: function (response) {

        }
    });
}
$('#btnClose').click(function () {
    $(".ashwini").addClass("modal fade");
    $(".ashwini").css("display", "none");
});
$('#btnClosebutton').click(function () {
    $(".ashwini").addClass("modal fade");
    $(".ashwini").css("display", "none");
});

function Delete(id) {
    if (confirm("This will going to delete permanently, Once deleted it cannot be retrieved.")) {
        $.ajax({
            type: "POST",
            url: "/TherapistManage/DeleteTherapist",
            data: '{id: "' + id + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $(response).each(function () {
                    if (response == 1) {
                        alert('Therapist has been deleted successfully.');
                    }
                    setTimeout(function () {
                        if (response == 1) {
                            window.location.href = "/TherapistManage/Index";
                        }
                    }, 1000);
                });
            },
            failure: function (response) {

            },
            error: function (response) {

            }
        });
    }
    return false;
}

function Block(id, status) {
    if (confirm("Are you sure want to " + status + "?")) {
        $.ajax({
            type: "POST",
            url: "/TherapistManage/BlockToTherapist",
            data: '{id: "' + id + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $(response).each(function () {
                    if (response == 1) {
                        alert('Therapist has been ' + status + 'ed successfully.');
                    }
                    setTimeout(function () {
                        if (response == 1) {
                            window.location.href = "/TherapistManage/Index";
                        }
                    }, 1000);
                });
            },
            failure: function (response) {

            },
            error: function (response) {

            }
        });
    }
    return false;
}