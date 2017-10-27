(function () {
    "use strict";
    
    angular.module("quizApp")
        .controller("ResultDetailController", ResultDetailController);

    ResultDetailController.$inject = ["$stateParams", "quizDataService"];

    function ResultDetailController($stateParams, quizDataService) {

        var vm = this;

        vm.language = $stateParams.language;

        getResults();

        function getResults() {
            quizDataService.getAnswers(vm.language)
            .then(function (data) {
                vm.results = data;
            });
        }
    }
})();