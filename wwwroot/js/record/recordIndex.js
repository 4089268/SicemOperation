
/**
 * @param {Date} currentDate 
 */
function loadIncidentsGrid(currentDate){

    var currentYear = currentDate.getFullYear();
    var currentMonth = currentDate.getMonth() + 1;

    // * load int gridview
    $("#wrapper").load("/Record/GetIncidentGrid", {
        year: currentYear,
        month: currentMonth
    });
    
    // * set the label
    var _dateFormat = currentDate.toLocaleDateString("es-MX", {month:"long", year:"numeric"});
    $("#lblDate").text(_dateFormat);


    // * upgrade the url
    const newUrl = `/Record?year=${currentYear}&month=${currentMonth}`;
    window.history.pushState({ path: newUrl }, '', newUrl);

}

jQuery(document).ready(function(){
    
    /**
     * @type {Date} targetDate - The target date to display.
     */

    // * initialy load the current month
    loadIncidentsGrid(targetDate);

    // * add events
    $("#btnPrevMonth").click(function(){
        // * decrement month
        targetDate = new Date(targetDate.setMonth(targetDate.getMonth() -1));
        loadIncidentsGrid(targetDate);
    });

    $("#btnNextMonth").click(function(){
        // * increment one month
        targetDate = new Date(targetDate.setMonth(targetDate.getMonth() + 1));
        loadIncidentsGrid(targetDate);
    });

});