$(document).ready(function () {
    GetMissingQtoken();
});

function GetResetMissingQtoken(value) {
    var dataParam = { value: value };
    var onQueueSuc = function (result) {
        ajaxRequestEnd();
        GetMissingQtoken();
        //$('#display').show();
        //$('#dvResults').html('');
        //$('#dvResults').html(result);
    }
    ajaxCall("/Support/Get_Reset_MissingQtoken", "POST", dataParam, "HTML", onQueueSuc);
}

function GetMissingQtoken() {
    var value = 0;
    var dataParam = { value: value };
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
    ajaxCall("/Support/Get_Reset_MissingQtoken", "GET", dataParam, "HTML", onQueueSuc);
}