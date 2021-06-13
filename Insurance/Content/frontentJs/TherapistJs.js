
var today = new Date();
var dd = String(today.getDate()).padStart(2, '0');
var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
var yyyy = today.getFullYear();

today = yyyy + '/' + mm + '/' + dd;

//Today

function GetAnAppointment(type) {
    var s = '';

    $.ajax({
        type: "POST",
        url: "/Therapist/Appointment",
        data: '{date: "' + today + '",type: "' + type + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $(response).each(function () {
                s = s + '<article class="test-card text-appointment"><div class="row"><div class="col col-sm"><h3>' + this.FullName + '</h3><div class="appointment-meta"><p><span>' + this.Age + '</span> | <span>    ' + this.Gender + '    </span> | <span>    ' + this.TherapistType + '</span></p ><p class="appoint-date"><i class="fas fa-clock"></i>  ' + this.AppointmentDate + ', ' + this.Timing + '</p><p class="appoint-address"><i class="fa fa-map-marker" aria-hidden="true"></i>  ' + this.Address + '</p></div></div><div class="col col-auto"><div class="col-auto"><a href="/Therapist/AppointmentDetails/' + this.AppointmentId + '"><button class="test-gray ml-auto">View Details  <i class="fas fa-angle-right"></i></button></a></div></div></div></article>';
            });
            if (s == '') {
                s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">No Record(s) found</span></h2></div></div></div ></article >';
            }
            $('#article').html(s);
        },
        failure: function (response) {
            s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">Something went wrong!</span></h2></div></div></div ></article >';
            $('#article').html(s);
        },
        error: function (response) {
            s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">Something went wrong!</span></h2></div></div></div ></article >';
            $('#article').html(s);
        }
    });
}
function getAutoAppointment() {
    var s = '';
    $.ajax({
        type: "POST",
        url: "/Therapist/AppointmentAutoSearch",
        data: '{date: "' + today + '",type: "Compleated",keyword: "' + $('#txtSearch').val() + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $(response).each(function () {
                s = s + '<article class="test-card text-appointment"><div class="row"><div class="col col-sm"><h3>' + this.FullName + '</h3><div class="appointment-meta"><p><span>' + this.Age + '</span> | <span>    ' + this.Gender + '    </span> | <span>    ' + this.TherapistType + '</span></p ><p class="appoint-date"><i class="fas fa-clock"></i>  ' + this.AppointmentDate + ', ' + this.Timing + '</p><p class="appoint-address"><i class="fa fa-map-marker" aria-hidden="true"></i>  ' + this.Address + '</p></div></div><div class="col col-auto"><div class="col-auto"><a href="/Therapist/AppointmentDetails/' + this.AppointmentId + '"><button class="test-gray ml-auto">View Details  <i class="fas fa-angle-right"></i></button></a></div></div></div></article>';
            });
            if (s == '') {
                s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">No Record(s) found with keyword: ' + $('#txtSearch').val() + '</span></h2></div></div></div ></article >';
            }
            $('#article').html(s);
        },
        failure: function (response) {
            s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">Something went wrong!</span></h2></div></div></div ></article >';
            $('#article').html(s);
        },
        error: function (response) {
            s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">Something went wrong!</span></h2></div></div></div ></article >';
            $('#article').html(s);
        }
    });
}

//Upcomings
function GetAnUpcomingAppointment(date) {
    var s = '';

    $.ajax({
        type: "POST",
        url: "/Therapist/Appointment",
        data: '{date: "' + date + '",type: "Upcoming" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $(response).each(function () {
                s = s + '<article class="test-card text-appointment"><div class="row"><div class="col col-sm"><h3>' + this.FullName + '</h3><div class="appointment-meta"><p><span>' + this.Age + '</span> | <span>    ' + this.Gender + '    </span> | <span>    ' + this.TherapistType + '</span></p ><p class="appoint-date"><i class="fas fa-clock"></i>  ' + this.AppointmentDate + ', ' + this.Timing + '</p><p class="appoint-address"><i class="fa fa-map-marker" aria-hidden="true"></i>  ' + this.Address + '</p></div></div><div class="col col-auto"><div class="col-auto"><a href="/Therapist/AppointmentDetails/' + this.AppointmentId + '"><button class="test-gray ml-auto">View Details  <i class="fas fa-angle-right"></i></button></a></div></div></div></article>';
            });
            if (s == '') {
                s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">No Record(s) found</span></h2></div></div></div ></article >';
            }
            $('#article').html(s);
        },
        failure: function (response) {
            s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">Something went wrong!</span></h2></div></div></div ></article >';
            $('#article').html(s);
        },
        error: function (response) {
            s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">Something went wrong!</span></h2></div></div></div ></article >';
            $('#article').html(s);
        }
    });
}
//Compleated
function GetCompletedAppointment(type) {
    var s = '';

    $.ajax({
        type: "POST",
        url: "/Therapist/Appointment",
        data: '{date: "' + today + '",type: "' + type + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $(response).each(function () {
                s = s + '<article class="test-card text-appointment"><div class="row"><div class="col col-sm"><h3>' + this.FullName + '</h3><div class="appointment-meta"><p><span>' + this.Age + '</span> | <span>    ' + this.Gender + '    </span> | <span>    ' + this.TherapistType + '</span></p ><p class="appoint-date"><i class="fas fa-clock"></i>  ' + this.AppointmentDate + ', ' + this.Timing + '</p><p class="appoint-address"><i class="fa fa-map-marker" aria-hidden="true"></i>  ' + this.Address + '</p></div></div><div class="col col-auto"><div class="col-auto"><a href="/Therapist/AppointmentDetails/' + this.AppointmentId + '"><button class="test-gray ml-auto">View Details  <i class="fas fa-angle-right"></i></button></a></div></div></div></article>';
            });
            if (s == '') {
                s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">No Record(s) found</span></h2></div></div></div ></article >';
            }
            $('#article').html(s);
        },
        failure: function (response) {
            s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">Something went wrong!</span></h2></div></div></div ></article >';
            $('#article').html(s);
        },
        error: function (response) {
            s = ' <article class="test-card text-appointment"><div class="row"><div class="col col-sm"><div class="appointment-meta" style="text-align: center;"><h2><span style="color:#ff5e0052">Something went wrong!</span></h2></div></div></div ></article >';
            $('#article').html(s);
        }
    });
}
