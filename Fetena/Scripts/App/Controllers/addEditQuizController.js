(function () {
    "use strict";

    angular.module("quizApp")
        .controller("AddEditQuizController", AddEditQuizController);

    AddEditQuizController.$inject = ["$uibModalInstance", "data", "quizDataService", "$rootScope"];

    function AddEditQuizController($uibModalInstance, data, quizDataService, $rootScope) {

        var vm = this;

        vm.addInputField = addInputField;
        vm.cancel = cancel;
        vm.editableItem = {};
        vm.isEditMode = (data.itemToEdit ? true : false);
        vm.isRemoveInputFieldButtonShowing = false;
        vm.properties = data;
        vm.removeInputField = removeInputField;
        vm.save = save;
        vm.title = (data.itemToEdit ? "Edit Quiz" : "Add New Quiz");

        if (vm.isEditMode) {
            vm.editableItem = angular.copy(data.itemToEdit);
        } else {
            vm.editableItem = {
                choices: [{},{}]
            }
        }

        activateTypeaheads();

        function activateTypeaheads() {
            getCategories();
            getLanguages();
            getLevels();
        }

        function addInputField() {
            vm.editableItem.choices.push({});
            vm.isRemoveInputFieldButtonShowing = true;
        }

        function cancel() {
            $uibModalInstance.dismiss();
        }

        function getCategories() {
            quizDataService.getCategories()
                .then(function (response) {
                    vm.categories = response;
                });
        }

        function getLanguages() {
            quizDataService.getLanguages()
                .then(function (response) {
                    vm.languages = response;
                });
        }

        function getLevels() {
            quizDataService.getLevels()
                .then(function (response) {
                    vm.levels = response;
                });
        }

        function removeInputField() {
            vm.editableItem.choices.pop();
            if (vm.editableItem.choices.length === 0)
                vm.isRemoveInputFieldButtonShowing = false;
        }

        function save() {          
            $uibModalInstance.close(vm.editableItem);
        }

    }

})();