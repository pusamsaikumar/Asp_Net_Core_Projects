var RwdSuccessParam = function (result) {
    //////debugger;
    $('#dvResGrid').css("display", "block");
    $('#dvResGrid').html('');
    $('#dvResGrid').html(result);
    ajaxRequestEnd();
    jQuery.noConflict();
}
function onRewardSel() {
    //////debugger;
    $('#dvResGrid').removeAttr("style");
    $('#dvResGrid').html('');
}

function displayGrids() {
    //////debugger;
    var memberNoEle = $('#rwdMember');
    var arrlist = new Array(memberNoEle);
    var errorCount = CheckForErrors(arrlist);
    if (0 == errorCount) {
        var memberNo = memberNoEle.val();
        var rewardIdSel = $('#ddlRewards').val();
        var chkFixGrpEle = $('#chkFixGrp');
        var chkFixImpsEle = $('#chkFixImps');
        var chkFixRedEle = $('#chkFixRed');
        var isFixGrp = setChkValues(chkFixGrpEle);
        var isFixImp = setChkValues(chkFixImpsEle);
        var isFixRed = setChkValues(chkFixRedEle);
        var dataParam = { LoyaltyId: memberNo, RewardId: rewardIdSel, FixImp: isFixImp, FixGrp: isFixGrp, FixRed: isFixRed };
        ajaxCall("/Support/ValidateRewardResults", "POST", dataParam, "HTML", RwdSuccessParam);
    }
    else {
        $('#dvResGrid').html('');
    }
}
function setChkValues(ele) {
    if (ele[0].checked) {
        return 1;
    }
    else {
        return 0;
    }
}
//On Reset redeem click
function displayGridOnReset() {
    var memberNo = $('#rwdMember').val();
    var couponId = $('#txtCouponId');
    var arr = new Array(couponId);
    var getErrors = CheckForErrors(arr);
    $('#dvResGrid').html('');
    if (getErrors == 0) {
        var chkDeleteCouponEle = $('#chkDeleteCoupon');
        var isDelCoupon = setChkValues(chkDeleteCouponEle);
        var dataParam = { LoyaltyId: memberNo, CouponId: couponId.val(), isDelete: isDelCoupon };
        ajaxCall("/Support/ResetNotRedeemed", "POST", dataParam, "html", RwdSuccessParam)
    }
}

function displayResults(rewardtitle, rewardIdSel, isValidate) {
    var action = '';
    var resulttext = '';
    var dataParam = {};
    if (isValidate) {
        resulttext = "Reward";
        action = "/Support/ValidateRewardResults";
        dataParam = { LoyaltyId: $('#lblMemberNo').text(), RewardId: rewardIdSel, FixImp: 0, FixGrp: 0, FixRed: 0 };
    }
    else {
        resulttext = "Queue";
        action = "/MobileView/QueueRewardResults";
    }
    var onRewardSuc = function (result) {
        //////debugger;
        ajaxRequestEnd();
        $('#dvRewardRes').css("display", "block");
        $('#dvRewardRes').html('');
        $('#dvRewardRes').html(result);
        $('#lblRewardTitle').text(resulttext + ' results for :' + rewardtitle);
    }
    ajaxCall(action, "POST", dataParam, "HTML", onRewardSuc);
}

function displayCheckQueueResults(screentitle) {
    var selVal = $("#ddlItemsList option:selected").text();
    var rewardQueue = false;
    if (screentitle == "Check Reward Queue Status") {
        rewardQueue = true;
    }
    else if (screentitle == "") {
        rewardQueue = true;
    }
    var dataParam = { selDbInstance: selVal, isRewardQueue: rewardQueue };
    var onQueueSuc = function (result) {
        ajaxRequestEnd();
        $('#dvResults').html('');
        $('#dvResults').html(result);
    }
    ajaxCall("/Support/CheckQueueStatus", "POST", dataParam, "HTML", onQueueSuc);
}