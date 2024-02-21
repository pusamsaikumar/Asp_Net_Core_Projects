function GetCheckRewardOpt_InsResult() {
    ////debugger;
   // var selVal = $("#ddlItemsList option:selected").text();

    var selVals = $("#ddlitemvalues option:selected").text();
    var checkBox = document.getElementById("check_Reset");
    if (checkBox.checked == true) {
        var values = 1;
        var dataParam = { days: selVals, values: values };

        var onQueueSuc = function (result) {
            ajaxRequestEnd();
                      
            $('#dvResults').html('');
            $('#dvResults').html(result);
        }
        ajaxCall("/Support/Rewardopt_inOlder", "POST", dataParam, "HTML", onQueueSuc);
    }
    else {

        var values = 0;
        var dataParam = {  days: selVals, values: values };
        var onQueueSuc = function (result) {
            ajaxRequestEnd();

            $('#dvResults').html('');
            $('#dvResults').html(result);
        }

        ajaxCall("/Support/Rewardopt_inOlder", "GET", dataParam, "HTML", onQueueSuc);
    }

}

function SendUpdate(NCRPromotionID) {
    ////debugger;
    var dataParam = { CouponID: NCRPromotionID }
    var onQueueSuc = function (result) {
        
        ajaxRequestEnd();
        alert("Row is update");
    }
    ajaxCall("/Support/UpdateQueue", "POST", dataParam, "HTML", onQueueSuc);

}


function GetRegularCouonOpt_InsResult()
{
  //  ////debugger;
    var selVals = $("#ddlitemvalues option:selected").text();
    var checkBox = document.getElementById("check_Reset");
    if (checkBox.checked == true) {
        var values = 1;
        var dataParam = { days: selVals, values: values };

        var onQueueSuc = function (result) {
            ajaxRequestEnd();
            $('#shows').show();
            $('#dvResults').html('');
            $('#dvResults').html(result);
        }
        ajaxCall("/Support/Coupon_OptIn", "POST", dataParam, "HTML", onQueueSuc);
    }
    else {

        var values = 0;
        var dataParam = { days: selVals, values: values };
        var onQueueSuc = function (result) {
            ajaxRequestEnd();
            $('#shows').show();
            $('#dvResults').html('');
            $('#dvResults').html(result);
        }

        ajaxCall("/Support/Coupon_OptIn", "GET", dataParam, "HTML", onQueueSuc);
    }
}


//function GetCouonOpt_InsResult(newid)
//{
//    ////debugger;
//    var selVals = $("#ddlitemvalues option:selected").text();
//    var dataParam = { days: selVals, Newid: NewID };
//    var successPar = function (data) {
//        ajaxRequestEnd();
//        // $('#Shoppersearchresult').html(data);
//    };
//    ajaxCall("OptInShoppersCoupons", "POST", dataParam, "HTML", successPar);
//}


