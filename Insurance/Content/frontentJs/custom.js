this.Element && function(ElementPrototype) {
  ElementPrototype.matches = ElementPrototype.matches ||
  ElementPrototype.matchesSelector ||
  ElementPrototype.webkitMatchesSelector ||
  ElementPrototype.msMatchesSelector ||
  function(selector) {
      var node = this, nodes = (node.parentNode || node.document).querySelectorAll(selector), i = -1;
      while (nodes[++i] && nodes[i] != node);
      return !!nodes[i];
  }
}(Element.prototype);
// closest polyfill
this.Element && function(ElementPrototype) {
  ElementPrototype.closest = ElementPrototype.closest ||
  function(selector) {
      var el = this;
      while (el.matches && !el.matches(selector)) el = el.parentNode;
      return el.matches ? el : null;
  }
}(Element.prototype);

document.addEventListener('click',function(event){
  var drop__down = document.querySelectorAll('.drop__down');  
  if(!event.target.classList.contains('show__dropdown') && event.target.closest('.drop__down') == null  ){
     for (var i = drop__down.length - 1; i >= 0; i--) {
       drop__down[i].classList.add('hide');
      
     } 
     document.querySelector('body').style.overflow = 'auto'; 	
  }
  else if(event.target.classList.contains('show__dropdown')){   	
     for (var i = drop__down.length - 1; i >= 0; i--) {
       drop__down[i].classList.add('hide');
     }
   event.target.nextElementSibling.classList.remove('hide');	
   document.querySelector('body').style.overflow = 'hidden'; 
  }  
});











var stickyHeader = document.querySelector('.top-header');
var hamburger = document.querySelector('.navbar-btn');
var menumob  = document.querySelector('.menumob');
var menumobtext  = document.querySelector('.btn-container');
if(hamburger!==null){
hamburger.addEventListener('click', function(){
  this.classList.toggle('in'); 
 menumob.classList.toggle('show'); 
 menumobtext.classList.toggle('show');
});
}


var  menumob__accordhead = document.querySelector('.menumob__accord--head');
var  menumob__accordlinks = document.querySelector('.menumob__accordlinks ');

if(menumob__accordhead!==null){
  menumob__accordhead.addEventListener('click',function(){
      menumob__accordlinks.classList.toggle('hide');
      this.classList.toggle('active');
  });
}



var stickyHeaderHeight = stickyHeader.clientHeight;
var textcontainer = document.querySelector('.tests-container');
var Userpeekcontainer = document.querySelector('.Userpeek-container');
var instructionscontainer = document.querySelector('.instructions-container');
var fixedsidebar = document.querySelector('.tests-sidebar');
document.addEventListener('scroll', function(){
  if (document.body.scrollTop>1){
    stickyHeader.classList.add('sticky');
    if(textcontainer!==null){
    textcontainer.style.paddingTop = stickyHeaderHeight;
  }
  if(Userpeekcontainer!==null){
    Userpeekcontainer.style.paddingTop = stickyHeaderHeight;
  }
  if(instructionscontainer!==null){
    instructionscontainer.style.marginTop = stickyHeaderHeight;
  }
  
    if(fixedsidebar !== null){
    fixedsidebar.classList.add('fixed');
  }
 }



 else{
  stickyHeader.classList.remove("sticky");
  if(textcontainer!==null){
  textcontainer.style.paddingTop = 0;
  }
  if(Userpeekcontainer!==null){
  Userpeekcontainer.style.paddingTop = 0; 
  }
  if(instructionscontainer!==null){
    instructionscontainer.style.marginTop = 0; 
    }
  if(fixedsidebar !== null){
  fixedsidebar.classList.remove('fixed');
  }
 }
});




var searchinput = document.querySelector('.create-search-sub');
var searchbtn = document.querySelector('.create-search');

if(searchbtn!=null){
  searchbtn.addEventListener('click', function(){
  searchinput.classList.add('open');
  });
  
}

if(searchinput!=null){
  document.addEventListener('click', function(event){
    if (event.target.closest('.create-search-sub')) return;
    searchinput.classList.remove('open');
  });
}







/*-- Range slider start --*/
var slider = document.getElementById("largescreen");
var output = document.getElementById("screenvalue");
if(slider!=null && output!=null){
output.innerHTML = slider.value;
slider.oninput = function() {
  output.innerHTML = this.value;
}

slider.addEventListener("mousemove", function() {
    var x = slider.value * 6.666666666666667;
    var color = 'linear-gradient(90deg, rgb(140, 131, 255)' + x + '% , rgb(214, 214, 214)' + x + '%)';
    slider.style.background = color;
});
}

var slider1 = document.getElementById("tablet");
var output1 = document.getElementById("screentablet");
if(slider1!=null && output1!=null){
output1.innerHTML = slider1.value;
slider1.oninput = function() {
  output1.innerHTML = this.value;
}
slider1.addEventListener("mousemove", function() {
    var x = slider1.value  * 6.666666666666667;
    var color = 'linear-gradient(90deg, rgb(140, 131, 255)' + x + '% , rgb(214, 214, 214)' + x + '%)';
    slider1.style.background = color;
});
}


var slider2 = document.getElementById("mobile");
var output2 = document.getElementById("screenmobile");
if(slider2!=null && output2!=null){
output2.innerHTML = slider2.value;
slider2.oninput = function() {
  output2.innerHTML = this.value;
}
slider2.addEventListener("mousemove", function() {
    var x = slider2.value  * 6.666666666666667;
    var color = 'linear-gradient(90deg, rgb(140, 131, 255)' + x + '% , rgb(214, 214, 214)' + x + '%)';
    slider2.style.background = color;
});
}
/*-- Range slider end --*/

