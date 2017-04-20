$(document).ready(function () {
    $('.datepicker input').datepicker({
        format: "dd.mm.yyyy",
        language: "ru",
        orientation: "bottom right",
        startDate: moment().format('DD.MM.YYYY')
    });
    $('.search-city-input').on('input', function(event) {
        let input = $(this).val();
        //todo clean autocompletion on backspace
        if (input.length > 1) {
            $.get('/api/search/hints?input=' + ($(this).val()), function(data){
                let hints = [];
                if (data.stations && data.stations.length) {
                    for (let station of data.stations) {
                        hints.push(
                            `${station.name} (${data.transportGroups.filter(group => group.id == station.transportGroupId)[0].name})`
                        );
                    }
                }
                console.log(hints);
                $(event.target).autocomplete({
                    source: hints.slice(0,9),
                    delay: 0,
                    minLength: 1,
                });
            });
        }
    })
})
