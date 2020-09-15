//---------------------- this variable used for delete articles ---------------------//
var globalIdVariable = 0;

function deleteuser() {


  $.ajax({
    url: '/Manage/Articles/Delete',
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

//////////////////////////////// get article data and fill the ui element ////////////////////////////////////////////
function EditArticle(id) {
  debugger;
  $('#loading').removeClass('hide')

  $.ajax({
    url: '/Manage/Articles/FindToEdit',
    type: 'post',
    data: { id: id },
    success:
      function (result) {
        debugger;
        if (result.status == 200) {
          $.validator.unobtrusive.parse("#frmEditArticle");
          $('#Title').val(result.title)
          $('#Abstract').val(result.abstract)
          $('#Description').val(result.description)
         // $('#photo').attr("src", "/images/" + result.photo);
          $('#Id').val(result.id)
          //--------- show modal ---------//
          $('#showModal').trigger('click')
          //$('#modal-13').modal('show');


        //  croper_reloadjs();

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

////////////////////////////////////////////// update article  //////////////////////////////////////
$('#btnEdit').click(function (event) {
  debugger;
  event.preventDefault();
  if (!$('#frmEditArticle').valid()) {
    return false;
  }
  $('#frmEditArticle').on('submit', function () {
    $('#frmEditArticle').preventDefault();
  })

  var model = $('#frmEditArticle').serializeArray();
  $.ajax({
    url: '/Manage/Articles/Update',
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


/////////////////////// reload cope js for the image ////////////////////////////////
//function croper_reloadjs() {
//  $('#croper_js1').remove();
//  $.getScript("/Manage/bower_components/cropper/js/cropper.min.js", function () {
//    $('script:last').attr('id', 'Croper_js1');
//  });
//  $('#croper_js2').remove();
//  $.getScript("/Manage/assets/pages/cropper/croper.js", function () {
//    $('script:last').attr('id', 'croper_js2');
//  });
//}