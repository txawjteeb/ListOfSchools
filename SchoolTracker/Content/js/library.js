// 
// 
// 

// Define your custom commands and emoji
const commands = [
    { emoji: '🍺', name: 'beer' },
];

{
    // Create custom commands
    commands.forEach(({ name, emoji }) => window.console[name] = (...args) => console.log(emoji + ' ' + args.join(', ')));
}

if( typeof console === 'object' ) {
    console.log(
        '\n' +
        'Hi there, fellow developer! Thanks for visiting.\n' +
        '— @ValleyAir\n'
    );
}

// Log to the console!
console.beer("Cheers!");

// 
// 
// 

$(document).ready(function(){
 
    // HTML escaper
    // 
    // $('code').each(function(){
    //     var code = $(this).html();
    //     $(this).text(code);
    // });
    
    // loading bar
    // 
    $('.js-show-hide-loading-bar').click(function(){
      showHideLoadingBar();
      return false;
    });

    function showHideLoadingBar(){
        if ($('.loading-bar').length === 0) { 
            $( 'body').append( "<div class='loading-bar'></div>" );
        }
        setTimeout(function(){ 
            $('.loading-bar').fadeOut(function(){
                $('.loading-bar').remove();
            });
        }, 3000);
    }
    
    // Loading spinner
    // 
    $('.js-show-hide-loading-spinner').click(function(){
      showHideLoadingSpinner();
      return false;
    });
    function showHideLoadingSpinner(){
        if ($('.loading-spinner').length === 0) { 
            $('body').append( "<div class='loading-spinner'><span></span><span></span><span></span><span></span></div><div class='loading-spinner-bg'></div>");
        }
        setTimeout(function(){ 
            $('.loading-spinner').fadeOut(
                function(){
                    $( '.loading-spinner').remove();
                    $( '.loading-spinner-bg').remove();
            });
           
        }, 3000);
    }

    // Navigation
    // 
    $(".nav__menu-icon").click(function(){
        $(".nav__collapse").toggleClass("active");
        $("#menu-switch").toggleClass("bt-times");
    });

    $("main").click(function(){
        $(".nav__collapse").removeClass("active");
        $("#menu-switch").removeClass("bt-times");
    });

});


