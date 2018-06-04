var ListViewModel = function (data) {

    var mapping = {
        "copy": ["listId"],
        "listItems": {
            create: function (options) {
                return new ListItemViewModel(options.data);
            }
        }
    };

    ko.mapping.fromJS(data, mapping, this);

    // Mapping defines...
    //this.listId
    //this.title
    //this.listItems
    //this.isActive
};


ListViewModel.prototype.addListItem = function (listItemDescription) {
    var self = this;

    ListItemsService.createListItem({ description: listItemDescription, listId: self.listId },
        function (data) {
            var listItem = {
                listItemId: data.listItemId,
                description: listItemDescription,
                isCompleted: false,
                listId: self.listId
            };

            self.listItems.push(listItem = new ListItemViewModel(listItem));
        },
        function () {
            // TODO: Standardize error handling.
            alert("Sorry, there was an error adding the list item. Please try again later.");
        }
    );
};

ListViewModel.prototype.removeListItem = function (listItemId) {
    var self = this;

    ListItemsService.deleteListItem(listItemId,
        function () {
            self.listItems.remove(function (listItem) {
                return listItem.listItemId === listItemId;
            });
        },
        function () {
            // TODO: Standardize error handling.
            alert("Sorry, there was an error deleting the list item. Please try again later.");
        });
};

ListViewModel.prototype.toggleIsActive = function () {
    var self = this;

    var list = {
        listId: self.listId,
        title: self.title,
        isActive: (!self.isActive())
    };

    ListsService.updateList(list,
        function () {
            self.isActive(!self.isActive());
        },
        function () {
            alert("Sorry, there was an error updating the list. Please try again later.");
        });
};