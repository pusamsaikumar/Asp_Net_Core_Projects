$(document).ready(function () {
    //Added to bind coupon type dropdown values using api call
    var couponTypeEle = $("#selCouponType");
    var dvCouponsResEle = $('#dvCouponsSearchresult');
    couponTypeEle.empty().append('<option selected="selected" value="whatever">Loading</option>');
    var onCouponTypeSucc = function (response) {
        ajaxRequestEnd();
        if (response.status == 200) {
            couponTypeEle.empty().append('<option value="">' + "Select Coupon Type" + '</option>');
            $.each(response.data.NewsCategories, function (i, value) {
                var optionhtml = '<option value="' +
                    value.NewsCategoryID + '">' + value.NewsCategoryName + '</option>';
                couponTypeEle.append(optionhtml);
            });
        }
        else {
            alert(response.message);
        }
    }
    ajaxCall("/Coupon/CouponTypes", 'Get', {}, 'Json', onCouponTypeSucc);

    //Added to clear the search results on change of coupon type
    couponTypeEle.change(function () {
        dvCouponsResEle.html('');
    })
    //Added to display all coupons on search click
    $('#btnSearchCoupons').click(function () {
        var onCouponSucc = function (response) {
            ajaxRequestEnd();
            dvCouponsResEle.html(response);
        };
        var selCoupon = $("#selCouponType").val();
        if (selCoupon == "") {
            notify('warning', 'Please select coupon type');
        }
        else {
            ajaxCall("/Coupon/FindCouponResult", "post", { couponType: selCoupon }, 'html', onCouponSucc)
        }
    });


});




