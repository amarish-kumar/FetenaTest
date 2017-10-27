(function () {
    "use strict";

    angular.module("quizApp")
        .controller("ResultsController", ResultsController);

    ResultsController.$inject = ["$stateParams", "quizDataService"];

    function ResultsController(quizDataService) {

        var vm = this;

        getResults();

        function getResults() {
            quizDataService.getAnswers(vm.language)
            .then(function (data) {
                vm.results = data;
            });
        }
    }
})();