// Preloader
window.addEventListener('load', function () {
    document.querySelector('body').classList.add("loaded")
});

/* Replace all SVG images with inline SVG */
$('img.svg').each((i, e) => {

    const $img = $(e);

    const imgID = $img.attr('id');

    const imgClass = $img.attr('class');

    const imgURL = $img.attr('src');

    $.get(imgURL, (data) => {
    // Get the SVG tag, ignore the rest
    let $svg = $(data).find('svg');

    // Add replaced image's ID to the new SVG
    if (typeof imgID !== 'undefined') {
        $svg = $svg.attr('id', imgID);
    }
    // Add replaced image's classes to the new SVG
    if (typeof imgClass !== 'undefined') {
        $svg = $svg.attr('class', `${imgClass} replaced-svg`);
    }

    // Remove any invalid XML tags as per http://validator.w3.org
    $svg = $svg.removeAttr('xmlns:a');

    // Check if the viewport is set, if the viewport is not set the SVG wont't scale.
    if (!$svg.attr('viewBox') && $svg.attr('height') && $svg.attr('width')) {
        $svg.attr(`viewBox 0 0  ${$svg.attr('height')} ${$svg.attr('width')}`);
    }

    // Replace image with new SVG
    $img.replaceWith($svg);
    }, 'xml');
});

/* sidebar collapse  */
$('body').on("click", function (e) {
    if (window.matchMedia('(max-width: 1151px)').matches) {
    if ($(e.target).is(".sidebar__menu-group *") == false &&
        $(e.target).is('.header-top *') == false) {
        $(".sidebar").addClass("collapsed");
        $(".contents").addClass("expanded");
        $(".footer-wrapper").addClass("expanded");
    }
    }
});

const sidebarToggle = document.querySelector(".sidebar-toggle");

function sidebarCollapse(e) {
    e.preventDefault();
    $('.overlay-dark-sidebar').toggleClass('show');
    document.querySelector(".sidebar").classList.toggle("collapsed");
    document.querySelector(".contents").classList.toggle("expanded");
    document.querySelector(".footer-wrapper").classList.toggle("expanded");
}
if (sidebarToggle) {
    sidebarToggle.addEventListener("click", sidebarCollapse);
}

$(window).on('scroll', function (e) {
    let blogContainer = document.querySelector(".blog-details"),
    shareGroup = document.querySelector(".blog-share-top");
    if (blogContainer != null && shareGroup != null) {
    window.pageYOffset <= blogContainer.offsetTop ? shareGroup.classList.remove("show") : window.pageYOffset >= blogContainer.offsetTop && window.pageYOffset <= blogContainer.offsetTop + blogContainer.clientHeight - 700 ? shareGroup.classList.add("show") : shareGroup.classList.remove("show");
    }
});

/* sidebar nav events */
$(".sidebar_nav .has-child ul").hide();
$(".sidebar_nav .has-child.open ul").show();
$(".sidebar_nav .has-child >a").on("click", function (e) {
    e.preventDefault();
    $(this).parent().next("has-child").slideUp();
    $(this).parent().parent().children(".has-child").children("ul").slideUp();
    $(this).parent().parent().children(".has-child").removeClass("open");
    if ($(this).next().is(":visible")) {
    $(this).parent().removeClass("open");
    } else {
    $(this).parent().addClass("open");
    $(this).next().slideDown();
    }
});

/* Header mobile view */
$(window)
    .bind("resize", function () {
    var screenSize = window.innerWidth;
    if ($(this).width() <= 767.98) {
        $(".navbar-right__menu").appendTo(".mobile-author-actions");
        // $(".search-form").appendTo(".mobile-search");
        $(".contents").addClass("expanded");
        $(".sidebar ").addClass("collapsed");
    } else {
        $(".navbar-right__menu").appendTo(".navbar-right");
    }

    })
    .trigger("resize");
$(window)
    .bind("resize", function () {
    var screenSize = window.innerWidth;
    if ($(this).width() > 767.98) {
        $(".dm-mail-sidebar").addClass("show");
    }
    })
    .trigger("resize");
$(window)
    .bind("resize", function () {
    var screenSize = window.innerWidth;
    if ($(this).width() <= 991) {
        $(".sidebar").addClass("collapsed");
        $(".sidebar-toggle").on("click", function () {
        $(".overlay-dark-sidebar").toggleClass("show");
        });
        $(".overlay-dark-sidebar").on("click", function () {
        $(this).removeClass("show");
        $(".sidebar").addClass("collapsed");
        });
    }
    })
    .trigger("resize");

/* Mobile Menu */
$(window)
    .bind("resize", function () {
    var screenSize = window.innerWidth;
    if ($(this).width() <= 991.98) {
        $(".menu-horizontal").appendTo(".mobile-nav-wrapper");
    }
    })
    .trigger("resize");

$(".btn-search").on("click", function () {
    $(this).toggleClass("search-active");
    $(".mobile-search").toggleClass("show");
    $(".mobile-author-actions").removeClass("show");
});

$(".kanban-items li").hover(function () {
    $(this).toggleClass("active");
});

$(".btn-author-action").on("click", function () {
    $(".mobile-author-actions").toggleClass("show");
    $(".mobile-search").removeClass("show");
    $(".btn-search").removeClass("search-active");
});

$(".menu-mob-trigger").on("click", function (e) {
    e.preventDefault();
    $(".mobile-nav-wrapper").toggleClass("show");
});

$(".nav-close").on("click", function (e) {
    e.preventDefault();
    $(".mobile-nav-wrapper").removeClass("show");
});

$('.list-thumb-gallery li a').click(function (e) {

    $('.list-thumb-gallery li a').removeClass('active');

    var $this = $(this);
    if (!$this.hasClass('active')) {
    $this.addClass('active');
    }
});