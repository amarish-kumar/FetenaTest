(function () {
    "use strict";

    angular.module("quizApp")
        .controller("AddEditLanguageController", AddEditLanguageController);

    AddEditLanguageController.$inject = ["$uibModalInstance", "data"];

    function AddEditLanguageController($uibModalInstance, data) {

        var vm = this;

        vm.cancel = cancel;
        vm.editableItem = angular.copy(data.itemToEdit);
        vm.properties = data;
        vm.save = save;
        vm.title = (data.itemToEdit ? "Edit Language" : "Add New Language");

        function cancel() {
            $uibModalInstance.dismiss();
        }

        function save() {
            $uibModalInstance.close(vm.editableItem);
        }
    }

})();