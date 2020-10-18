GetNotification(15)

function GetNotification(num) {
    $.ajax({
        url: '/api/NotificationAPI/' + num,
        success: function (result) {
            var res = "";
            $.each(result, function (i, v) {
                res = res +
                    '<div class="row"><div class="col-md-2"><img width="50px" src="' + v.imagePath + '" /> </div><div class="col-md-10" style="margin-bottom:-20px><a href="#" class="m-card-user__email m--font-weight-300 m-link">' + v.title + '</a> <p style="font-size:13px;color:#808080;">' + v.body + ' </p><p style="font-size:11px;color:#808080;margin-top:-9px">' + v.date + '</p></div></div><div class="m-separator m-separator--primary"></div>';
            })
            if (!$.trim(result)) {
                res = '<div class="m-dropdown__header m--align-center"><span class="m-dropdown__header-title">لا يوجد تنبيهات</span></div>';
            }
            $("#list_message").html(res);
        }
    });
}



