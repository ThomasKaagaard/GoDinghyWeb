$(document).ready(function() {
    
    var $window = $(window);
    checkHeight($window);
    $window.resize(function () { checkHeight($window); });

});

function checkHeight($window) {
    var windowsHeight = $window.height();
    var headerHeight = $('.header').height();
    var borderBottomHeight = $('.border.hor.bot').height();
    var borderTopHeight = $('.border.hor.top').height();
    var footerHeight = $('.footer').height();
    var innerHeight = windowsHeight - (headerHeight + (borderBottomHeight + borderTopHeight));
    var contentHeight = windowsHeight - (headerHeight + borderBottomHeight + borderTopHeight + footerHeight) - 20;

    $('.frontpage .banner').css("height", innerHeight + "px");
    $('.content').css("min-height", contentHeight + "px");
}

function contactformCompleted(data) {
    var errorCode = data.statusText;
    var errorMessage = data.ErrorMessage;

    if (errorCode === "OK") {
        $(".contactform").slideUp(function () {
            $(".thanks").slideDown();
        });
    }
    else if (errorCode === "Error") {
        alert(errorMessage);
    }
}

function formCompleted(data) {
    var errorCode = data.ErrorCode;
    var errorMessage = data.ErrorMessage;
    alert(errorCode + " - " + errorMessage);
}

function test(result) {
    if (result) {
        alert("Authentication succesful. Redirecting to main intranet page.");
    }
    else {
        alert("Authentication failed. Please check your username and password.");
    }
}
