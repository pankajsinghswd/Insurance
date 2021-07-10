$(document).ready(function () {

});

function View(id) {
    $.ajax({
        type: "POST",
        url: "/ManageUser/UserProfile",
        data: '{id: "' + id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $(response).each(function () {
                $("#insurancetype_en").html(this.InsuranceType_en);
                $("#insurancetype_local").html(this.InsuranceType_local);
                $("#first_en").html(this.FullName_en);
                $("#first_local").html(this.FullName_local);
                $('#img').attr('src', this.ProfilePath == '' ? '/Content/images/avtar.png' : this.ProfilePath);
                $("#Mobile").html(this.Mobile);
                $("#Email").html(this.Email);
                $("#Interest_en").html(this.Interest_en);
                $("#Interest_local").html(this.Interest_local);

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
            url: "/ManageUser/DeleteUser",
            data: '{id: "' + id + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $(response).each(function () {
                    if (response == 1) {
                        alert('User has been deleted successfully.');
                    }
                    setTimeout(function () {
                        if (response == 1) {
                            window.location.href = "/ManageUser/Index";
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
            url: "/ManageUser/BlockToUser",
            data: '{id: "' + id + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $(response).each(function () {
                    if (response == 1) {
                        alert('User has been ' + status + 'ed successfully.');
                    }
                    setTimeout(function () {
                        if (response == 1) {
                            window.location.href = "/ManageUser/Index";
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

function ViewDetailHistory(id) {
    $.ajax({
        type: "POST",
        url: "/Reports/UserDetailHisotry",
        data: '{id: "' + id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            $('#divuserdetails').html(response);
            $("#view").addClass("modal fade in");
            $("#view").css("display", "block");
        },
        failure: function (response) {

        },
        error: function (response) {

        }
    });
}