lang = {
    Error: "تبا شيء ما حدث بشكل خاطئ !",
    logout:"تسجيل خروج",

    //not in use
    SelectAll: "اختر الكل",
    DeSelectAll: "الغاء تحديد الكل",
    PleaseSelectAtleastOneImage: "الرجاء تحديد أتلست صورة واحدة !",
    PleaseSelectImage: "الرجاء تحديد صورة !",
    AreYouSureWantToDelete: "هل أنت متأكد تريد حذف ؟",
   
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
    InvalidCaptcha: "إجابة captcha غير صالحة",
    InsuranceSubmittedQuote:"قدمت عروض الأسعار الخاصة بك بنجاح. سوف نصل إليك قريبا.",
};
var wind = $(window).width();
if (wind <= 767) {
    var hdr = $('.banner_1 .header_tabinner').clone();
    $(hdr).insertBefore('.newForm').addClass('cln');
    $('.banner_1 .header_tabinner').hide();
}