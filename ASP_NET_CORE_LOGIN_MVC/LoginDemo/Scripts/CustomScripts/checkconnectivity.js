function onClickOfAllClientCoupons() {
    ////debugger;
    var eleChkAllCoupons = $("#chkAllCoupons");
    var checkboxesGrp = $("input[id^='chkCoupon']")
    if (eleChkAllCoupons[0].checked) {
        checkboxesGrp.each(function () {
            //this.Attr('disabled', 'true');
            $(this).attr('checked', 'true');
        });
    }
    else {
        checkboxesGrp.each(function () {
            //this.Attr('disabled', 'false');
            $(this).attr('checked', 'false');
        });
    }
}

function createCoupon() {
    ////debugger;
    var test = "test";
}

function createOptin(isCouponCreated) {
    ////debugger;
    var isCouponSuccess = isCouponCreated;
}