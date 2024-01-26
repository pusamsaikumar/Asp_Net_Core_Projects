
function ajaxRequestStart() {
    $('#task-progress').addClass('md-show');
}

function ajaxRequestEnd() {
    $('#task-progress').removeClass('md-show').addClass('md-close');
}

function SuccessMessageModal(msg, selector) {
    $('.alert-success, .alert-danger ').remove();
    $('<div class="alert alert-success"><button type="button" class="close"  data-dismiss="alert"></button>' + msg + '</div>')
            .prependTo($("#" + selector).find(".message").first());
}

function ErrorMessageModal(msg, selector) {
    $('.alert-danger, .alert-success').remove();
    $('<div class="alert alert-danger"><button type="button" class="close"  data-dismiss="alert"></button>' + msg + '</div>')
            .prependTo($("#" + selector).find(".message").first());
}



function UserLogOutWithModal(url, callabackurl) {
    $.ajax({
        url: url,
        type: "POST",
        success: function () {
            var tempUrl = callabackurl;
            window.location.href = tempUrl;
        },
        error: function () {
            alert('Failed to Logout');
        }
    });
}


function UpdateFormModalHtml(url, data) {
    ajaxRequestStart();
    $.ajax({
        type: 'POST',
        dataType: 'html',
        data: data,
        url: url,
        success: function (data) {
            $('#form-modal-html').html('');
            $('#form-modal-html').html(data);
            ajaxRequestEnd();
            $('#form-modal').addClass('md-show');
        },
        error: function () {
            alert('Failed');
            ajaxRequestEnd();
        },
        cache: false
    });
}

function CloseFormModal() {
    $('#form-modal').removeClass('md-show').addClass('md-close');
    return false;
}


function Update3DSlitModalHtml(url, data) {
    ajaxRequestStart();
    $.ajax({
        type: 'POST',
        dataType: 'html',
        data: data,
        url: url,
        success: function (data) {
            $('#md-3d-slit-html').html('');
            $('#md-3d-slit-html').html(data);
            ajaxRequestEnd();
            $('#md-3d-slit').addClass('md-show');
        },
        error: function () {
            alert('Failed');
            ajaxRequestEnd();
        },
        cache: false
    });
}

function Close3DSlitModal() {
    $('#md-3d-slit').removeClass('md-show').addClass('md-close');
    return false;
}

function Update3DSlitChildModalHtml(url, data) {
    ajaxRequestStart();
    $.ajax({
        type: 'POST',
        dataType: 'html',
        data: data,
        url: url,
        success: function (data) {
            $('#md-3d-slit-child-html').html('');
            $('#md-3d-slit-child-html').html(data);
            ajaxRequestEnd();
            $('#md-3d-slit-child').addClass('md-show');
        },
        error: function () {
            alert('Failed');
            ajaxRequestEnd();
        },
        cache: false
    });
}

function Close3DSlitChildModal() {
    $('#md-3d-slit-child').removeClass('md-show').addClass('md-close');
    return false;
}
