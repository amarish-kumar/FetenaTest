(function () {
    "use strict";

    angular.module("quizApp")
        .controller("LanguagesController", LanguagesController);

    LanguagesController.$inject = ["$uibModal", "quizDataService", "deleteConfirmService", "$state"];

    function LanguagesController($uibModal, quizDataService, deleteConfirmService, $state) {

        var vm = this;

        vm.languages = [];
        vm.removeLanguage = removeLanguage;
        vm.editLanguage = editLanguage;
        vm.getLanguages = getLanguages;
        vm.filteredLanguages = [];
        vm.currentPage = { num: 1 };
        vm.numPerPage = 10;
        vm.maxSize = 5;

        activateLanguages();

        function activateLanguages() {
            quizDataService.getLanguages()
                .then(function (response) {
                    vm.languages = response;
                    getLanguages();
                });
        }

        function getLanguages() {
            var begin = ((vm.currentPage.num - 1) * vm.numPerPage);
            var end = begin + vm.numPerPage;
            vm.filteredLanguages = vm.languages.slice(begin, end);
        }

        function removeLanguage(id) {
            deleteConfirmService.confirm("Are you sure you want to Delete this item?", "Delete?", ["OK", "Cancel"])
                .then(function () {
                    quizDataService.deleteLanguage(id).then(function (data) {
                        _.remove(vm.languages, { 'id': id });
                        activateLanguages();
                    });
                });
        }

        function editLanguage(languageData) {
            var modalInstance = $uibModal.open({
                templateUrl: "Scripts/App/Templates/addEditLanguage.html",
                controller: "AddEditLanguageController",
                controllerAs: "vm",
                resolve: {
                    data: function () {
                        return {
                            itemToEdit: languageData
                        };
                    }
                }
            });
            modalInstance.result.then(function (result) {
                quizDataService.saveLanguage(result).then(function (data) {
                    if (languageData) {
                        _.assign(languageData, data);
                        activateLanguages();
                    } else {
                        activateLanguages();
                    }
                });
            });
        }


    }
})();