$(function () {

    $('#mainContent').on('click', '.pager a', function () {
        var url = $(this).attr('href');

        $('#mainContent').load(url);

        return false;
    });

    $(function () {
        $('.date-time-picker').datetimepicker({
            locale: 'hr'
        });
    });

});
