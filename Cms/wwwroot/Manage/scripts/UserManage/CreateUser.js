

///////////////////// add user //////////////////
$('#btnCreate').click(function (event) {
    debugger;
    event.preventDefault();
    if (!$('#frmCreateUser').valid()) {
        return false;
    }
    $('#frmCreateUser').on('submit', function () {
        $('#frmCreateUser').preventDefault();
    })
   
    var model = $('#frmCreateUser').serializeArray();
    $.ajax({
        url: '/Manage/UserManagers/CreateUser',
        type: 'post',
        data:  model ,
        success: function (result) {
            debugger;
            if (result.status == 200) {
                notify(result.message, 'top', 'left', '', 'success', '', '');
                $('#frmCreateUser').trigger('reset');
            }
            else if (result.status == 600) {
                notify(result.message, 'top', 'left', '', 'danger', '', '');
               //$.each(result.errors, function (i, error) {
               //    $.each(error.errors, function (j, item) {
               //         $('#allError').append(createErrorElement(item.errooMessage))
               //     })
               // })
                console.log(result);
            }
            else if (result.status == 100) {
                notify(result.message, 'top', 'left', '', 'danger', '', '');
                console.log(result);
            }
            else {
                console.log(result);
            }

        },
        error: function (result) {
            console.log(result)
        },

    });
})


//--------------------check username validation---------------------------
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


