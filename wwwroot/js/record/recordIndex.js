
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

function initCalendar(currentDate){
    $('#calendarRecords').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month'
        },
        defaultDate: currentDate.toISOString().split('T')[0],
        navLinks: true, // can click day/week names to navigate views
        editable: true,
        eventLimit: true, // allow "more" link when too many events
        events: [
            {
                title: 'Capturado',
                start: '2024-11-01',
            },
            {
                title: 'Capturado',
                start: '2024-11-02',
            },
            {
                title: 'Pendiente',
                start: '2024-11-09',
                backgroundColor: 'red',
            }
        ]
    });
}

async function initChartsHole(currentDate){
    
    // * fetch the data
    var currentYear = currentDate.getFullYear();
    var currentMonth = currentDate.getMonth() + 1;
    const settings = {
        async: true,
        crossDomain: true,
        url: `/record/resume-chart?year=${currentYear}&month=${currentMonth}`,
        method: 'GET',
        headers: {
            Accept: '*/*'
        }
    };
    const response = await $.ajax(settings);

    // * diplay the data
    if(!document.chart){
        document.chart = new Chartist.Line('#chartRecords', {
                labels: response.labels,
                series: response.series
            }, {
            fullWidth: true,
            chartPadding: {
                right: 5
            },
            axisY: {
            },
            stretch: false,
            low: 0
        });
    }else{
        // document.chart.data = response;
        document.chart.update(response, null, true);
    }
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
        initChartsHole(targetDate);
    });

    $("#btnNextMonth").click(function(){
        // * increment one month
        targetDate = new Date(targetDate.setMonth(targetDate.getMonth() + 1));
        loadIncidentsGrid(targetDate);
        initChartsHole(targetDate);

    });

    initCalendar(targetDate);

    initChartsHole(targetDate);

});