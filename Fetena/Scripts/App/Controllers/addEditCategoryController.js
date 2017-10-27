(function() {
    "use strict";

    angular.module("quizApp")
        .controller("AddEditCategoryController", AddEditCategoryController);

    AddEditCategoryController.$inject = ["$uibModalInstance", "data"];

    function AddEditCategoryController($uibModalInstance, data) {

        var vm = this;

        vm.cancel = cancel;
        vm.editableItem = angular.copy(data.itemToEdit);
        vm.properties = data;
        vm.save = save;
        vm.title = (data.itemToEdit ? "Edit Category" : "Add New Category");

        function cancel() {
            $uibModalInstance.dismiss();
        }

        function save() {
            $uibModalInstance.close(vm.editableItem);
        }
   }

})();