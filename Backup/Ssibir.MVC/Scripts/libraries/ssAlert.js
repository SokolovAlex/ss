(function () {				
	var $el,
		timerId,
		inited = false,
		textEl;

	$(document).ready(function () {
		$el = $("#ssAlert");
		inited = true;
		textEl = $('#ssAlert .message');
	});

	function show(message) {
		textEl.text(message);
		$el.addClass('show');

		console.log("!!!!!!!!!!", message);

		timerId = setTimeout(function() {
			$el.removeClass('show');
		}, 2000);
	}
	ssAlert = {
		ok: function (message) {
			$el.removeClass('error');
			show(message);
		},
		error: function (message) {
			$el.addClass('error');
			show(message);
		}
	}
})(window)

