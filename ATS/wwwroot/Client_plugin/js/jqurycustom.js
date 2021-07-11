$(document).ready(function(){
var path = window.location.href; 
 $('.navbar-nav li a').each(function() {
  if (this.href === path) {
   $(this).addClass('active');
  }
 });
});

$(document).ready(function () {
    var path = window.location.href;
    $('.audit-saidvar .li a').each(function () {       
        if (this.href === path) {
            $(this).addClass('active');
        }
    });
});

$(document).ready(function () {
    $(".page-item").click(function () {
        $(".page-item").removeClass("active");
        // $(".tab").addClass("active"); // instead of this do the below 
        $(this).addClass("active");
    });
});