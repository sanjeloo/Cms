﻿

///////////////////// add user //////////////////
$('#btnCreate').click(function (event) {
    debugger;
    $('#loading').removeClass('hide')
    event.preventDefault();
    if (!$('#frmCreateArticle').valid()) {
        return false;
    }
    $('#frmCreateArticle').on('submit', function () {
        $('#frmCreateArticle').preventDefault();
    })

    var model = $('#frmCreateArticle').serialize();
    $.ajax({
        url: '/Manage/Articles/Insert',
        method: 'post',
        data:  model ,
        success: function (result) {
            $('#loading').addClass('hide')

            debugger;
            if (result.status == 200) {
                notify(result.message, 'top', 'left', '', 'success', '', '');
                $('#frmCreateArticle').trigger('reset');
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
            $('#loading').addClass('hide')

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




