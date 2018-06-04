var ToDoListViewModel = function (listsData) {
    "use strict";

    var mapping = {
        "lists": {
            create: function (options) {
                return new ListViewModel(options.data);
            }
        }
    };

    ko.mapping.fromJS(listsData, mapping, this);

    this.listToAdd = ko.observable("");
    this.listItemToAdd = ko.observable("");
    this.listItemsFilter = ko.observable("all");
    this.showCompleted = ko.observable(true);

    this.activeList = ko.computed(function () {
        return ko.utils.arrayFirst(this.lists(), function (list) {
            return list.isActive();
        });
    }, this);

    this.listItems = ko.computed(function () {
        if (!this.activeList())
            return null;

        if (this.showCompleted())
            return this.activeList().listItems();

        return this.activeListItems();
    }, this);

    this.activeListItems = ko.computed(function () {
        if (!this.activeList())
            return null;

        return ko.utils.arrayFilter(this.activeList().listItems(), function (item) {
            return !item.isCompleted();
        });
    }, this);

    this.showCompletedText = ko.computed(function () {
        if (this.showCompleted())
            return "Hide Completed";

        return "Show Completed";
    }, this);

    this.addListButtonEnabled = this.listToAdd().length > 0;
};

ToDoListViewModel.prototype.addList = function () {
    var self = this;

    var list = {
        title: self.listToAdd(),
        isActive: true
    };

    ListsService.createList(list,
        function (data) {
            // Inactivate.
            if (self.activeList())
                self.activeList().toggleIsActive();

            list.listId = data.listId;
            list.listItems = [];

            var newList = new ListViewModel(list);
            self.lists.push(newList);
            self.listToAdd("");
        },
        function () {
            // TODO: Standardize error handling.
            alert("Sorry, there was an error adding the list. Please try again later.");
        });
};

ToDoListViewModel.prototype.addListItem = function () {
    this.activeList().addListItem(this.listItemToAdd());
    this.listItemToAdd("");
};

ToDoListViewModel.prototype.switchActiveList = function (list) {
    // Inactivate.
    this.activeList().toggleIsActive();
    // Activate.
    list.toggleIsActive();
};

ToDoListViewModel.prototype.toggleShowCompleted = function () {
    this.showCompleted(!this.showCompleted());
};

ToDoListViewModel.prototype.deleteList = function () {
    var self = this;

    ListsService.deleteList(this.activeList().listId,
        function () {
            self.lists.remove(self.activeList());

            if (self.lists().length)
                self.lists()[0].toggleIsActive();
        },
        function () {
            alert("Sorry, there was an error deleting the list. Please try again later.");
        });
};