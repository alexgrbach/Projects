var GetStaticPages = angular.module('StaticPagesApp', ['ngSanitize']);

GetStaticPages.factory('StaticPagesFactory',
    function ($http) {
        var webAPIProvider = {};
        var url = '/api/StaticPages';

        //returns data
        webAPIProvider.getPosts = function () {
            return $http.get(url);
        };
        return webAPIProvider;
    });

//controller to get list of pages
GetStaticPages.controller('StaticPagesController',
    function ($scope, StaticPagesFactory) {
        //calls the http.get method from our http object
        StaticPagesFactory.getPosts()
        .success(function (data) {
            $scope.StaticPages = data;

        })


    });