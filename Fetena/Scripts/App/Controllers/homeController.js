(function () {
    "use strict";

    angular.module("quizApp")
        .controller("HomeController", HomeController);

    HomeController.$inject = ["$http", "initialData"];

   function HomeController($http, initialData) {

            var vm = this;

            vm.search = "";
            vm.languages = initialData;
          
  } 
})();