function DoLogin() {
    var isValid = _this.Errors.showAllMessages();
    if (!isValid) {
        return;
    }
    var data = {
        Password: _this.Password(),
        UserName: _this.UserName()
    };
    window.BaseShop.SendAjaxRequest('/umbraco/surface/loginpage/dologin', {
        data: data,
        success: _this.HandleLoginResult
    });
};
function DoLogout() {
    swal({
        type: "warning",
        title: TradePoint.Localized.Messages.SignoutTitle,
        text: TradePoint.Localized.Messages.SignoutMessage,
        showCancelButton: true,
        showConfirmButton: true,
        confirmButtonText: TradePoint.Localized.Messages.Yes,
        cancelButtonText: TradePoint.Localized.Messages.No
    }, function (isConfirm) {
        if (isConfirm) {
            window.BaseShop.SendAjaxRequest('/umbraco/surface/loginpage/dologout', {
                success: _this.HandleLoginResult
            });
        }
    });
};
function HandleLogout() {
    window.location.href = "/";
};
function HandleLoginResult(data) {
    _this.IsSuccess(data);
    if (data) {
        if (_this.IsLoginPage) {
            window.location.href = "/";
        }
        else {
            window.location.reload();
        }
    }
};