(function () {
    "use strict";

    angular.module("quizApp").controller("DeleteConfirmController", DeleteConfirmController);

    DeleteConfirmController.$inject = ["$uibModalInstance", "data"];

    function DeleteConfirmController($uibModalInstance, data) {

        var vm = this;

        vm.cancel = cancel;
        vm.ok = ok;
        vm.properties = data;
        
        function cancel() {
            $uibModalInstance.dismiss();
        }

        function ok() {
            $uibModalInstance.close();
        }
    }
})();