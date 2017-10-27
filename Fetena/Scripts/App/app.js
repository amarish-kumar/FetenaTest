(function() {

    "use strict";

    var app = angular.module("quizApp",
    [
        "ngAnimate",
        "ui.router",
        "ui.bootstrap",
        "quizCommonServices"
    ]);
    app.config([
        "$stateProvider",
        "$urlRouterProvider",
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise("/");

            $stateProvider
                .state("categories",
                {
                    url: "/categories",
                    templateUrl: "Scripts/App/Templates/categories.html",
                    controller: "CategoriesController",
                    controllerAs: "vm"
                })
                .state("home",
                {
                    url: "/",
                    templateUrl: "Scripts/App/Templates/home.html",
                    controller: "HomeController",
                    controllerAs: "vm",
                    resolve: {
                        initialData: ["quizDataService", function(quizDataService) {
                                return quizDataService.getLanguagesUsed();
                            }]
                    }
                })
                .state("languages",
                {
                    url: "/languages",
                    templateUrl: "Scripts/App/Templates/languages.html",
                    controller: "LanguagesController",
                    controllerAs: "vm"
                })
                .state("quizzes",
                {
                    url: "/quizzes",
                    templateUrl: "Scripts/App/Templates/quizzes.html",
                    controller: "QuizzesController",
                    controllerAs: "vm"
                })
                .state("quizDetail",
                {
                    url: "/quiz/:language",
                    templateUrl: "Scripts/App/Templates/quizDetail.html",
                    controller: "QuizDetailController",
                    controllerAs: "vm"
                })
                .state("results",
                {
                    url: "/results",
                    templateUrl: "Scripts/App/Templates/results.html",
                    controller: "ResultsController",
                    controllerAs: "vm"
                })
                .state("resultDetail",
                {
                    url: "/result/:language",
                    templateUrl: "Scripts/App/Templates/resultDetail.html",
                    controller: "ResultDetailController",
                    controllerAs: "vm"
                });
        }
    ]);
})();