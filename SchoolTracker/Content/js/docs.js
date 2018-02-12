// Showdown Global Options
// 
showdown.setFlavor('github');

// Run Stuff after AJAX loads content
// 
$( document ).ajaxComplete(function( event, request, settings ) {

    $('pre code').each(function(i, block) {
        hljs.highlightBlock(block);
    });

    $(function() {
        var list = $('#sidebar ul');

        $("h1").each(function() {
            $(this).prepend('<a name="' + $(this).text() + '"></a>');
            $(list).append('<li><a href="#' + $(this).text() + '">' +  $(this).text() + '</a></li>');
        });
    });
});

// Navigation
// 
$(document).ready(function(){
  
    $(window).scroll(function () {
        var nav = $('.nav-inpage');
        if ($(this).scrollTop() > 0) {
            nav.addClass("fixed margin-top-10");
        } else {
            nav.removeClass("fixed margin-top-10");
        }
    });

});