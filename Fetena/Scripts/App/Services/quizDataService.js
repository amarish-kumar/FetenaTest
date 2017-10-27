(function () {

    "use strict";

    angular.module("quizApp")
        .factory("quizDataService", quizDataService);

    quizDataService.$inject = ["$http","appSettings"];

    function quizDataService($http, appSettings) {

        var service = {
            addAnswer: addAnswer,
            getAnswers: getAnswers,
            deleteCategory: deleteCategory,
            deleteLanguage: deleteLanguage,
            deleteLevel: deleteLevel,
            deleteQuiz: deleteQuiz,
            getCategory: getCategory,
            getCategories: getCategories,
            getCategoriesUsed: getCategoriesUsed,
            getLanguage: getLanguage,
            getLanguages: getLanguages,
            getLanguagesUsed: getLanguagesUsed,
            getLevel: getLevel,
            getLevels: getLevels,
            getLevelsUsed: getLevelsUsed,
            getQuiz: getQuiz,
            getQuizzes: getQuizzes,
            saveCategory: saveCategory,
            saveLanguage: saveLanguage,
            saveLevel: saveLevel,
            saveQuiz: saveQuiz
        };

        return service;

        function addAnswer(questionId, userAnswer) {
            var answer = { 'quizId': questionId, 'selectedAnswer': userAnswer };
            return httpPost("/answers", answer);
        }

        function getAnswers(language) {
            var url = "/answers?language=" + language;
            return httpGet(url);
        }

        function deleteCategory(categoryId) {
            return httpDelete("/categories/" + categoryId);
        }

        function deleteLanguage(languageId) {
            return httpDelete("/languages/" + languageId);
        }

        function deleteLevel(levelId) {
            return httpDelete("/levels/" + levelId);
        }

        function deleteQuiz(quizId) {
            return httpDelete("/quizzes/" + quizId);
        }

        function getCategory(categoryId) {
            return httpGet("/categories/" + categoryId);
        }

        function getCategories() {
            return httpGet("/categories");
        }

        function getCategoriesUsed(language, level) {
            var url = "/getCategories?language=" + language + "&level=" + level;
            return httpGet(url);
        }

        function getLanguage(languageId) {
            return httpGet("/languages" + languageId);
        }

        function getLanguages() {
            return httpGet("/languages");
        }

        function getLanguagesUsed() {
            return httpGet("/getlanguageslist");
        }

        function getLevel(levelId) {
            return httpGet("/levels" + levelId);
        }

        function getLevels() {
            return httpGet("/levels");
        }

        function getLevelsUsed(language) {
            return httpGet("/getlevels?language=" + language);
        }

        function getQuiz(quizId) {
            return httpGet("/getQuizById" + quizId);
        }

        function getQuizzes(language, level, category) {
            return httpGet("/getQuizzes?language=" + language + "&level=" + level + "&category=" + category);
        }

        function saveCategory(category) {
            return saveItem("/categories", category);
        }

        function saveLanguage(language) {
            return saveItem("/languages", language);
        }

        function saveLevel(level) {
            return saveItem("/levels", level);
        }

        function saveQuiz(quiz) {
            return saveItem("/quizzes", quiz);
        }

        function httpExecute(requestUrl, method, data) {
            //appSpinner.showSpinner();
            return $http({
                url: appSettings.baseUrl + requestUrl,
                method: method,
                data: data
                //headers: requestConfig.headers
            }).then(function (response) {

                // appSpinner.hideSpinner();
                console.log('**response from EXECUTE', response);
                return response.data;
            });
        }

        function httpDelete(url) {
            return httpExecute(url, "DELETE");
        }

        function httpGet(url) {
            return httpExecute(url, "GET");
        }

        function httpPut(url, data) {
            return httpExecute(url, "PUT", data);
        }

        function httpPost(url, data) {
            return httpExecute(url, "POST", data);
        }

        function saveItem(url, item) {
            if (item.id) {
                return httpPut(url + "/" + item.id, item);
            } else {
                return httpPost(url, item);
            }
        }
    }
})();