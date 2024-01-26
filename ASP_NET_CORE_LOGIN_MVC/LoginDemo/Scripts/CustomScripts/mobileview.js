function displayScreens() {
    ////debugger;
    var dealsSec = $('#dvDeals');
    var couponsSec = $('#dvAllCoupons');
    var departmentsSec = $('#dvDepartments');
    var depTable = $('#tbDepartments');
    var rewardsSec = $('#dvMyRewards');
    var selVal = $("#ddlItemsList option:selected").text();
    switch (selVal) {
        case "MyDeals":
            showHideDiv(dealsSec);
            var onsuc = function (response) {
                ajaxRequestEnd();
                dealsSec.html('');
                dealsSec.html(response);
            }
            ajaxCall("GetDealsCouponsData", 'post', { isDeals: true }, 'html', onsuc);
            break;
        case "AllCoupons":
            showHideDiv(couponsSec);
            var onsuc = function (response) {
                ajaxRequestEnd();
                couponsSec.html('');
                couponsSec.html(response);
            };
            ajaxCall("GetDealsCouponsData", 'post', { isDeals: false }, 'html', onsuc);
            break;
        case "Departments":
            showHideDiv(departmentsSec);
            LoadData(depTable, "GetDepartmentsData");
            break;
        case "MyRewards":
            showHideDiv(rewardsSec);
            var onsuc = function (response) {
                rewardsSec.html('');
                rewardsSec.html(response);
                var hdnValidate = $('tr #tdValidate');
                hdnValidate.each(function () {
                    hdnValidate.removeAttr("hidden");
                });
                $('#thValidate').removeAttr("hidden");
                ajaxRequestEnd();
            };
            ajaxCall("/Support/GetMyRewards", 'post', { isPartial: true }, 'html', onsuc);
            break;
        default:
            showHideDiv();
            break;
    }
}

function showHideDiv(showDiv) {
    var ddlDivGrp = $('#dvDropDownItems div');
    ddlDivGrp.each(function () {
        $(this).hide();
    });
    if (showDiv != null && showDiv != '')
        showDiv.show();

}

function LoadData(tableTag, URL) {
    var succParam = function (response) {
        ajaxRequestEnd();
        var tableBody = '';
        if (response.status == 200) {
            tableBody = GetDataToDisplay(response);
            tableTag.html(tableBody);
        }
        else {
            alert(response.message);
        }
    };
    ajaxCall(URL, "POST", {}, "json", succParam);
}
function GetDataToDisplay(response) {
    var departmentsRes = response.data.GetProductCategories;
    var tableData = '';
    $.each(departmentsRes, function (key, value) {
        tableData += '<tr>';
        tableData += '<td><img class="dimensions" src=" ' + value.DepartmentImageUrl + '" alt="Error in loading image"/></td>';
        tableData += '<td>' + value.NoOfCoupons + '</td>';
        tableData += '<td>' + value.ProductCategoryId + '</td>';
        tableData += '<td>' + value.ProductCategoryName + '</td>';
        tableData += '<tr>';
    });
    return tableData;
}


//QueueRewardResults