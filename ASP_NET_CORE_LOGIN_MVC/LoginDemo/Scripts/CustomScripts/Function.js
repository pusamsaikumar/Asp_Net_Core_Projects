function GetCouonOpt_InsResult(newid) {
    ////debugger
    var selVals = $("#ddlitemvalues option:selected").text();
    var dataParam = { days: selVals, Newid: newid };
    var successPar = function (data) {
        ////debugger
        ajaxRequestEnd();
        $('#shows').show();
        $('#Couponsearchresult').html(data);
    };
    ajaxCall("OptInShoppersCoupons", "POST", dataParam, "HTML", successPar);
}

function ResetQToken(id, member)
{
 //   var member = $("#lblMemeberNumber").val();
    var dataParam = { id: id, membernumber: member };
    var successPar = function (data) {
        ajaxRequestEnd();
        ////debugger;
        ChangeNewMemberNumber(member, id);
        //$('#table').hide();
        //$('#Qtoken').show();
        //$('#Qtoken').html(data);
    }
    ajaxCall("RunQtoken", "POST", dataParam, "HTML", successPar);
}


function ChangeNewMemberNumber(MemberNumber, userdetailId) {
   
    var data = { MemberNumber: MemberNumber, Userid: userdetailId };
    ajaxCall("QGetToken", "POST", data, "HTML", SuccessParam);
    sessionStorage.setItem("UserDetailId", userdetailId);
}



function GetReOptinCoupon(NewID, NewCategoryID) {
    ////debugger
    var data = { Newid: NewID, NewsCategoryId: NewCategoryID}
    var successPar = function (data) {
        ajaxRequestEnd();
        alert("success");
        
    }
    ajaxCall("OptInShoppersCouponOlder", "POST", data, "HTML", successPar)
}