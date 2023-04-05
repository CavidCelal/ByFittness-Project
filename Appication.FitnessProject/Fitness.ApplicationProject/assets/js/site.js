$(function() {"use strict";

	if ($(window).width() < 768) {
		$('.navbar-nav li').on('click', function() {
			$('.drop-down').slideUp();
			$(this).children('.drop-down').slideDown();
		});
	};
	
	$('.dropdown-menu li a').on('click',function(){
		var abc=$(this).html();
		$('.dropdown-toggle').html(abc + '<span class="caret"></span>');
	});
	

	if ($('#owl-slider1').length) {

		$("#owl-slider1").owlCarousel({

			autoPlay : 5000, //Set AutoPlay to 5 seconds
			items : 2,
			itemsDesktop : [1199, 2],
			itemsDesktopSmall : [979, 2],
			itemsMobile : [600, 1]

		});
	}
	if ($('#owl-slider2').length) {

		$("#owl-slider2").owlCarousel({

			autoPlay : 5000, //Set AutoPlay to 5 seconds
			singleItem : true

		});
	}
	if ($('#owl-sucess-story').length) {

		$("#owl-sucess-story").owlCarousel({

			autoPlay : 5000, //Set AutoPlay to 5 seconds
			singleItem : true,

		});
	}

	if ($('#owl-slider-hero').length) {

		$("#owl-slider-hero").owlCarousel({

			navigation : false, // Show next and prev buttons
			slideSpeed : 2000,
			paginationSpeed : 400,
			autoPlay : 5000,
			singleItem : true

			// "singleItem:true" is a shortcut for:
			// items : 1,
			// itemsDesktop : false,
			// itemsDesktopSmall : false,
			// itemsTablet: false,
			// itemsMobile : false

		});

		$('.slider-navigation').find('li').on('click', function() {
			$('.slider-navigation li').removeClass('active')
			$(this).addClass('active');

			var a = $(this).index();
			$("#owl-slider-hero").trigger('owl.goTo', a)
		});

		setInterval(function() {
			var i = $('#owl-slider-hero .owl-pagination .owl-page.active ').index();
			$('.slider-navigation li').removeClass('active')
			$('.slider-navigation li').eq(i).addClass('active');
		}, 1000);

	}
	if ($('#owl-blog').length) {

		$("#owl-blog").owlCarousel({

			navigation : true, // Show next and prev buttons
			slideSpeed : 300,
			paginationSpeed : 400,
			singleItem : true,
			pagination : false
			// "singleItem:true" is a shortcut for:
			// items : 1,
			// itemsDesktop : false,
			// itemsDesktopSmall : false,
			// itemsTablet: false,
			// itemsMobile : false

		});
	}

	if ($('#owl-schedule').length) {

		$("#owl-schedule").owlCarousel({

			autoPlay : 5000, //Set AutoPlay to 3 seconds

			items : 6,
			itemsDesktop : [1600, 5],
			itemsDesktopSmall : [1200, 4],
			itemsMobile : [600, 1]

		});
	}
	if ($('#owl-schedule-home-3').length) {

		$("#owl-schedule-home-3").owlCarousel({

			autoPlay : 5000, //Set AutoPlay to 5 seconds

			items : 3,
			itemsDesktop : [1600, 3],
			itemsDesktopSmall : [1200, 3],
			itemsMobile : [600, 1]

		});
	}

	if ($('#owl-trainers').length) {

		$("#owl-trainers").owlCarousel({

			autoPlay : 5000, //Set AutoPlay to 5 seconds

			items : 3.5,
			itemsDesktop : [1600, 3.5],
			itemsDesktopSmall : [1200, 3],
			itemsMobile : [600, 1]

		});
	}

	if ($('#owl-hthree-one').length) {
		$("#owl-hthree-one").owlCarousel({

			navigation : true, // Show next and prev buttons
			slideSpeed : 300,
			paginationSpeed : 400,
			singleItem : true

		});
	}
	if ($('#owl-blog-details').length) {

		$("#owl-blog-details").owlCarousel({

			autoPlay : 3000, //Set AutoPlay to 3 seconds
			navigation : true,
			pagination : false,
			navigationText : ["previous", "next"],

			items : 2,
			itemsDesktop : [1600, 2],
			itemsDesktopSmall : [1200, 2],
			itemsMobile : [600, 1]

		});
	}

	//=================Range Slider function ================
	if ($('#slider-meter').length) {
		$("#slider-meter").slider({
			range : true,
			min : 50,
			max : 100,
			values : [50, 81],
			slide : function(event, ui) {
				$("#amount").text("$" + ui.values[0] + " - ");
				$("#amount1").text("$" + ui.values[1]);
			}
		});

		$("#amount").text("$" + $("#slider-meter").slider("values", 0) + " - ");

		$("#amount1").text("$" + $("#slider-meter").slider("values", 1));

	}

	$('#header .nav ,.pagination li ').find('li').on('click', function() {
		$(this).siblings('li').removeClass('active');
		$(this).addClass('active');
	});

	$('.open-info').on('click', function(e) {
		e.preventDefault();
		$(this).parents('.item').addClass('open_slide');
	})

	$('.cross').on('click', function(e) {
		e.preventDefault();
		$(this).parents('.item').removeClass('open_slide');
	})
	//==============Map Function
	if (jQuery('#custom_map').length) {

		var initialize = function() {
			//function initialize() {
			var pos = new google.maps.LatLng(23.001452, 72.574112);

			var mapProp = {
				center : pos,
				zoom : 10,
				scrollwheel : false,
				mapTypeId : google.maps.MapTypeId.ROADMAP
			};

			var infowindow = new google.maps.InfoWindow({
				position : pos,
				content : '<div id="info">' + '<span class="head">Fit FAB  Fitness Studio 31 FAB Street Falkirk, Ahmedabad</span>' + ' <a href="#" >01324 1234567</a>' + '<a href="#" class="text-mail">info@fitfab.com</a>' + '</div>'

			});
			// var contentString = $('#legend').html();
			// var infowindow = new google.maps.InfoWindow({
			// content : contentString,
			//
			// });

			var map = new google.maps.Map(document.getElementById("custom_map"), mapProp);

			infowindow.open(map);

		}

		google.maps.event.addDomListener(window, 'load', initialize);

	};

	//==============Map Function2
	if (jQuery('#custom_mapevent').length) {

		var initialize = function() {
			//function initialize() {
			var pos = new google.maps.LatLng(23.001452, 72.574112);

			var mapProp = {
				center : pos,
				zoom : 10,
				scrollwheel : false,
				mapTypeId : google.maps.MapTypeId.ROADMAP
			};

			var marker = new google.maps.Marker({
				position : pos,
				map : map,
				draggable : false,

			});

			var map = new google.maps.Map(document.getElementById("custom_mapevent"), mapProp);
			marker.setMap(map);
			// infowindow.open(map, marker);

		}

		google.maps.event.addDomListener(window, 'load', initialize);

	};
	$(window).scroll(function() {

		if ($(this).scrollTop() > 10) {
			$('.header-one').addClass('header-color');
		} else {
			$('.header-one').removeClass('header-color');
		}
	})
});

