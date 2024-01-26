
function displayCheckRewardsResults() {
   
    var selVal = $("#ddlItemsList option:selected").text();

    var selVals = $("#ddlitemvalues option:selected").text();
    var values = 0;
    var isRewardQueue= true;
    var dataParam = { selDbInstance: selVal ,days:selVals,values:values};
    var onQueueSuc = function (result) {
        ajaxRequestEnd();
        $('#findid').hide();
        $('#attid').show();
        $('#dvResults').html('');
        $('#dvResults').html(result);
    }
    ajaxCall("/Support/CheckRewardOpt_Ins", "POST", dataParam, "HTML", onQueueSuc);
}

function GetCheckRewardOpt_InsResults() {
   
    var checkBox = document.getElementById("check_Reset");
    if (checkBox.checked == true) {
        var selVal = $("#ddlItemsList option:selected").text();

        var selVals = $("#ddlitemvalues option:selected").text();
        var values = 1;
        var dataParam = { selDbInstance: selVal, days: selVals, values: values };

        var onQueueSuc = function (result) {
            ajaxRequestEnd();          
            $('#attid').hide;
            $('#findid').show();
            $('#dvResults').html('');
            $('#dvResults').html(result);
        }
        ajaxCall("/Support/CheckRewardOpt_Ins", "POST", dataParam, "HTML", onQueueSuc);
    }
    else
    {
        alert("Please Select Reset CheckBox");
    }
   
}

function GetAllQTockenStatus()
{
    var selVal = $("#ddlItemsList option:selected").text();
    var dataParam = { selDbInstance: selVal };
    var onQueueSuc = function (result) {
        ajaxRequestEnd();
     
        $('#dvResults').html('');
        $('#dvResults').html(result);
    }
    ajaxCall("/Support/GetALLQtokenStatus", "POST", dataParam, "HTML", onQueueSuc);
}

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