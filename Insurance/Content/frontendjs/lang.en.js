lang = {
    Error: "Oops something went wrong !",
    logout:"Logout",
    //not in use
    SelectAll: "Select All",
    DeSelectAll: "Deselect All",
    PleaseSelectAtleastOneImage: "Please select atleast one image!",
    PleaseSelectImage: "Please select image!",
    AreYouSureWantToDelete: "Are you sure want to delete ?",
    Error: "Oops something went wrong !",
    PleaseLoginFrst: "Please login first !",
    Page: "Page",
    UserCancelledLoginOrDidNotFullyAuthorize: "User cancelled login or did not fully authorize.",
    ErrorWhileSettingUpdate: "Error while setting update!",
    YourSettingHasBeenChanged: "Your setting has been changed.",
    English_Us: "English(US)",
    Arabic: "Arabic",
    SomethingWrongPleaseTryAgainLater: "Something wrong! please try again later.",
    AlreadyExistPleaseEnterAnotherName: "Already exist! please enter another name.",
    FormNotValid: "Form not valid.",
    SomethingWentWrongWhileCreatingUser: "Something went wrong while creating user.",
    InvalidCredential: "Invalid Credential.",
    SomethingWentWrongWhileLogin: "Something went wrong while login.",
    FeedbackHasBeenSubmittedSuccessfully: "Feedback has been submitted successfully.",
    SomethingWentWrongWhileSubmitFeedback: "Something went wrong while submit feedback.",
    YourProfileyUpdatedSuccessfully: "Your profile updated successfully.",
    NoItemFound: "No  item found.",
    AreYouSureWantToSave: "Are you sure want to save ",
    EmailIdAlreadyExists: "Email id already exists",
    Country: "Country",
    City: "City",
    //User Login Messages
    NoAccountFound: "No Account found",
    IncorrectPasswordOrEmailID: "Incorrect password or email ID.",
    UserAccountlockedPleaseContact: "User account is locked, please contact Insurance Administrator",
    KindlyActivateYourAccountLogin: "Kindly activate your account to login.",
};

function countOffer() {
    var URLPATH = $("#URLPATH").val();
    //var offerid = offerid;
    //var itemname = ItemName;
    $.ajax({
        url: URLPATH + "/Home/GetUserOfferCount",
        type: "POST",
        //data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $('#CounttotalOffer').text('(' + response + ')');
        },
        error: function (er) {
            alert(lang.Error);
            return false;
        }
    });
}