(function () {
    "use strict";

    angular.module("quizApp")
        .controller("QuizzesController", QuizzesController);

    QuizzesController.$inject = ["$uibModal", "quizDataService", "deleteConfirmService", "$rootScope"];

    function QuizzesController($uibModal, quizDataService, deleteConfirmService, $rootScope) {

        var vm = this;

        vm.activateQuizzes = activateQuizzes;
        vm.category = "";
        vm.categories = [];
        vm.currentPage = { num: 1 };
        vm.editQuiz = editQuiz;
        vm.filteredQuizzes = [];
        vm.getCategories = getCategories;
        vm.getLevels = getLevels;
        vm.getQuizzes = getQuizzes;
        vm.isQuizListShowing = false;
        vm.language = "";
        vm.languages = [];
        vm.level = "";
        vm.levels = [];
        vm.numPerPage = 10;
        vm.maxSize = 5;
        vm.quizzes = [];
        vm.removeQuiz = removeQuiz;

        getLanguages();

        function activateQuizzes() {
            quizDataService.getQuizzes(vm.language, vm.level, vm.category)
                .then(function (response) {
                    vm.quizzes = response;
                    getQuizzes();
                    vm.isQuizListShowing = true;
                });
        }

        function editQuiz(quizData) {
            var modalInstance = $uibModal.open({
                templateUrl: "Scripts/App/Templates/addEditQuiz.html",
                controller: "AddEditQuizController",
                controllerAs: "vm",
                size: "lg",
                resolve: {
                    data: function () {
                        return {
                            itemToEdit: quizData
                        };
                    }
                }
            });
            modalInstance.result.then(function (result) {
                quizDataService.saveQuiz(result).then(function (data) {
                    console.log(data);
                    if (quizData) {
                        _.assign(quizData, data);
                        activateQuizzes();
                    } else {
                        activateQuizzes();
                    }
                });
            });
        }

        function getCategories() {
            quizDataService.getCategoriesUsed(vm.language, vm.level)
                .then(function(response) {
                    vm.categories = response;
                });
        }

        function getLanguages() {
            quizDataService.getLanguagesUsed()
                .then(function(response) {
                    vm.languages = response;
                });
        }

        function getLevels() {
            quizDataService.getLevelsUsed(vm.language)
                .then(function(response) {
                    vm.levels = response;
                });
        }

        function getQuizzes() {
            var begin = ((vm.currentPage.num - 1) * vm.numPerPage);
            var end = begin + vm.numPerPage;
            vm.filteredQuizzes = vm.quizzes.slice(begin, end);
        }

        function removeQuiz(id) {
            deleteConfirmService.confirm("Are you sure you want to Delete this item?", "Delete?", ["OK", "Cancel"])
                .then(function () {
                    quizDataService.deleteQuiz(id).then(function (data) {
                        _.remove(vm.quizzes, { 'id': id });
                        activateQuizzes();
                    });
                });
        }

    }
})();