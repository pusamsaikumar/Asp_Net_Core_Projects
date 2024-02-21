//Save user points only if all mandatory field values are provided
function SubmitUserPoints() {
    //////debugger;
    var RewardTypeId = $("#ddlSelectedRewardTypeId").val();//int
    var memberEle = $("#Member");
    var upc1Ele = $("#UPC1");
    var qty1Ele = $("#Qty1");
    var transAmountEle = $("#TransactionAmount");
    if (1 == RewardTypeId) {
        var arrEle = new Array(memberEle, upc1Ele, qty1Ele, transAmountEle);
    }
    else {
        var arrEle = new Array(memberEle, transAmountEle);
    }
    var errCount = CheckForErrors(arrEle);
    if (0 == errCount) {
        saveShopperPoints(memberEle, upc1Ele, qty1Ele, transAmountEle, RewardTypeId)
    }
}

//Save Shopper points when all values are provided
function saveShopperPoints(memberEle, upc1Ele, qty1Ele, transAmountEle, RewardTypeId) {
    var tAmount = transAmountEle.val();
    var upc2Ele = $("#UPC2");
    var qty2Ele = $("#Qty2");
    if (tAmount <= 10000) {
        $('#btnUserPoints').attr("disabled", true);
        var Member = memberEle.val();//string
        var UPC1 = upc1Ele.val();//string
        var UPC2 = upc2Ele.val();//string
        var Qty1 = qty1Ele.val();//int
        var Qty2 = qty2Ele.val();//int
        var data = {Member: Member, UPC1: UPC1, Qty1: Qty1, UPC2: UPC2, Qty2: Qty2, TransactionAmount: tAmount, RewardTypeId: RewardTypeId };
        var succParam = function (data) {
            ajaxRequestEnd();
            window.location.href = "FindShopper";
            alert('Shopper points are saved Successfully');
        };
        ajaxRequestStart();
        ajaxCall("SaveUserPoints","POST", data, "HTML", succParam)
    }
    else {
        alert('You can add up to max $100 worth of points at a time.');
        transAmountEle.focus();
        transAmountEle.css('border-color', 'red');
    }
}
