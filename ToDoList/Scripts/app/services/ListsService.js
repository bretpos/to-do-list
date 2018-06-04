var ListsService = (function ($) {
    "use strict";

    function createList(list, done, fail) {
        $.ajax({
            method: "POST",
            url: "/api/lists",
            data: list
        })
        .done(done)
        .fail(fail);
    }

    function deleteList(listId, done, fail) {
        $.ajax({
            url: "/api/lists/" + listId,
            method: "DELETE"
        })
        .done(done)
        .fail(fail);
    }

    function updateList(list, done, fail) {
        $.ajax({
            url: "/api/lists",
            method: "PUT",
            data: list
        })
        .done(done)
        .fail(fail);
    }

    return {
        createList: createList,
        deleteList: deleteList,
        updateList: updateList
    };

}(jQuery));