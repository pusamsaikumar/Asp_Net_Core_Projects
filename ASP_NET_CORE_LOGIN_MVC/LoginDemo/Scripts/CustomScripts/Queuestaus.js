function GetPushnotificationstatus()
{
    var dataParam = {};
    var onQueueSuc = function (result) {
        ajaxRequestEnd();
        if (result != null) {
            $('#display').show();
            $('#dvResults').html('');
            $('#dvResults').html(result);
        }
        else
        {
            $('#display').show();
            $('#dvResults').hide();
            $('#messages').show();
        }
    }
    ajaxCall("/Support/PushQueue_Status", "GET", dataParam, "HTML", onQueueSuc);
}


function GetQTokenStatus()
{

    var dataParam = {};
    var onQueueSuc = function (result) {
        ajaxRequestEnd();
        $('#dvResults').html('');
        $('#dvResults').html(result);

    }
    ajaxCall("/Support/Qtokenstatus", "GET", dataParam, "HTML", onQueueSuc);

}


function GetBasketReceivedStatus() {
    var onQueueSuc = function (jsons) {
        ajaxRequestEnd();
        for (var i = 0; i < jsons.length ; i++) {
            var BasketJSON = jsons[i].BasketJSON;
            var GetJson = "Empty";
            if (BasketJSON != null)
            {

            $("#basketids tbody").append('<tr><td>' + jsons[i].TOTALBASKETAMOUNT + '</td><td>' + jsons[i].LOYALTYID + '</td><td>' + jsons[i].STOREID + '</td><td>' + jsons[i].STORENAME + '</td><td>' + moment(jsons[i].TransactionDate).format('MM/DD/YYYY HH:mm:ss') +
               '</td><td>' +jsons[i].BasketJSON.substring(0, 20) + '<a href="javascript:void(0);" onclick="myBasketJson(' + jsons[i].TOTALBASKETAMOUNT + "," + jsons[i].LOYALTYID + ')">Link to JSON </a>' + '</td></tr>');
            }
            else
            {
                $("#basketids tbody").append('<tr><td>' + jsons[i].TOTALBASKETAMOUNT + '</td><td>' + jsons[i].LOYALTYID + '</td><td>' + jsons[i].STOREID + '</td><td>' + jsons[i].STORENAME + '</td><td>' + moment(jsons[i].TransactionDate).format('MM/DD/YYYY HH:mm:ss') +
              '</td><td>' + GetJson + '</td></tr>');
            }
        }

        $('#display').show();
    }
    ajaxCall("/Support/Basketreceivedstatus", "GET", {}, "JSON", onQueueSuc);

}


function myBasketJson(amount, MEMBERNUMBER) {
    // ////debugger;
    var onSucc = function (data) {
        ajaxRequestEnd();
        $("#myModalContentbasket").html(data.data);
        $("#editModalBasket").modal('show');
    }
    ajaxCall("/Support/GetLastBasketJSON", "GET", { "Amount": amount, "MEMBERNUMBER": MEMBERNUMBER }, "JSON", onSucc);
}


function GetLastRedemptionStatus() {
    var dataParam = {};
    var onQueueSuc = function (jsons) {
        ajaxRequestEnd();
        ////debugger;
        for (var i = 0; i < jsons.length; i++) {
            var RDJSON = jsons[i].RDJson;
            var GetRDJSON="Empty"
            if (RDJSON != null)
            {
            $("#Redemtionid").append(
               '<tr><td>' + moment(jsons[i].RedemptionDate).format('MM/DD/YYYY HH:mm:ss') + '</td><td>' + jsons[i].MemberNumber + '</td><td>' + jsons[i].Title + '</td><td>' + jsons[i].NewscategoryID +
               '</td><td>' + jsons[i].PreferredStore + '</td><td>' + jsons[i].RDJson.substring(0, 20) + '<a href="javascript:void(0);" onclick="myRDJSON(' + jsons[i].MemberNumber + "," + "'" + jsons[i].Title + "'" + ')">Link to JSON </a>' + '</td></td>'
           );
            }
            else
            {
                $("#Redemtionid").append(
              '<tr><td>' + moment(jsons[i].RedemptionDate).format('MM/DD/YYYY HH:mm:ss') + '</td><td>' + jsons[i].MemberNumber + '</td><td>' + jsons[i].Title + '</td><td>' + jsons[i].NewscategoryID +
              '</td><td>' + jsons[i].PreferredStore + '</td><td>' + GetRDJSON + '</td></td>'
          );
            }          
        }
        $('#display').show();
    }
    ajaxCall("/Support/LastRedemption_Status", "GET", {}, "JSON", onQueueSuc);

}


function myRDJSON(MEMBERNUMBER, Title) {
    //////debugger;
    var onSucc = function (data) {
        ajaxRequestEnd();
        $("#myModalContent").html(data.data);
        $("#editModal").modal('show');
    }
    ajaxCall("/Support/GetSingleJSONREDEMPTION", "GET", { "MEMBERNUMBER": MEMBERNUMBER, "Title": Title }, "JSON", onSucc);
}
