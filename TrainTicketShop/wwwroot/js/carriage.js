let freeSeatsArr = JSON.parse($('#free-seats').text());
console.log(freeSeatsArr);
$('path').each(function (i, elem) {
    if ($(this).attr('id').match(/s[\d]+/)) {
        $(this).addClass('car-seat');
        if (freeSeatsArr.indexOf(Number($(this).attr('number'))) != -1) {
            $(this).addClass('free');
        }
    }
    else if ($(this).attr('id').match(/n[\d]+/)) {
        $(this).addClass('car-seat-caption');
        if (freeSeatsArr.indexOf(Number($(this).attr('number'))) != -1) {
            $(this).addClass('free');
        }
    }
});

let $freeSeats = $('.car-seat').filter('.free');
let $freeSeatsCaptions = $('.car-seat-caption').filter('.free');

$freeSeatsCaptions.each(function (i, elem) {
    $(this).css('fill', '#0275d8');
});

$freeSeats.hover(
    function (e) {
        $(this).css('fill', '#0275d8');
        $('#n' + $(this).attr('number')).css('fill', '#fff');
    },
    function (e) {
        $(this).css('fill', '#dedfe0');
        $('#n' + $(this).attr('number')).css('fill', '#0275d8');
    }
);

$freeSeatsCaptions.hover(
    function (e) {
        $(this).css('fill', '#fff');
        $('#s' + $(this).attr('number')).css('fill', '#0275d8');
    },
    function (e) {
        $(this).css('fill', '#0275d8');
        $('#s' + $(this).attr('number')).css('fill', '#dedfe0');
    }
)

$('.car-seat, .car-seat-caption').filter('.free').each(function (i, elem) {
    $(this).css('cursor', 'pointer');
});




$('.car-seat, .car-seat-caption').click(function (e) {
    console.log($(this).attr('number'));
}); 