//////////////////crate span element for show errors ////////////////////////
function createErrorElement(value) {
    var $span = $(document.createElement('span'));
    $span.addClass('text-danger').html(value);
    //    $span.add('id', 'allError');
    return $span;
}
$('#NewsLetter').on('click', function () {
    debugger;
    var phone = $('#NewsLetterNumber').val();
    if (phone !== undefined && phone > 1000000000) {
        $('#loading').removeClass('hide')
        $.ajax({
            url: '/Home/NewsLetter',
            method: 'post',
            data: { Phone: phone },
            success: function (result) {
                $('#loading').addClass('hide')

                debugger;
                if (result.status == 200) {
                    notify(result.message, 'top', 'left', '', 'success', '', '');
                 
                }
                
                else if (result.status == 100) {
                    notify(result.message, 'top', 'left', '', 'danger', '', '');
                    console.log(result);
                }
                else if (result.status == 600) {
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
    }
    else {
        notify('کاربر گرامی در وارد کردن شماره تلفن خود دقت کنید', 'top', 'left', '', 'danger', '', '');
    }
})