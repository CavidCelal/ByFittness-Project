var person = angular.module("PersonModule", []);

person.factory('PersonFactory', function ($http, $q) {

    return {
        TestMetodu: function () {
            var deferred = $q.defer();
            return deferred.promise;
        },
    }

});

person.service('PersonService', function ($http, $sce, $compile, $q) {

    this.DoGetPersonProjectList = function () {

        var deferred = $q.defer();
        var url = SiteUrl;
        url += '/Api/GetPersonProjectList';

        $http.get(url, {


        }).then(function (returnData) {

            deferred.resolve(returnData);
            return deferred.promise;

        }).catch(function (e) {

            console.log(e.status + " " + e.statusText);
            deferred.resolve(e.status);
            deferred.reject(e);
            return deferred.promise;

        }).finally(function (e) {

        });
        return deferred.promise;

    };

});