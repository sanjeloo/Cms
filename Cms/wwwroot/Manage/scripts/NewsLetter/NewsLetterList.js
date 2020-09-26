var globalIdVariable = 0;


function deleteuser() {


    $.ajax({
        url: '/Manage/NewsLetter/Delete',
        type: 'post',
        data: { id: globalIdVariable },
        success:
            function (result) {
                debugger;
                if (result == true) {
                    $('#deleteModal').modal('hide');
                    $('#' + globalIdVariable + '').fadeOut('slow');
                }
                $('#deleteModal').modal('hide');
            },
        error: function (result) {
            $('#deleteModal').modal('hide');
            console.log(result)
        },

    });
}


////////////////////////////////////////////// send news letter  //////////////////////////////////////
$('#btnSend').click(function (event) {
    debugger;
    event.preventDefault();
    if (!$('#frmSendNewsLetter').valid()) {
        return false;
    }
    $('#frmSendNewsLetter').on('submit', function () {
        $('#frmSendNewsLetter').preventDefault();
    })

    var model = $('#frmSendNewsLetter').serializeArray();
    $.ajax({
        url: '/Manage/NewsLetter/Send',
        type: 'post',
        data: model,
        success: function (result) {

            $('#closeModal').trigger('click')

            debugger;
            if (result.status == 200) {
                notify(result.message, 'top', 'left', '', 'success', '', '');
                $('#large-Modal').modal('hide');
                // $('#frmEditUser').trigger('reset');

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
            else if (result.status == 404) {
                notify(result.message, 'top', 'left', '', 'danger', '', '');
                console.log(result);
            }
            else {
                console.log(result);
            }

        },
        error: function (result) {
            $('.pname').val('');
            $('.jFiler-items').css('display', 'none');
            $('.stock').val('');
            $('.pamount').val('');
            $("#modal-13").modal('hide');
            console.log(result)
        },

    });
})
