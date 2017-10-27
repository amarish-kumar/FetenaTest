(function () {
    "use strict";

    angular.module("quizApp")
        .controller("CategoriesController", CategoriesController);

    CategoriesController.$inject = ["$uibModal", "quizDataService", "deleteConfirmService", "$state"];

    function CategoriesController($uibModal, quizDataService, deleteConfirmService, $state) {

        var vm = this;

        vm.categories = [];
        vm.removeCategory = removeCategory;
        vm.editCategory = editCategory;
        vm.getCategories = getCategories;
        vm.filteredCategories = [];
        vm.currentPage = {num: 1};
        vm.numPerPage = 10;
        vm.maxSize = 5;

        activateCategories();

        function activateCategories() {
            quizDataService.getCategories()
                .then(function(response) {
                    vm.categories = response;
                    getCategories();
                });
        }      

        function getCategories() {
            var begin = ((vm.currentPage.num - 1) * vm.numPerPage);
            var end = begin + vm.numPerPage;
            vm.filteredCategories = vm.categories.slice(begin, end); 
        }

        function removeCategory(id) {
            deleteConfirmService.confirm("Are you sure you want to Delete this item?", "Delete?", ["OK", "Cancel"])
                .then(function () {
                    quizDataService.deleteCategory(id).then(function (data) {
                        _.remove(vm.categories, { 'id': id });
                        activateCategories();
                    });
                });
        }

        function editCategory(categoryData) {
            var modalInstance = $uibModal.open({
                templateUrl: "Scripts/App/Templates/addEditCategory.html",
                controller: "AddEditCategoryController",
                controllerAs: "vm",
                resolve: {
                    data: function () {
                        return {
                            itemToEdit: categoryData
                        };
                    }
                }
            });
            modalInstance.result.then(function (result) {

                quizDataService.saveCategory(result).then(function (data) {
                    if (categoryData) {
                        _.assign(categoryData, data);
                        activateCategories();
                    } else {
                        activateCategories();
                    }
                });
            });
        }


    }
})();