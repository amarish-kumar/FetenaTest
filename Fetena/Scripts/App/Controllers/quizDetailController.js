(function () {

    "use strict";

    angular.module("quizApp")
        .controller("QuizDetailController", QuizDetailController);

    QuizDetailController.$inject = ["$http","$stateParams", "quizDataService"];

    function QuizDetailController($http, $stateParams, quizDataService) {

        var vm = this;

        vm.activeQuestion = -1;
        vm.category = { name: "" };
        vm.categories = [];
        vm.correctAnswer = "";
        vm.correctness = "";
        vm.counter = 1;
        vm.getCategories = getCategories;
        vm.isLoading = false;
        vm.isSelected = isSelected;
        vm.isCorrect = isCorrect;
        vm.language = $stateParams.language;
        vm.level = { name: "" };
        vm.levels = [];
        vm.nextQuestion = nextQuestion;
        vm.numberOfAnsweredQuestions = 1;
        vm.numberOfCorrectAnswers = 0;
        vm.numberOfIncorrectAnswers = 0;
        vm.questionState = "";
        vm.quizzes = [];
        vm.selectAnswer = selectAnswer;
        vm.selectedAnswer = "";
        vm.showProgress = false;
        vm.startQuiz = startQuiz;
        vm.totalQuestions = 0;
        vm.working = false;

        getLevels();

        function getLevels() {
            quizDataService.getLevelsUsed(vm.language)
                .then(function(data) {
                    vm.levels = data;
                });
        }

        function getCategories() {
            quizDataService.getCategoriesUsed(vm.language, vm.level.name)
                .then(function(data) {
                    vm.categories = data;
                });
        }

        function startQuiz() {
            quizDataService.getQuizzes(vm.language, vm.level.name, vm.category.name)
                .then(function(data) {
                    vm.quizzes = data;
                    vm.totalQuestions = vm.quizzes.length;
                });
            vm.activeQuestion = 0;
            vm.showProgress = true;
        };

        function postAnswer(question, userAnswer) {
            quizDataService.addAnswer(question.id, userAnswer)
                .then(function(data) {
                    vm.correctAnswer = data;
                    if (vm.correctAnswer === vm.selectedAnswer + 1) {
                        vm.numberOfCorrectAnswers++;
                    } else {
                        vm.numberOfIncorrectAnswers++;
                    }
                });
        }

        function selectAnswer(question, choiceIndex) {
            var userAnswer = (choiceIndex + 1);
            if (vm.questionState !== "answered") {
                vm.selectedAnswer = choiceIndex;
                postAnswer(question, userAnswer);
                vm.questionState = "answered";
            }
        }

        function isSelected(choiceIndex) {
            return vm.selectedAnswer === choiceIndex;
        }

        function isCorrect(choiceIndex) {
            if(vm.questionState === "answered")
                return vm.correctAnswer === (choiceIndex + 1);
            return false;
        }

        function nextQuestion() {
            vm.questionState = "";
            vm.selectedAnswer = "";
            vm.counter++;
            if (vm.numberOfAnsweredQuestions < vm.totalQuestions)
                vm.numberOfAnsweredQuestions++;
            return vm.activeQuestion++;
        }
    }

})();