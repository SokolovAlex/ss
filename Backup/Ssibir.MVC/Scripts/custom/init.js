

$(function () {

	function chechRequestForm(data) {
		function validateEmail(email) {
			var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
			return re.test(email);
		}

		if (!data.UserName) {
			$('#requestTourForm input[name=UserName]').parent().addClass('has-error');
			ssAlert.error('Укажите Ваше имя.');
			return false;
		} else {
			$('#requestTourForm input[name=UserName]').parent().removeClass('has-error');
		}

		if (!validateEmail(data.Email)) {
			$('#requestTourForm input[name=Email]').parent().addClass('has-error');
			ssAlert.error('Поле Email заполнено неверно.');
			return false;
		} else {
			$('#requestTourForm input[name=Email]').parent().removeClass('has-error');
		}

		if (!data.Phone) {
			$('#requestTourForm input[name=Phone]').parent().addClass('has-error');
			ssAlert.error('Укажите Ваш телефон.');
			return false;
		} else {
			$('#requestTourForm input[name=Phone]').parent().removeClass('has-error');
		}

		if (!data.Wishes) {
			$('#requestTourForm textarea[name=Wishes]').parent().addClass('has-error');
			ssAlert.error('Укажите Ваши пожелания к туру.');
			return false;
		} else {
			$('#requestTourForm textarea[name=Wishes]').parent().removeClass('has-error');
		}
		return true;
	}


	function submitForm(e) {
		e.preventDefault ? e.preventDefault() : event.returnValue = false;
		var data = {};

		$("#requestTourForm").serializeArray()
			.map(function (x) {
				data[x.name] = x.value;
			});

		if (!chechRequestForm(data)) {
			return;
		}

		$.ajax({
			url: '/Main/TourRequest',
			data: data,
			dataType: 'json',
			success: function (response) {
				ssAlert.ok('Заявка отправлена. Ждите ответа менеджера на указанные контактные данные.');
				$('#pickUpTour').removeClass('open');
			}
		});
	}

	$('#AccordionImageMenu').AccordionImageMenu({
		'border': 3,
		'color': '#000000',
		'height': 130,
		'duration': 350,
		'openDim': 340,
		'closeDim': 200,
		'effect': 'swing',
		'fadeInTitle': false
	});
	// menu hover
	$('.menuitem').bind('mouseenter', function () {
		$(this).find('.linkWrapper').css({ 'opacity': '1' });
		$(this).find('.linkWrapper').fadeIn(500);
	}).bind('mouseleave', function () {
		$(this).find('.linkWrapper').fadeOut(500);
	});

	$('#AccordionImageMenu').css({ "visibility": "visible" });

	// login block
	$('.front, .glyphicon-remove').click(function () {
		$('.safe').toggleClass('flip');
	});

	// menu click
	$('*[data-list]').click(function (e) {
		var filter = $(this).data('filter'),
			title = $(this).text(),
			list = $(this).data('list'),
			sort = $(this).data('sort');

		e.preventDefault ? e.preventDefault() : (e.returnValue = false);

		ssibir.toList(list, filter, sort, title);
	});

	// привязываем кнопки с направлениями
	$('*[data-page-key]').click(function (e) {

		e.preventDefault ? e.preventDefault() : (e.returnValue = false);

		if ($(this).hasClass('disabled')) return;

		var key = $(this).data('page-key');
		ssibir.toPage(key);
	});

	var initTR = false;
	// открыть "подобрать тур"
	$('#tooglePickUpTour').click(function (e) {
		var self = this;
		if (initTR) {
			$(this).closest('#pickUpTour').toggleClass('open');
		} else {
			$.ajax('/Main/TourRequestInfo', {
				dataType: "json",
				success: function (data) {
					if (data.error) return;

					$('#pickUpTour .datePicker').datepicker().on('changeDate', function (ev) {
						if (ev.viewMode == 'days') {
							$(this).datepicker('hide');
						}
					});
					//$('#inputManager').empty();
					$.each(data.managers, function(i, item) {
						$('#inputManager').append($('<option>', {
							text: item.DisplayName,
							value: item.Id,
							selected: i == 0
						}));
					});

					$('#sendRequestTourButton').click(submitForm);

					$(self).closest('#pickUpTour').toggleClass('open');
					initTR = true;
				}
			});
		}
	});

	$('input[type="button"]').button();
	$('button').button();

	if (window.history) {
		window.addEventListener('popstate', function (e) {
			var state = e.state;

			if (!state) {
				return location.href = '';
			}

			if (state.pagekey) {
				ssibir.toPage(state.pagekey, true);
			} else if (state.list) {
				var data = state.list;
				ssibir.toList(data.list, data.filter, data.sort, data.title, true);
			}
		}, false);

		var state = historyApi.getStateFromUrl(location.href);
		if (state && state.pagekey) {
			$('*[data-page-key=' + state.pagekey + ']').addClass('disabled');
		}
	}

});