$(document).ready(function () {
    //////debugger;
    GetAllRecordDetails();
    //Added on 18th July
  //  GetRewardsOlderAndResetOptin(false);
});

function Refresh() {
    location.reload();
}

function GetAllRecordDetails() {
    var onSucc = function (data) {
        ajaxRequestEnd();
        var GetJsonTable = "Empty";
        var GetRedJson = "Empty";
        for (var i = 0; i < 5; i++) {
            var basketslist = data.data.Table[i].BasketJSON;
            if (basketslist != null) {
                GetJsonTable = data.data.Table[i].BasketJSON.substring(0, 20) + '<a href="javascript:void(0);" onclick="myBasketJson(' + data.data.Table[i].TOTALBASKETAMOUNT + "," + data.data.Table[i].LOYALTYID + ')">Link to JSON </a>';
            }
            else {
                GetJsonTable = "Empty";
            }

            var Table = data.data.Table[i];
            var redemtionlist = data.data.Table1[i].RDJson;
            if (redemtionlist != null) {
                GetRedJson =  data.data.Table1[i].RDJson.substring(0, 20) + '<a href="javascript:void(0);" onclick="myRDJSON(' + data.data.Table1[i].MemberNumber + "," + "'" + data.data.Table1[i].Title + "'" + ')">Link to JSON </a>';
            }
            else {
                GetRedJson = "Empty";
            }

            var Table1 = data.data.Table1[i];
            var Table4 = data.data.Table4[i];
            var Table3 = data.data.Table3[i];
            var Table2 = data.data.Table2[i];
           
            if (Table != null) {
                $("#basketid").append('<tr><td>' + data.data.Table[i].TOTALBASKETAMOUNT + '</td><td>' + data.data.Table[i].LOYALTYID + '</td><td>' + data.data.Table[i].STOREID + '</td><td>' + data.data.Table[i].STORENAME + '</td><td>' + moment(data.data.Table[i].TransactionDate).format('MM/DD/YYYY HH:mm:ss') +
                    '</td><td>' + GetJsonTable+ '</td></tr>');
            }
           
            if (Table1 != null) {
                $("#redemtionid").append(
                    '<tr><td>' + moment(data.data.Table1[i].RedemptionDate).format('MM/DD/YYYY HH:mm:ss') + '</td><td>' + data.data.Table1[i].MemberNumber + '</td><td>' + data.data.Table1[i].Title + '</td><td>' + data.data.Table1[i].NewscategoryID +
                    '</td><td>' + data.data.Table1[i].PreferredStore + '</td><td>' + GetRedJson + '</td></tr>'
                );
            }
           
          

            if (Table2 != null) {
                $("#OptINId").append(
                    '<tr><td>' + moment(data.data.Table2[i].NCRImpressionDate).format('MM/DD/YYYY HH:mm:ss') + '</td><td>' + data.data.Table2[i].MemberNumber + '</td><td ' +' style="word-break: break-all">'
                    + data.data.Table2[i].Title + '</td><td>' + data.data.Table2[i].NewscategoryID + '</td><td>' + data.data.Table2[i].PreferredStore + '</td></tr>'
                );
            }
          

            if (Table3 != null) {
                $("#Rewardid").append(
                    '<tr><td>' + data.data.Table3[i].USERNAME + '</td><td>' + data.data.Table3[i].MEMBERNUMBER + '</td><td ' +' style="word-break: break-all">' + data.data.Table3[i].REWARDTITLE + '</td><td>' +
                    data.data.Table3[i].REWARDSCOUNT + '</td></tr>'
                );
            }
          
            if (Table4 != null) {
                $("#UserReg").append(
                    '<tr><td>' + data.data.Table4[i].USERNAME + '</td><td>' + data.data.Table4[i].BARCODEVALUE + '</td><td>' +
                    data.data.Table4[i].USERDETAILID + '</td><td>' + data.data.Table4[i].STOREID + '</td><td>' + data.data.Table4[i].STORENAME + '</td><td>' +
                    moment(data.data.Table4[i].SIGNUPDATE).format('MM/DD/YYYY HH:mm:ss') + '</td></tr>'
                );
            }
           
        }
    }
    ajaxCall("GetAllRecorddb", "GET", {}, "JSON", onSucc);
}

////Added on 18th July
//function GetRewardsOlderAndResetOptin(isreset) {
//    //////debugger;
//    var datareset = { isReset: isreset };
//    var onSucc = function (data) {
//        ajaxRequestEnd();
//        if (!isreset) {
//            for (var i = 0; i < 1; i++) {
//                $("#tblbodycomments").append(
//                    '<tr><td>' + " Older Than Days :" + data.data.Table[i].Older_Than_Days + '</td><td>' + ", Opt-In Count:" + data.data.Table[i].OptIn_Count + '</td></tr>'
//                );
//            }
//        }
//        else {
//            alert("Success");
//            location.reload();
//        }
//    }
//    ajaxCall("RewardOlder", "POST", datareset, "JSON", onSucc);
//}

//Added on 18th July
//function ResetOptin() {
//    ////debugger;
//    var datareset = 1;
//    var onSucc = function (data) {
//        ajaxRequestEnd();
//        alert("Success");
//        location.reload();
//    }
//    ajaxCall("/Support/ER_ReWardolder", "POST", datareset, "JSON", onSucc);
//}

//Added on 18th July to call the sinle RDJSON value
function myRDJSON(MEMBERNUMBER, Title) {
   //debugger;
    var onSucc = function (data) {
        ajaxRequestEnd();
        $("#myModalContent").html(data.data);
        $("#editModal").modal('show');
    }
    ajaxCall("/Support/GetSingleJSON", "GET", { "MEMBERNUMBER": MEMBERNUMBER, "Title": Title }, "JSON", onSucc);
}

//Added on 23th July to call the single BasketJson value
function myBasketJson(amount,MEMBERNUMBER)
{
   // ////debugger;
    var onSucc = function (data) {
        ajaxRequestEnd();
        $("#myModalContentbasket").html(data.data);
        $("#editModalBasket").modal('show');
    }
    ajaxCall("/Support/GetSinglBasketJSON", "GET", { "Amount": amount, "MEMBERNUMBER": MEMBERNUMBER }, "JSON", onSucc);
}
