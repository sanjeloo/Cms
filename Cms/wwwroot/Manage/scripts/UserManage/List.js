
function dismismodal() {
    $('#loading').addClass('hide')
    
}
function showmodal() {


    $('#large-Modal').modal('show');
    $('#loading').removeClass('hide')
}
function deleteuser(el) {
    

    $.ajax({
        url: '/Manage/UserManagers/Delete',
        type: 'post',
        data: { username: el },
        success:
            function (result) {
                
                if (result == true) {
                    $('#' + el + '').fadeOut('slow');
                }

            },
        error: function (result) {
            console.log(result)
        },

    });
}

//////////////////////////////// get user data and fill the ui element ////////////////////////////////////////////
function edituser(username) {
    debugger;
    $('#loading').removeClass('hide')

    $.ajax({
        url: '/Manage/UserManagers/FindUserToEdit',
        type: 'post',
        data: { username: username },
        success:
            function (result) {
                debugger;
                if (result.status == 200) {
                    $.validator.unobtrusive.parse("#frmEditUser");
                    $('#UserName').val(result.userName)
                    $('#FirstName').val(result.firstName)
                    $('#LastName').val(result.lastName)
                    $('#PhoneNumber').val(result.phoneNumber)
                    $('#photo').attr("src", "/images/" + result.photo);
                    if (result.gender == 1)
                        $('#gender-1').val(result.gender).add('checked')
                    else
                        $('#gender-2').val(result.gender).add('checked')

                    $('#large-Modal').modal('show');

                   
                    croper_reloadjs();
                 
                    $('#loading').addClass('hide')

                }
                else {
                    //todo need to show alert
                }
            },
        error: function (result) {
            console.log(result)
        },

    });
}

////////////////////////////////////////////// edit user  //////////////////////////////////////
$('#btnEdit').click(function (event) {
    debugger;
    event.preventDefault();
    if (!$('#frmEditUser').valid()) {
        return false;
    }
    $('#frmEditUser').on('submit', function () {
        $('#frmEditUser').preventDefault();
    })

    var model = $('#frmEditUser').serializeArray();
    $.ajax({
        url: '/Manage/UserManagers/EditUser',
        type: 'post',
        data: model,
        success: function (result) {
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
            console.log(result)
        },

    });
})


/////////////////////// reload cope js for the image ////////////////////////////////
function croper_reloadjs() {
    $('#croper_js1').remove();
    $.getScript("/Manage/bower_components/cropper/js/cropper.min.js", function () {
        $('script:last').attr('id', 'Croper_js1');
    });
    $('#croper_js2').remove();
    $.getScript("/Manage/assets/pages/cropper/croper.js", function () {
        $('script:last').attr('id', 'croper_js2');
    });
}