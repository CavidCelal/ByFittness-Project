var project = angular.module("ProjectModule", []);

project.factory('ProjectFactory', function ($http, $q) {

    return {
        TestMetodu: function () {
            var deferred = $q.defer();
            return deferred.promise;
        },
    }

});

project.service('ProjectService', function ($http, $sce, $compile, $q) {

    this.DoAddProject = function (Project, ProjectPersonList) {

        var deferred = $q.defer();
        var url = SiteUrl;
        url += '/Api/AddProject';
        var params = { "Proje": Project, "ProjeKisileri": ProjectPersonList };
        $http.post(url, params, {


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