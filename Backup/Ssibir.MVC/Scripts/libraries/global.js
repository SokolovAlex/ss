ssibir = {};

(function() {
    function makeData(data) {
        var result = {};
        _.each(data, function (value, name) {
            if (value) {
                result[name] = value;
            }
        });
        return result;
    }

    function addParameters(url, data) {
        var resultUrl = url + '?';
        var isFirst = true;
        _.each(data, function (value, key) {
            if (value) {
                if (isFirst) {
                    isFirst = false;
                    resultUrl += key + '=' + value;
                } else {
                    resultUrl += '&' + key + '=' + value;
                }
            }
        });
        return resultUrl;
    }

    ssibir.toPage = function (key, withoutHistory) {
    	var baseUrl = SS.config.baseUrl;

	    if (_.isObject(key)) {
		    key.preventDefault ? key.preventDefault() : (key.returnValue = false);
		    key = $(this).data('key') || $(this).data('id');
	    }
	    var el = $('#mainPage');
	    var preloader = $('<div class="preloader"><img src="' + baseUrl + 'Images/Others/preloader.GIF"/></div>');
	    //el.attr('style', 'opacity: 0.3');
	    el.append(preloader);

	    var url = !parseInt(key, 10) ? '/ss/PageDataByKey/' : '/ss/PageData/';

	    $.ajax({
		    url: url,
		    data: { key: key },
		    success: function (resp) {
			    resp = JSON.parse(resp);

			    var model = resp.model;
			    if (!withoutHistory && window.history && window.history.pushState) {
			    	window.history.pushState({
			    		pagekey: key
			    	}, null, '/ss/Page/' + key);
			    }

			    el.fadeOut(1000, function () {

				    var templateName = !resp.custom && resp.type || 'simple',
					    html = $('#' + templateName + 'Template').html();

				    var data = prepareData(model, resp.type);

				    var newPage = !resp.custom ? _.template(html, data) : model.Html;

				    el.html(newPage);
				    el.fadeIn(1000);

				    $('*.disabled[data-page-key]').removeClass('disabled');
				    $('*[data-page-key=' + key + ']').addClass('disabled');

			    });
		    },
		    error: function (error) {
			    preloader.remove();
		    }
	    });
    };

    ssibir.toList = function (name, filter, sort, title, withoutHistory) {
    	var baseUrl = SS.config.baseUrl;

	    var el = $('#mainPage');
	    var preloader = $('<div class="preloader"><img src="' + baseUrl + 'Images/Others/preloader.GIF"/></div>');
	    //el.attr('style', 'opacity: 0.3');
	    el.append(preloader);

	    var url = '/ss/ListData/';

	    $.ajax({
		    url: url,
		    data: makeData({
			    filter: filter,
			    list: name,
			    sort: sort
		    }),
		    success: function (resp) {
			    resp = JSON.parse(resp);

			    var params =  makeData({
			        filter: filter,
			        list: name,
			        sort: sort
			    });

			    if (!withoutHistory && window.history) {
				    window.history.pushState({
				        list:params
				    }, null, addParameters('/ss/List', params));
			    }

			    el.fadeOut(1000, function () {
				    resp.title = title;
				    var newPage = _.template($('#listTemplate').html(), resp);

				    el.html(newPage);

				    el.find('.card').click(ssibir.toPage);

				    el.fadeIn(1000);
			    });
		    },
		    error: function (error) {
			    preloader.remove();
		    }
	    });
    };

    function prepareData(model, type) {

	    switch (type) {
		    case 'manager':
			    return {
				    imageUrl: model.ImageUrl,
				    displayName: model.displayName,
				    description: model.Description,
				    displayName: model.DisplayName,
				    email: model.Email,
				    job: model.JobDescription,
				    phone: model.Phone,
				    vk: model.Vk,
				    skype: model.Skype
			    };
		    default:
			    return {
				    title: model.Title,
				    imageUrl: model.ImageUrl,
				    html: model.Html,
				    direction: null,
				    comments: null,
				    cost: null,
				    hotels: null
			    };
	    }
    }


})();