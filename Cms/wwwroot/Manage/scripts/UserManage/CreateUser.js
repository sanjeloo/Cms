

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

    var model = $('#frmCreateUser').serialize();
    $.ajax({
        url: '/Manage/UserManagers/CreateUser',
        method: 'post',
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


/////////////////////////// updod image //////////////////////////
function uploadImage () {
    debugger;

    var files = new FormData();
    $.each($('#filer_input')[0].files, function (i, file) {
        files.append('file-' + i, file);
    });
    $.ajax({
        url: '/Manage/Uploader/Image',
        method: 'POST',
        data: files,
        cache: false,
        contentType: false,
        processData: false, 
        success: function (result) {
            debugger;
            if (result.status == 200) {
                notify(result.message, 'top', 'left', '', 'success', '', '');
                $('#uploadPhoto').hide();
                $('#Photo').val(result.name);
            }
            else if (result.status == 500) {
                notify(result.message, 'top', 'left', '', 'danger', '', '');
                console.log(result);
            }
            else if (result.status == 400) {
                notify(result.message, 'top', 'left', '', 'danger', '', '');
                console.log(result);
            }
            else {
                console.log(result);
            }
        },
        error: function (result) {

        }
    })
}




