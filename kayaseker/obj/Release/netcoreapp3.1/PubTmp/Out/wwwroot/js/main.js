(function ($) {

    "use strict";




})(jQuery);

$(window).load(function () {
    blogisotope = function () {
        var e, t = $(".blog-masonry").width(),
            n = Math.floor(t);
        if ($(".blog-masonry").hasClass("masonry-true") === true) {
            n = Math.floor(t * .3033);
            e = Math.floor(t * .04);
            if ($(window).width() < 1023) {
                if ($(window).width() < 768) {
                    n = Math.floor(t * 1)
                } else {
                    n = Math.floor(t * .48)
                }
            } else {
                n = Math.floor(t * .3033)
            }
        }
        return e
    };
    var r = $(".blog-masonry");
    bloggingisotope = function () {
        r.isotope({
            itemSelector: ".post-masonry",
            animationEngine: "jquery",
            masonry: {
                gutterWidth: blogisotope()
            }
        })
    };
    bloggingisotope();
    $(window).smartresize(bloggingisotope)
})
/* == Template ==*/ 
(function ($) {
    "use strict";

    
    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');

    $('.validate-form').on('submit',function(){
        var check = true;

        for(var i=0; i<input.length; i++) {
            if(validate(input[i]) == false){
                showValidate(input[i]);
                check=false;
            }
        }

        return check;
    });


    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
        if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if($(input).val().trim() == ''){
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }
    
    

})(jQuery);