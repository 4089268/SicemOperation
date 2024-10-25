jQuery(document).ready(function() {
    if ($("#datatable").length) {
        $(document).ready(function() {
            document.mydatatable = $("#datatable").DataTable({
                lengthChange: false,
                buttons: ['copy', 'excel']
            });
            document.mydatatable.buttons().container().appendTo('#datatable_wrapper .col-md-6:eq(0)');
        });
    }
});