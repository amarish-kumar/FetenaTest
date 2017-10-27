(function () {
    "use strict";

    angular.module("quizApp")
        .directive("scoreDetail", function () {
            return {
                restrict: "AE",
                scope: {
                    sd: "="
                },
                template: "<div id='container'></div>",
                link: linkFn
            };

            function linkFn(scope, element, attrs) {
                var options = {
                    title: {
                        text: "Score Detail Dashboard"
                    },
                    xAxis: {
                        categories: []
                    },
                    yAxis: {
                        title: {
                            text: "Score"
                        },
                        plotLines: [
                            {
                                value: 0,
                                width: 1,
                                color: "#808080"
                            }
                        ]
                    },
                    legend: {
                        layout: "vertical",
                        align: "right",
                        verticalAlign: "middle",
                        borderWidth: 0
                    },
                    credits: {
                        enabled: false
                    },
                    series: [
                        {
                            name: "Your Score",
                            type: "column",
                            data: []
                        },
                        {
                            name: "Total Questions",
                            type: "column",
                            data: []
                        },
                        {
                            name: "Overall Users Maximum Score",
                            type: "spline",
                            data: []
                        },
                        {
                            name: "Overall Users Average Score",
                            type: "spline",
                            data: []
                        },
                        {
                            name: "Overall Users Minimum Score",
                            type: "spline",
                            data: []
                        }
                    ]
                };

                scope.$watch("sd", onScoreDataChange);

                function onScoreDataChange(newScoreData) {
                    if (newScoreData) {
                        initialOptions(newScoreData);
                        render();
                    }
                }

                function initialOptions(sd) {
                    var userScores = [];
                    var totalQuestions = [];
                    var maximumScores = [];
                    var averageScores = [];
                    var minimumScores = [];
                    var topics = [];

                    for (var i = 0; i < sd.individualScore.length; i++) {
                        userScores.push(sd.individualScore[i].userScore);
                        totalQuestions.push(sd.individualScore[i].total);
                        topics.push(sd.individualScore[i].topic);
                    }

                    for (var j = 0; j < sd.overallScoreStatistics.length; j++) {
                        maximumScores.push(sd.overallScoreStatistics[j].maximumScore);
                        averageScores.push(sd.overallScoreStatistics[j].averageScore);
                        minimumScores.push(sd.overallScoreStatistics[j].minimumScore);
                    }
                    options.xAxis.categories = topics;
                    options.series[0].data = userScores;
                    options.series[1].data = totalQuestions;
                    options.series[2].data = maximumScores;
                    options.series[3].data = averageScores;
                    options.series[4].data = minimumScores;
                }

                function render() {
                    element.highcharts(options);
                }
            }
        });
}());