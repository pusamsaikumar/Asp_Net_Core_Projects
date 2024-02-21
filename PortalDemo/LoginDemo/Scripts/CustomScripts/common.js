//function setClientSelected() {
//    //////debugger;
//    var ddlRetailerEle = $('#ddlRetailer :selected');
//    var clientSuccess = function (result) {
//        ajaxRequestEnd();
//        if (result.status == 200) {
//            $('#spRetailerSel').html(ddlRetailerEle.text());
//            var cur = window.location.pathname;
//            if (cur != "/Support/SystemOverView")
//                window.location.href = '/Support/FindShopper';
//            //else  if(cur!="/Support/SystemOverView")
//            //    window.location.href = '/Support/RewardOpt_InStatus';
//            else
//                window.location.reload();
//        }
//    };
//    ajaxCall("/Support/SetClientDetails", "post", { curClient: ddlRetailerEle.val() }, "json", clientSuccess);
//}

function setClientSelected() {
    //////debugger;
    var ddlRetailerEle = $('#ddlRetailer :selected');
    var clientSuccess = function (result) {
        ajaxRequestEnd();
        if (result.status == 200) {
            $('#spRetailerSel').html(ddlRetailerEle.text());
            var cur = window.location.pathname;

            if (cur == "/Users/Getredemption")
                window.location.href = '/Users/Getredemption';

            else if (cur != "/Support/SystemOverView")
                window.location.href = '/Support/FindShopper';


            else
                window.location.reload();
        }
    };
    ajaxCall("/Support/SetClientDetails", "post", { curClient: ddlRetailerEle.val() }, "json", clientSuccess);
}

var successParam = function (data) {
    $('#md-3d-slit-html').html('');
    $('#md-3d-slit-html').html(data);
    ajaxRequestEnd();
    $('#md-3d-slit').addClass('md-show');
}

//Ajax call 
function ajaxCall(url, type, data, datatypeParam, SuccessParam) {
    ////debugger;
    ajaxRequestStart();
    $.ajax({
        type: type,
        dataType: datatypeParam,
        data: data,
        url: url,
        cache: false,
        async: false,
        success: SuccessParam,
        error: function (jqxhr) {
            ////debugger;
            alert('Error' + jqxhr.statusText);
            ajaxRequestEnd();
        },
    });
}
function ajaxCallJsonContent(url, type, data, datatypeParam, SuccessParam) {
    ////debugger;
    ajaxRequestStart();
    $.ajax({
        type: type,
        dataType: datatypeParam,
        data: data,
        url: url,
        contentType: "application/json; charset=utf-8",
        success: SuccessParam,
        error: function (jqxhr) {
            ////debugger;
            alert('Error' + jqxhr.statusText);
            ajaxRequestEnd();
        },
    });
}
function ajaxRequestStart() {
    $('#task-progress').removeClass('md-close').addClass('md-show');
}

function ajaxRequestEnd() {
    $('#task-progress').removeClass('md-show').addClass('md-close');
}
function Close3DSlitModal() {
    $('#md-3d-slit').removeClass('md-show').addClass('md-close');
    return false;
}
//Check for mandatory field errors
function CheckForErrors(arrEle) {
    var errCount = 0;
    for (i = 0; i < arrEle.length; i++) {
        if (arrEle[i].val() == "") {
            arrEle[i].focus();
            arrEle[i].css('border-color', 'red');
            errCount = errCount + 1;
        }
        else {
            arrEle[i].css('border-color', '');
        }
    }
    return errCount;
}

//Reward stuck sub-functionality(Find Shopper screen)
function RedirectToReward(memberno, url) {
    if (url == '')
        url = '/Support/RewardStuck';
    var data = { MemberNumber: memberno, ispartial: true };
    var onsucParam = function (res) {
        ajaxRequestEnd();
        $('.content-page').html('');
        $('.content-page').html(res);
    };
    ajaxCall(url, "POST", data, "HTML", onsucParam);
}

//Added to display Add more upcs popup
function AddMoreUpc(isReward) {
    ajaxCall("/Support/AddMoreUpcs", "post", {}, 'html', successParam);
    var displayText = "";
    var displayNote = '';
    if (isReward) {
        displayText = "Reward";
        displayNote = "Note:If this reward is multi-limit reward all dependent rewards will be updated as well.";
    }
    else {
        displayText = "Coupon";
        displayNote = "Note:If this coupon is multi-limit coupon all dependent coupons will be updated as well.";
    }
    $('#dvConfirm').append(displayText);
    $('#btnAddMoreUpcs').append(displayText); 
    $('#dvNote').append(displayNote); 

}



function GetOlderCoupon(isReward)
{
    ////debugger;
    var data = { "Newid": isReward }
    var onsucParam = function (res) {
        ajaxRequestEnd();
        //$('.content-page').html('');
        //$('.content-page').html(res);
    }
    ajaxCall("/Support/OptinCoupon", "post", data, 'HTML', onsucParam);
}