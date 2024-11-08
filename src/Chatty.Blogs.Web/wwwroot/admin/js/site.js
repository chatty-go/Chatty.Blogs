// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.preloader').fadeOut(300);

$('#dropwodn_language').on('click', '.dropdown-item', function () {
    var culture = $(this).data('value');

    var form = document.createElement("form");
    form.action = '/admin/home/set-language';
    form.method = 'post';
    form.style.display = 'none';

    // 添加语言
    var input1 = document.createElement("input");
    input1.name = "culture";
    input1.value = culture;
    form.appendChild(input1);

    // 跳转URL
    var input2 = document.createElement("input");
    input2.name = "returnUrl";
    input2.value = $(this).closest('ul').data('url');
    form.appendChild(input2);

    document.body.appendChild(form);

    form.submit();
});

function handleSetLanguage() {
    alert(1)
}


function serializeObject(selector) {
    var form_data = $(selector).serializeArray();
    var map = {};
    form_data.forEach(function (item) {
        map[item.name] = item.value;
    });
    return map;
}

(function ($) {

    var $header = $('.layout-wrapper>.header');

    $(document).on('scroll', function () {
        var $this = $(this);
        var height = $(this).height();      //内容高度
        var contentH = $(window).height();  //窗口高度
        var scrollTop = $(this).scrollTop();//滚动高度

        var bootomHeight = height - scrollTop - contentH;

        console.log('scrollTop', scrollTop)

        if (scrollTop > 0) {
            $header.addClass('scrolling');
        } else {
            $header.removeClass('scrolling');
        }

    });

    $('.dropdown-scroll').niceScroll();

    $.fn.serializeObject = function () {
        var form_data = $(this).serializeArray();
        var map = {};

        form_data.forEach(function (item) {
            map[item.name] = item.value;
        });

        return map;
    };
}(jQuery));