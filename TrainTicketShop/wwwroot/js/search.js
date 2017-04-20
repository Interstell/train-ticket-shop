$(document).ready(function () {
    let searchHints = [];
    let stations = [];
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
                searchHints = [];
                if (data.stations && data.stations.length) {
                    for (let station of data.stations) {
                        searchHints.push(
                            `${station.name} (${data.transportGroups.filter(group => group.id == station.transportGroupId)[0].name})`
                        );
                        stations.push({
                            name: station.name,
                            id: station.id
                        })
                    }
                }
                $(event.target).autocomplete({
                    source: searchHints.slice(0,9),
                    delay: 0,
                    minLength: 1,
                });
            });
        }
    })
    $('.search-box form').submit(function (e) {
        e.preventDefault();
        let fromText = $(".search-box input[name='from']").val();
        let toText = $(".search-box input[name='to']").val();

        let fromStationName = fromText.match(/([^(]+) +\([^)]+\)/)[1];
        let toStationName = toText.match(/([^(]+) +\([^)]+\)/)[1];

        let fromStationId = stations.find(st => st.name == fromStationName).id;
        let toStationId = stations.find(st => st.name == toStationName).id;

        let dateSrc = $(".search-box input[name='date']").val();
        let date = moment(dateSrc, 'DD.MM.YYYY').format('YYYY-MM-DD');

        let redirectUrl = `/search/train?from=${fromStationId}&to=${toStationId}&date=${date}`;
        window.location.href = redirectUrl;
    });
})
