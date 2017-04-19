(function(){
    $('.datepicker input').datepicker({
        format: "dd.mm.yyyy",
        language: "ru",
        orientation: "bottom right",
        startDate: moment().format('DD.MM.YYYY')
    });
})();
