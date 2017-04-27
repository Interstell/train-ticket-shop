$(document).ready(function () {
    $('.birthdate-picker input').datepicker({
        format: "dd.mm.yyyy",
        language: "ru",
        orientation: "top right"
    });


    let freeSeatsArr = JSON.parse($('#free-seats').text());
    let seatsChosenCount = 0;
    let seatsChosenArr = [];
    

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
            if (!$(this).hasClass('selected')) {
                $(this).css('fill', '#dedfe0');
                $('#n' + $(this).attr('number')).css('fill', '#0275d8');
            }
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

    $('.car-seat, .car-seat-caption').filter('.free').click(function (e) {
        let isCaption = $(this).attr('id').match(/n/) !== null;
        if (isCaption) {
            $(this).toggleClass('selected');
            $('#s' + $(this).attr('number')).addClass('selected');  //change back to ToggleClass
        }
        else { 
            $(this).toggleClass('selected');
            $('#n' + $(this).attr('number')).addClass('selected');
        }

        if ($(this).hasClass('selected') && seatsChosenArr.indexOf($(this).attr('number')) == -1) {
            $('.order-btn').css('display', 'inline-block');
            $('.email').css('display', 'block');

            let $passenger = $('#passenger' + (++seatsChosenCount));
            $passenger.find('.passenger-number .seat').text($(this).attr('number'));
            $passenger.find('.seat-input').val($(this).attr('number'));

            $passenger.find('.passenger-is-active').val(true);


            seatsChosenArr.push($(this).attr('number'));
            $passenger.css('display', 'block');
        }
        else {
            //todo ticket cancellation
        }
    });

    $('.passenger-type').change(function (e) {
        $passenger = $(this).closest('.passenger');
        $passenger.find('.additional-info').css('display', 'none');
        if (this.value == 1) { //child
            $passenger.find('.birthdate').css('display','block');
        }
        else if (this.value == 2) { //student
            $passenger.find('.student-id').css('display', 'block');
        }
    })
});
