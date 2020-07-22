////--------------------check username validation---------------------------
//function checkUserName() {
//    var data = $('#UserName').val();
//    $.ajax({
//        url: '/Manage/UserManagers/CheckUserName',
//        type: 'post',
//        data: { username: data },
//        success:
//            function (result) {
//                //debugger;
//                if (result == true) {
//                    var $span = $(document.createElement('span'));
//                    $span.addClass('text-danger').html('نام کاربری قبلا در سیستم وجود دارد');
//                    $span.add('id', 'UserName-error');
//                    $('*[data-valmsg-for="UserName"]').append($span);
//                   // $('<span id="UserName-error" />').addClass('text_danger').html('نام کاربری در سیستم وجود دارد'))
//                    //$('#UserName-error').val("نام کاربری در سیستم وجود دارد")
//                }
//                else {
//                    $('#UserName-error').html("")
//                }

//            },
//        error: function (result) {
//            console.log(result)
//        },

//    });
//}


