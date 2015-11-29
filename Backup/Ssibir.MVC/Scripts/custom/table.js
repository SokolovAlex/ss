
window.SS.Table = function (el, menu, options) {
    var self = this,
		opt = _.extend({}, window.SS.Table.defaultOptions, options),
        buttonTemplate = $("#buttonTemplate").html(),
		template = $("#tableTemplate").html(),
        bodytemplate = $("#tbodyTemplate").html(),
        tbody = {},
        columns = opt.columns,
        actions = opt.actions,
        pagerOptions = opt.pager,
        asc = true,
        sortedValue = "";

	self.title = opt.title;
	self.button = null;
	self.items = opt.items;

	function action() {
        var val = $(this).data("value"),
            url = $(this).data("url"),
            callback = options.actionsCbs[url];

        $.ajax({
            url: url,
            type: 'post',
            data: {
                id: val
            },
            success: function (result) {
                callback(val, self);
            }
        });
    }

	function bind() {
	    el.off("click", ".sstable-action");
	    el.on('click', ".sstable-action", action);	       
	}

	function sort() {
	    var value = $(this).attr("value");
	    if (sortedValue == value) {
	        asc = !asc;
	    } else {
	        asc = true;
	    }
	    sortedValue = value;
	    items = self.items.sort(function (left, right) {
	        if (!asc) return left[value] < right[value];
	        return left[value] > right[value];
	    });
	    self.refresh();
	}

	function bindColumns() {
	    el.on('click', ".sstable-sort", sort);
	}

	function bindButttons() {
	    var el = $("a.tab-link", self.button);
	    el.click(edit);
	}

	self.refresh = function() {
	    tbody.fadeOut(function () {
	        var pageItems = [];
	        if (self.pager) {
	            var size = self.pager.getSize(),
                        current = self.pager.getCurrent(),
                        first = size * (current - 1),
                        last = _.min([size * current, self.items.length]);

	            for (var i = first; i < last; i++) {
	                pageItems.push(self.items[i])
	            }

	        } else {
	            pageItems = self.items;
	        }

	        tbody.html(_.template(bodytemplate, { items: pageItems, columns: columns, actions: actions }));

	        tbody.fadeIn();

	        bind();

	        if (pagerOptions) {
	            self.pager.refresh();
	        }
	    });
	}

	self.add = function(item) {
	    self.items.push(item);
	    self.refresh();
	}

	self.delete = function (id) {
	    self.items = _.reject(self.items, function (item) {
	        return item.Id == id;
	    });
	    self.refresh();
	}
    
	function edit() {
	    var el = $(this),
            href = el.attr("url"),
            type = el.attr("value");
	    $.ajax({
	        url: href,
	        data: {
                type: type
	        },
	        success: function (data) {
	            $(window).on("modalload", function(e, cb) {
	                cb(menu);
	            });
	            menu.modal.modal("show");
	            menu.modal.body.html(data);
	            menu.modal.header.html('Новости');
	        }
	    })
	}

	function init() {
	    el.append("<div class='label label-info'>" + self.title + "</div>");
	    el.append(_.template(buttonTemplate, opt));
	    self.button = el.last();
	    
	    bindButttons();

	    el.append(_.template(template, opt));
	    bindColumns();

	    if (pagerOptions) {
	        self.pager = new Pager($("#" + pagerOptions.el, el), self, pagerOptions);
	    }

	    tbody = $("tbody", el);
	    self.refresh();    
	}

	init();
}

var Pager = function (el, parent, opt) {
    var self = this,
        template = $("#pagerTemplate").html(),
        size = opt.size,
        name = opt.name || "items",
        count = parent[name] ? parent[name].length : 0,
        maxPage = Math.ceil(count / size),
        current = opt.start || 1;

    self.getCurrent = function () {
        return current;
    }

    self.getSize = function () {
        return size;
    }

    self.refresh = function () {
        render();
    }

    function bind() {
        el.off();

        el.on("click", "li:first-child", function () {
            if ($(this).hasClass("disabled")) {
                return;
            }
            current = current - 1;
            parent.refresh();
        })

        el.on("click", "li:last-child", function () {
            if ($(this).hasClass("disabled")) {
                return;
            }
            current = current + 1;
            parent.refresh();
        })

        el.on("click", "a.page", function () {
            current = $(this).text() * 1;
            parent.refresh();
        })

    }

    function init() {
        render();
    }

    function getData() {
        var startIndex = _.max([current - 2, 1]),
            finishIndex = _.min([maxPage, current + 2]),
            pages = _.range(startIndex, finishIndex + 1);

        return {
            prev: startIndex == current ? "disabled" : "",
            next: current == finishIndex ? "disabled" : "",
            pages: pages,
            start: current,
            size: size
        }
    }

    function render() {
        el.empty();
        count = parent[name].length;
        maxPage = Math.ceil(count / size);

        if (current  > maxPage) {
            current = maxPage;
            parent.refresh();
        }

        el.html(_.template(template, getData()));
        bind();
    }

    init();
};

window.SS.Table.defaultOptions = {
	title: "table",
	startPage: 1
};

