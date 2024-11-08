// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function serializeObject(selector) {
    var form_data = $(selector).serializeArray();
    var map = {};
    form_data.forEach(function (item) {
        map[item.name] = item.value;
    });
    return map;
}