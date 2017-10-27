(function () {
    "use strict";

    angular.module("quizApp").factory("deleteConfirmService", DeleteConfirmService);

    DeleteConfirmService.$inject = ["$uibModal"];

    function DeleteConfirmService($uibModal) {
        var service = {
            confirm: confirm
        };

        return service;

        function confirm(message, title, buttons) {
            var modalInstance = $uibModal.open({
                templateUrl: "Scripts/App/Templates/deleteConfirm.html",
                controller: "DeleteConfirmController",
                controllerAs: "vm",
                resolve: {
                    data: function () {
                        return {
                            message: message,
                            title: title,
                            buttons: buttons
                        };
                    }
                },
                size: "sm"
            });

            return modalInstance.result;
        }
    }
})();