$(function(){
  /*-- Dropdown jquery start --*/
$('.userpeek-dropdowns-btn').on('click',function(event){
event.preventDefault();
$(this).parent().find('.userpeek-dropdowns').slideToggle(300, function(){
  $(document).click(function(e) {
    $('.userpeek-dropdowns-sub')
      .not($('.userpeek-dropdowns-sub').has($(e.target)))
      .children('.userpeek-dropdowns')
      .hide();
  });
  
});

});
/*-- Dropdown jquery end --*/


/*-- filter dropdown start --*/
var $btns = $('.menu-btn').click(function() {
if (this.id == 'all-tests') {
    $('#all-parent > article').fadeIn(450);
  } else {
    var $el = $('.' + this.id).fadeIn(450);
    $('#all-parent > article').not($el).hide();
  }
  $btns.removeClass('active');
  $(this).addClass('active');
})
/*-- filter dropdown end --*/

/*-- top mobile menu code start --*/

    
$('.tests-sidebar .mobile-head').click(function(){
  if($(window).width() <= 991){
      $('.tests-sidebar .side-menu').slideToggle(300);
  }
});

      $(window).on("load resize",function(e){
        if($(window).width() <= 991){
      //  $('.tests-sidebar .side-menu').slideUp(300);
      $('.tests-sidebar .side-menu .menu-btn').click(function(){
        var selectedvalue = $(this).find('a').text();
        $('.mobile-head h2 span').text(selectedvalue);
        $('.tests-sidebar .side-menu').slideUp(300);
      });
    }
});


/*-- top mobile menu code end --*/

/*-- test detail dropdown code start--*/
$('.detail-dropdown-btn').click(function(){
$('.detail-dropdown').slideDown(300);
$(this).hide();
});
$('.detail-close').click(function(){
  $('.detail-dropdown').slideUp(300);
  $('.detail-dropdown-btn').show();
});
/*-- test detail dropdown code stop--*/

/*-- demographics-select code start --*/
$(' label.language-label .participants-input').click(function(){
if($('.demographics-checkbox').is(":checked")){
$('.specific-demograhics-container').slideDown(300);
}else{
$('.specific-demograhics-container').slideUp(300);
}
});
/*-- demographics-select code end --*/

/*-- uploaded images start --*/
var readURL = function(input) {
      if (input.files && input.files[0]) {
          var reader = new FileReader();

          reader.onload = function (e) {
              $('.profile-pic').attr('src', e.target.result);
          }
  
          reader.readAsDataURL(input.files[0]);
      }
  }
  

  $(".file-upload").on('change', function(){
      readURL(this);
  });
  
  $(".upload-button").on('click', function() {
     $(".file-upload").click();
  });
/*-- uploaded images end --*/

/*-- account sidebar start --*/

$('.menu-btn').click(function(){
  $('.tabing').hide();
$('.' + this.id).show();
});
/*-- account sidebar end --*/

/*-- video-collapse code start --*/

$('#video-collapse').click(function(){
$('.video-info-sub').toggleClass('hide');
$('.video-player').toggleClass('hide');
});

var $window = $(window),
$collapse = $('.video-info-sub');
$collapsevideo = $('.video-player');
$window.resize(function resize() {
if ($window.width() <= 991) {
    return  $collapsevideo.removeClass('hide') && $collapse.addClass('hide');
    
}

$collapse.removeClass('hide');
$collapsevideo.removeClass('hide');
}).trigger('resize');

/*-- video-collapse code end --*/

/*-- filter dropdown start --*/
$('.filter .filter-btn').click(function(){
 $(this).toggleClass('active');
$('.filter .filter-dropdown').slideToggle(300);
$('.filter .filter-dropdown .col-8').removeClass('show');
$('.filter .filter-dropdown .col-4 .nav.nav-pills li').removeClass('active');
$('.filter-dropdown .col-4').removeClass('filter-name');
});
$('.device-search').click(function(){
$('.sub-dropdown').slideToggle(300);
});


/*-- filter dropdown end --*/

/*-- Video info edit dropdown start--*/

$('.right-icon').on('click',function(event){
  event.preventDefault();
  $(this).parent().find('.dropdowns').slideToggle(300, function(){
    $(document).click(function(e) {
      $('.right-dropdown')
        .not($('.right-dropdown').has($(e.target)))
        .children('.dropdowns').slideUp(300);
    });
    
  });
  
  });

/*-- Video info edit dropdown end--*/


/*-- Video filter dropdown start --*/

  // $('.filter-dropdown .filter-dropdown-items label.name').on('click',function(event){
  //   event.preventDefault();
  //   $(this).addClass('active');
  //   $(this).parent().find('.filter-subdropdown').addClass('open', 300);
    
  //     $(document).click(function(e) {
  //       $('.filter-dropdown .filter-dropdown-items')
  //         .not($('.filter-dropdown .filter-dropdown-items').has($(e.target)))
  //         .children('.filter-subdropdown').removeClass('open');
             
  //     });
      
  //   });

$('.filter-dropdown .nav-pills li').click(function(){
  $('.filter-dropdown .nav-pills li').removeClass('active');
  $(this).addClass('active');
});

$('.filter-dropdown .nav-pills li a').click(function(){
  $('.filter-dropdown .col-4').addClass('filter-name');
  $('.filter-dropdown .col-8').addClass('show');
});

/*-- Video filter dropdown end --*/


});








