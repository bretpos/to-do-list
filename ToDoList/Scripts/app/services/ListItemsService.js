var ListItemsService = (function ($) {
    "use strict";

    function createListItem(listItem, done, fail) {
        $.ajax({
            method: "POST",
            url: "/api/listItems",
            data: listItem
        })
        .done(done)
        .fail(fail);
    }

    function deleteListItem(listItemId, done, fail) {
        $.ajax({
            url: "/api/listItems/" + listItemId,
            method: "DELETE"
        })
        .done(done)
        .fail(fail);
    }

    function updateListItem(listItem, done, fail) {
        $.ajax({
            url: "/api/listItems",
            method: "PUT",
            data: listItem
        })
        .done(done)
        .fail(fail);
    }

    return {
        createListItem: createListItem,
        deleteListItem: deleteListItem,
        updateListItem: updateListItem
    };

}(jQuery));