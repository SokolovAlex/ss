
var options = {},
    Table = SS.Table,
    pager = {
        size: 5,
        el: "pager"
    };

    options.pages = {
        title: "Страницы",
        buttons: [{
            text: "Создать",
            simple: false,
            subButtons: [{
                text: "Опиание тура корткое",
                url: "NewPage",
                value: 0
            }, {
                text: "Новость",
                url: "NewPage",
                value: 1
            }, {
                text: "Описание тура полное",
                url: "NewPage",
                value: 2
            }]
        }],
        items : data.Pages,
        columns: [
       {
           text: "Заголовок",
           row: "Title",
           width: "50px"
       },
       {
           text: "Тип",
           row: "Type",
           width: "50px"
       },
       {
           text: "Создан",
           row: "CreatedDate",
           width: "50px"
       },
        {
            text: "Кем",
            row: "CreatedBy.LastName",
            width: "50px"
        }],
        actionsCbs:{
            'DeletePage': function (id, table) {
                table.delete(id);
            }
        },
        actions: [
            {
                text: "Изм.",
                icon: '<i class="glyphicon glyphicon-wrench"></i>',
                url: "/edit",
                row: "Id"
            }, {
                text: "Удалить",
                icon: '<i class="glyphicon glyphicon-trash"></i>',
                url: "DeletePage",
                row: "Id"
            }
        ],
        pager: pager
    };

    options.clients = {
        title: "Клиенты",
        buttons: [{
            text: "Создать"
        }],
        columns: [
      {
          text: "ФИО",
          row: "LastName",
          width: "50px"
      },
      {
          text: "ДР",
          row: "Birth",
          width: "50px"
      }],
        actions: [
            {
                text: "Изм.",
                icon: '<i class="icon-edit"></i>',
                url: "/edit",
                row: "Id"
            }, {
                text: "Удалить",
                icon: '<i class="icon-trash"></i>',
                url: "/DeleteClient",
                row: "Id"
            }
        ],
        pager: pager,
        items : data.Clients
    };

    options.settings = {
        title: "Настройки"
    };

    window.menu = {};
    menu.tables = {};
    menu.tabs = $("#tabs");
    menu.modal = $("#modal");

    menu.modal.body = $(".modal-body", menu.modal);
    menu.modal.header = $("#myModalLabel", menu.modal);

    menu.tabs.on("show", function (e) {
        var el = $(e.target),
            type = el.attr("href").replace("#", "");

        if (!menu.tables[type]) {
            menu.tables[type] = menu.initTable(type);
        }
    });

    menu.initTable = function (type) {
        switch (type) {
            case "clients":
                console.log(options[type]);
                console.log("data", data);
                return new Table($("#" + type), this, options[type]);
            case "pages":
                console.log(options[type]);

                console.log("data", data);
                options[type].items = data.Pages;
                return new Table($("#" + type), this, options[type]);
            case "settings":
                console.log(options[type]);
                return "";
        }
    }

    menu.tabs.find('a:first').tab('show');

    