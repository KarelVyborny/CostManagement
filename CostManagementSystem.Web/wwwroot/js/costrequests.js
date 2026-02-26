// wwwroot/js/costrequests.js
$(function () {
    $('#reqTable').DataTable({
        order: [],
        pageLength: 25,
        scrollX: true,
        columnDefs: [{ orderable: false, targets: -1 }]
    });
});