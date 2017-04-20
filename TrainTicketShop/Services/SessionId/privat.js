/*
To RUN: casperjs test privat.js
 */

var fs = require('fs');

casper.test.begin('Test Container Tags', function suite(test) {

    casper.start("https://bilet.privatbank.ua/train/", function () {

    });

    var urls = [],
        links = [];

    casper.on('resource.requested', function (requestData, resource) {
        urls.push(decodeURI(requestData.url));
        var data = JSON.stringify(requestData);
        var match = data.match(/\\"sessionId\\":\\"([^\\]+)\\"/);
        if (match){
            fs.write('pb_session_id.json', JSON.stringify({
                sessionId: match[1],
                activeSince: +(new Date()),
                activeUntil: +(new Date()) + 60*30,
                activeSinceStr: new Date()
            }), 'w');
        }
    });

    casper.then(function () {
        var index = -1;
        var found = 0;
        for (var i = 0; i < urls.length; i++) {
            index = urls[i].indexOf('__utm.gif');
            if (index > -1)
                found = found + 1;
        }
        casper.echo('found' + found);
        test.assert(found > 0, 'Page Load Test Complete');
    });

//Emit "resource.requested" to capture the network request on link click
    casper.then(function (self) {
        var utils = require('utils');
        var x = require('casper').selectXPath;
        casper.click(x("//button[@class='tr-stations-search']"));
        //casper.click(x("//a[data-type]"));
    });

    casper.waitForResource(function testResource(resource) {
        //console.log('----->' + resource.url);
    });

    casper.run(function () {
        test.done();
    });

});