


function GetLastRedemptionStatus() {

    var dataParam = {};
    var onQueueSuc = function (jsons) {
        ajaxRequestEnd();
        $('#display').show();
        var tr;
        //   var data = JSON.parse(jsons);
        ////debugger;
        for (var i = 0; i <= 20; i++) {

            $("#Redemtionid").append(
               '<tr><td>' + moment(jsons[i].RedemptionDate).format('MM/DD/YYYY HH:mm:ss') + '</td><td>' + jsons[i].MemberNumber + '</td><td>' + jsons[i].Title + '</td><td>' + jsons[i].NewscategoryID +
               '</td><td>' + jsons[i].PreferredStore + '</td><td>' + jsons[i].RDJson.substring(0, 20) + '<a href="javascript:void(0);" onclick="myRDJSON(' + jsons[i].MemberNumber + "," + "'" + jsons[i].Title + "'" + ')">Link to JSON </a>' + '</td></td>'
           );
            //    $("#basketid").append('<tr><td>' + data.data.TOTALBASKETAMOUNT + '</td><td>' + data.data.Table[i].LOYALTYID + '</td><td>' + data.data.Table[i].STOREID + '</td><td>' + data.data.Table[i].STORENAME + '</td><td>' + moment(data.data.Table[i].TransactionDate).format('MM/DD/YYYY HH:mm:ss') +
            //        '</td><td>' + data.data.Table[i].BasketJSON.substring(0, 20) + '<a href="javascript:void(0);" onclick="myBasketJson(' + data.data.Table[i].TOTALBASKETAMOUNT + "," + data.data.Table[i].LOYALTYID + ')">Link to JSON </a>' + '</td></tr>');
            //tr = $('<tr/>');
            //tr.append("<td>" + json[i].RedemptionDate + "</td>");
            //tr.append("<td>" + json[i].MemberNumber + "</td>");
            //tr.append("<td>" + json[i].Title + "</td>");
            //tr.append("<td>" + json[i].NewscategoryID + "</td>");
            //tr.append("<td>" + json[i].PreferredStore + "</td>");
            //tr.append("<td>" + json[i].RDJson.substring(0, 20) + '<a href="javascript:void(0);" onclick="myBasketJson(' + json[i].MemberNumber + "," + json[i].Title + ')">Link to JSON </a>' + "</td>");

            //$('#Redemtionid').append(tr);
        }



    }
    ajaxCall("/Support/LastRedemption_Status", "GET", dataParam, "JSON", onQueueSuc);

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
