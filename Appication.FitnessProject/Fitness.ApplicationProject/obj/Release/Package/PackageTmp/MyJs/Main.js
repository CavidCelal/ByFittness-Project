var InfoApp = angular.module("InfoApplication", ["CommonModule", "PersonModule", "ProjectModule"]);

InfoApp.controller("InfoController", function ($scope, $http, $window, CommonService, PersonService, ProjectService) {

    $scope.ServerDateTime = '';
    $scope.Loading = false;
    $scope.ActiveProjectCount = 0;
    $scope.Project = {
        DurumId: 0,
        OncelikId: 0
    };
    $scope.ProjectPersonList = [];
    $scope.PriorityList = [];
    $scope.StatusList = [];
    $scope.PersonList = [];
    $scope.SelectedPersonId = 0;
    $scope.SelectedPerson = '';

    $scope.LoadSettings = function (Version) {
        CommonService.LoadSettings();
        Lang = CommonService.GetBrowserLang();
        $scope.SiteUrl = CommonService.GetSiteUrl();
        SiteUrl = $scope.SiteUrl;
        $scope.Version = Version;
        alert($scope.SiteUrl);
    };

    $scope.GetServerDateTime = function () {
        $scope.Loading = true;
        CommonService.DoGetServerDateTime().then(function (Response) {
            if (Response.status === 200) {
                $scope.ServerDateTime = Response.data;
            }
        }).catch(function (e) {

        }).finally(function (e) {
            $scope.Loading = false;
        });
    };

    $scope.GetPersonProjectList = function () {
        $scope.Loading = true;
        PersonService.DoGetPersonProjectList().then(function (Response) {
            if (Response.status === 200) {
                $scope.ActiveProjectCount = length(Response.data);
            }
        }).catch(function (e) {

        }).finally(function (e) {
            $scope.Loading = false;
        });
    };

    $scope.AddProject = function () {
        var ff = document.getElementById('ckeditor-classic');
        $scope.Loading = true;
        ProjectService.DoAddProject($scope.Project, $scope.ProjectPersonList).then(function (Response) {
            if (Response.status === 200) {
                //$scope.ActiveProjectCount = length(Response.data);
            }
        }).catch(function (e) {

        }).finally(function (e) {
            $scope.Loading = false;
        });
    };

    $scope.GetProjectRoutiness = function () {
        $scope.Loading = true;
        CommonService.DoGetProjectRoutiness().then(function (Response) {
            if (Response.status === 200) {
                $scope.PriorityList = Response.data.Data[0];
                $scope.StatusList = Response.data.Data[1];
                $scope.PersonList = Response.data.Data[2];
            }
        }).catch(function (e) {

        }).finally(function (e) {
            $scope.Loading = false;
        });
    };


    $scope.SetSelectedPerson = function () {
        $scope.SelectedPerson = document.getElementById('SelectedPersonId').innerText;
    };

    $scope.AddPersonToProject = function () {
        var Kisi = {
            KisiId: $scope.SelectedPersonId
        };
        $scope.ProjectPersonList.push(Kisi);
    };

});