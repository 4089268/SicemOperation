jQuery(document).ready(function($) {

    var _date = new Date();

    // * display the current date
    var _dateFormat = _date.toLocaleDateString("es-MX", {month:"long", year:"numeric"});
    $("#lblDate").text(_dateFormat);

    // * add events

    $("#btnPrevMonth").click(function(){
        $("#wrapper").load("/Record/GetIncidentGrid");
    });

    $("#btnNextMonth").click(function(){

    });

});