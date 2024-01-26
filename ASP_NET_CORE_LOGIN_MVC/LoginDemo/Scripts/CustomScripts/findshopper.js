var SuccessParam = function (data) {
    $('#md-3d-slit-html').html('');
    $('#md-3d-slit-html').html(data);
    ajaxRequestEnd();
    $('#md-3d-slit').addClass('md-show');
}
//Search shopper details based on user data
function SearchShopper() {
    alert("jelo");
    //////debugger;
    var UserName = $("#UserName").val();
    var Member = $("#Member").val();
    var dataParam = { UserName: UserName, MemberNumber: Member };
    var successPar = function (data) {
        ajaxRequestEnd();
        $('#Shoppersearchresult').html(data);
    };
    ajaxCall("FindShopperSearchResult", "POST", dataParam, "HTML", successPar);
}
//Reset Find Shopper UI form 
function Reset() {
    window.location.href = "FindShopper";
}

//Change Password sub-functionality(Find Shopper)
function EmailNewPin(username) {
    if (confirm("An Email will be sent to your registered E-mail. Please Confirm?") == true) {
        var data = { UserName: username };
        var sucPar = function (response) {
            ajaxRequestEnd();
            if (response == '' || response == null)
                response = "New PIN is sent to your Email"
            alert(response);
        }
        ajaxCall("EmailNewPin", "POST", data, "HTML", sucPar);
    }
    else {
        return false;
    }

}
function ChangePasswordSubmit() {
    var userdetailId = sessionStorage.getItem("UserDetailId");
    var data = { UserdetailId: userdetailId, NewPassword: $('#txtNewPwd').val() };
    ajaxCall("ChangePasswordSubmit", "GET", data, "text", SuccessParam);
}

//Change Username sub-functionality(Find Shopper)
function ChangeUserName(UserName, userdetailId) {
    //////debugger;
    var data = { UserName: UserName };
    ajaxCall("ChangeUserName", "POST", data, "HTML", SuccessParam);
    sessionStorage.setItem("UserDetailId", userdetailId);
}


function ChangeNewMemberNumber(MemberNumber, userdetailId)
{
  
    var data = { MemberNumber: MemberNumber, Userid: userdetailId };
    ajaxCall("QGetToken", "POST", data, "HTML", SuccessParam);
    sessionStorage.setItem("UserDetailId", userdetailId);
}






//OnSubmission of change password
function ChangeUserNameSubmit() {
    //////debugger;
    var UserNamEle = $('#lblUserName');
    var NewUserNameEle = $('#lblNewUserName');
    var ConfirmNewUserEle = $('#lblConfirmNewUser');
    var arrList = new Array(UserNamEle, NewUserNameEle, ConfirmNewUserEle);
    var errCount = CheckForErrors(arrList);
    if (0 == errCount) {
        var NewUserName = NewUserNameEle.val();
        if (ConfirmNewUserEle.val() != NewUserName) {
            $('#lblError').html('The new username and confirm new username do not match.');
        }
        else {
            $('#lblError').html('');
            var userdetailId = sessionStorage.getItem("UserDetailId");
            var data = { Userdetailid: userdetailId, newUserName: NewUserName };
            var successPar = function (res) {
                ajaxRequestEnd();
                alert("UserName is successfully changed");
                window.location.href = "FindShopper";
            }
            ajaxCall("ChangeUserNameSubmit", "POST", data, "HTML", successPar);
        }
    }
}
//Add Points sub-functionality(Find Shopper screen)
function ViewPointsDetails(MemberNumber) {
    var data = { MemberNumber: MemberNumber };
    ajaxCall("ViewAddPointsDetails", "POST", data, "HTML", SuccessParam);
}


function NewMemberNumberSubmit()
{
    ////debugger;
    var UserName = $("#lblMemeberNumber").val();
    var Member = $("#lblNewMemberNumber").val();
    var dataParam = { currentMember: UserName, newMember: Member };
    var successPar = function (res) {
        ajaxRequestEnd();
    }

    ajaxCall("ManuallyEnterNewMemberNumbar", "POST", dataParam, "HTML", successPar);
}


//function GetQtokenResult(MemberNumber, userdetailId) {
//    ////debugger;
//    var data = { MemberNumber: MemberNumber };
//    ajaxCall("QGetToken", "POST", data, "HTML", SuccessParam);
//    sessionStorage.setItem("UserDetailId", userdetailId);

//}

