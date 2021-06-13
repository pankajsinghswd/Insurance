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
                $("#insurancetype").html(this.InsuranceType);
                $("#first").html(this.FullName);
                $('#img').attr('src', this.ProfilePath == '' ? '/Content/images/avtar.png' : this.ProfilePath);
                $("#Mobile").html(this.Mobile);
                $("#Email").html(this.Email);
                $("#Interest").html(this.Interest);

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