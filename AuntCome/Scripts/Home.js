$(document).ready(function () {
    $(".button_1").click(function () {
        $(".list_1").toggle();
    });
});
$(document).ready(function () {
    $("#result").load('/User/Create');
});