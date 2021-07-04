lang = {
    SelectAll: "اختر الكل",
    DeSelectAll: "الغاء تحديد الكل",
    PleaseSelectAtleastOneImage: "الرجاء تحديد أتلست صورة واحدة !",
    PleaseSelectImage: "الرجاء تحديد صورة !",
    AreYouSureWantToDelete: "هل أنت متأكد تريد حذف ؟",
    Error: "تبا شيء ما حدث بشكل خاطئ !",
    PleaseLoginFrst: "يرجى الدخول أولاً !",
    Page: "صفحة",
    UserCancelledLoginOrDidNotFullyAuthorize: "إلغاء المستخدم تسجيل الدخول أو لم يأذن بالكامل .",
    ErrorWhileSettingUpdate: "خطأ أثناء إعداد التحديث !",
    YourSettingHasBeenChanged: "تم تغيير الإعداد .",
    English_Us: "الإنجليزية الولايات المتحدة)",
    Arabic: "العربية",
    SomethingWrongPleaseTryAgainLater: "هل هناك خطب ما! الرجاء معاودة المحاولة في وقت لاحق.",
    AlreadyExistPleaseEnterAnotherName: "موجود مسبقا! يرجى إدخال اسم آخر .",
    FormNotValid: "تشكيل غير صالحة .",
    SomethingWentWrongWhileCreatingUser: "حدث خطأ أثناء إنشاء المستخدم .",
    InvalidCredential: "شهادة اعتماد غير صالحة.",
    SomethingWentWrongWhileLogin: "حدث خطأ ما أثناء تسجيل الدخول.",
    FeedbackHasBeenSubmittedSuccessfully: "وقد قدمت ملاحظات بنجاح .",
    SomethingWentWrongWhileSubmitFeedback: "حدث خطأ ما أثناء تقديم التغذية الراجعة.",
    YourProfileyUpdatedSuccessfully: "ملفك الشخصي تحديث بنجاح .",
    NoItemFound: "أي بند جدت .",
    EmailIdAlreadyExists: "البريد الإلكتروني معرف مسبقا",
    Country: "بلد",
    City: "مدينة",
    //User Login Messages
    NoAccountFound: "لم يتم العثور على حساب",
    IncorrectPasswordOrEmailID: "كلمة مرور أو بريد إلكتروني غير صحيح.",
    UserAccountlockedPleaseContact: "تم تأمين حساب المستخدم ، يرجى الاتصال بمسؤول Insurance",
    KindlyActivateYourAccountLogin: "يرجى تفعيل حسابك للدخول",
    NoOffersFound: "لا يوجد عروض .",
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