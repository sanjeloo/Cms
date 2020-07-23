//////////////////crate span element for show errors ////////////////////////
function createErrorElement(value) {
    var $span = $(document.createElement('span'));
    $span.addClass('text-danger').html(value);
    //    $span.add('id', 'allError');
    return $span;
}