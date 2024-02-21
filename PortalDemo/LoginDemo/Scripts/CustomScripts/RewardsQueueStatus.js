function GetCheckRewardQueueStatus() {
    var dataParam = {};
    var onQueueSuc = function (result) {
        ajaxRequestEnd();
        if (result != null) {
            $('#display').show();
            $('#dvResults').html('');
            $('#dvResults').html(result);
           // $('#lblRewardTitle').text(resulttext + ' results for :' + rewardtitle);
        }
        else {
            $('#display').show();
            $('#messages').show();
            $('#dvResults').hide();
           
        }
        
    }
    ajaxCall("/Support/RewardQueue_status", "GET", dataParam, "HTML", onQueueSuc);
}

function GetCheckRecurringQueueStatus() {
    var dataParam = {};
    var onQueueSuc = function (result) {
        ajaxRequestEnd();
        if (result != null)
        {
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
    ajaxCall("/Support/RecurringQueue_Status", "GET", dataParam, "HTML", onQueueSuc);
}