/* Increment And Decrement----ShopDetails*/
var count = 1;
$(".increment").on('click', function() {

	count++;

	$(".textVal").val(count);
});
$(".decrement").on('click', function() {
	count = $(".textVal").val();
	if (count != 0) {

		count--;
	}
	$(".textVal").val(count);
});

/* Increment And Decrement----ShoppingCart*/

var count = 1;
$(".increase1").on('click', function() {
	count++;
	$(".product-value1").val(count);
});
$(".decrease1").on('click', function() {
	count = $(".product-value1").val();
	if (count != 0) {
		count--;
	}
	$(".product-value1").val(count);
});
$(".increase2").on('click', function() {
	count++;
	$(".product-value2").val(count);
});
$(".decrease2").on('click', function() {
	count = $(".product-value2").val();
	if (count != 0) {
		count--;
	}
	$(".product-value2").val(count);
});

// Filltering.................
if ($('.main').length) {

	$container = $('.main').isotope({
		itemSelector : '.main-item',
		layoutMode : 'fitRows'
	})

	$('.dropdown-menu li').on('click', function() {

		var filterValue = "." + $(this).attr('class');
		$container.isotope({
			filter : filterValue
		});

	});
}

$(window).load(function() {
	$("#loading").delay(2000).fadeOut(500);
	

})

