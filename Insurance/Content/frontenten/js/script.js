    

    var page={ 
        init:function(){
            page.insertBars();
            page.insertMetaMedia();
            $(document).off('click').on('click','.burger',function(){

                $('.header_nav').toggleClass('show_menu');
                $(this).toggleClass('close_menu');
            });
        },
        insertBars : function(){
            $('.header_menu').before("<div class='burger fa fa-bars'></div>");
        },
        insertMetaMedia : function(){
            $('head').append("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
        }
    }
    
    setTimeout(function(){
        page.init();
    }, 500);
    

