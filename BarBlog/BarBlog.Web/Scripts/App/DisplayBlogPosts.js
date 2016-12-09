var GetBlogPosts = angular.module('PublicPostsApp', ['ngSanitize', 'angularUtils.directives.dirPagination']);
GetBlogPosts.factory('BlogPostsFactory',
    function ($http) {
        var webAPIProvider = {};
        var url = '/api/BlogPosts/';
        //returns data
        webAPIProvider.getPosts = function () {
            return $http.get(url);
        };
        return webAPIProvider;
    });

//controller to get list of posts
GetBlogPosts.controller('PublicApiController',
    function ($scope, BlogPostsFactory) {
        $scope.currentPage = 1;
        $scope.pageSize = 5;
        //calls the http.get method from our http object
        BlogPostsFactory.getPosts()
        .success(function (data) {
            $scope.BlogPosts = data;

        });
        //adds search functionality to a textbox labled ng-app="query"
        $scope.search = function (post) {
            return (angular.lowercase(post.PostBody).indexOf(angular.lowercase($scope.query) || '') !== -1 ||
                    angular.lowercase(post.PostTitle).indexOf(angular.lowercase($scope.query) || '') !== -1);
        };
        $scope.date = function (post) {

            var filtered = [];
            angular.forEach(post, function (item) {
                if ((Date.parse(post.PostDate) > Date.parse($scope.startDate) && Date.parse(post.PostDate) <= Date.parse($scope.endDate))) {
                    filtered.push(item)
                }
            });
            return filtered;
        };
    });

