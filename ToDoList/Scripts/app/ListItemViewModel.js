var ListItemViewModel = function (data) {
    "use strict";

    var mapping = {
        "copy": ["listItemId", "listId"]
    };

    ko.mapping.fromJS(data, mapping, this);

    // Mapping defines...
    //this.listItemId
    //this.description
    //this.isCompleted
    //this.listId

    this.showRemoveButton = ko.observable(false);
};

ListItemViewModel.prototype.update = function () {
    ListItemsService.updateListItem(new ListItem(this.listItemId, this.description, this.isCompleted, this.listId));
};

ListItemViewModel.prototype.toggleCompleted = function () {
    this.update();
    return true;
};

ListItemViewModel.prototype.hideRemoveButton = function () {
    this.showRemoveButton(false);
};

var ListItem = function (listItemId, description, isCompleted, listId) {
    this.listItemId = listItemId;
    this.description = description;
    this.isCompleted = isCompleted;
    this.listId = listId;
};