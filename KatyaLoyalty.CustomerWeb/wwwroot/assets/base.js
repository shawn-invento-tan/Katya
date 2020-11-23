$(document).ready(function () {
	$("[data-toggle=overlay]").on("click", function () {
		var target = $(this).attr("data-target");
		$(target).toggleClass("show");
		$("body").toggleClass("overflow-hidden");
	})
	$("[data-dismiss=overlay]").on("click", function () {
		$(this).parents(".overlay").removeClass("show");
		$("body").removeClass("overflow-hidden");
	})
	$(window).on("resize", function () {
		$(".overlay").removeClass("show");
		$("body").removeClass("overflow-hidden");
	})
})