function padLeft(n, width, z) {
    z = z || '0';
    n = n + '';
    return n.length >= width ? n : new Array(width - n.length + 1).join(z) + n;
}

$(document).ready(function () {
    var orderFinishesUnix = moment($('.timer .start').text(), 'YYYY-MM-DD HH:mm:ss').add(15,'minutes').unix();
    setInterval(() => {
        var now = moment().unix();
        var difference = orderFinishesUnix - now;
        if (difference > 0) {
            $('.timer span').text(`00:${padLeft(~~(difference / 60),2)}:${padLeft(difference % 60,2)}`)
        }
        else $('.timer span').text("00:00:00");
    }, 1000);
});