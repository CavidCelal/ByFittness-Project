var common = angular.module("CommonModule", []);

common.factory('CommonFactory', function ($http, $q) {

    return {
        TestMetodu: function () {            
            var deferred = $q.defer();            
            return deferred.promise;
        },
    }

});
