(function () {
    App.controller("UserContraller", [
        '$scope', 'abp.services.app.user', '$modal', '$rootScope', 'appSession', function ($scope, userService, $modal, $rootScope, appSession) {
            var vm = this;
            var tenantId;

            var tenant = appSession.tenant;

            vm.users = [];
            //分页基本参数
            $scope.paginationConf = {
                currentPage: 1,
                itemsPerPage: 10,
                perPageOptions: [5, 10, 15, 20]
            };

            var loadUser = function () {

                //查询参数
                var postData = {
                    MaxResultCount: 100,
                    pageIndex: $scope.paginationConf.currentPage,
                    pageSize: $scope.paginationConf.itemsPerPage,
                    tenantId: appSession ? tenant.id : null
                }

                abp.ui.setBusy(
                    null,
                    userService.getUsers(postData).success(function (data) {
                        $scope.paginationConf.totalItems = data.totalCount;
                        vm.users = data.items;
                    })
                );
            };

            $scope.$watch('paginationConf.currentPage + paginationConf.itemsPerPage', loadUser);

            //创建用户
            vm.showNewUser = function () {
                var modalInstance = $modal.open({
                    templateUrl: abp.appPath + 'App/Main/views/user/create.html',
                    controller: 'app.views.user.create as vm',
                    size: 'md'
                });

                modalInstance.result.then(function () {
                    loadUser();
                });
            };

            //更新用户
            vm.update = function (index) {

                var scope = $rootScope.$new();
                scope.data = vm.users[index];

                var modalInstance = $modal.open({
                    templateUrl: abp.appPath + 'App/Main/views/user/create.html',
                    controller: 'app.views.user.create as vm',
                    size: 'md',
                    scope: scope
                });

                modalInstance.result.then(function () {
                    loadUser();
                });
            };            

            vm.delete = function (index) {
                var data = vm.users[index];
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("确定要删除此用户？", function (r) {
                    if (r) {
                        userService.deleteUser(data.id).success(function (data) {
                            loadUser();
                        });
                    }
                });

            };

            //创建用户角色
            vm.showUserRole = function (index) {
                var scope = $rootScope.$new();
                scope.data = vm.users[index];
                var modalInstance = $modal.open({
                    templateUrl: abp.appPath + 'App/Main/views/user/role.html',
                    controller: 'app.views.user.role as vm',
                    size: 'md',
                    scope: scope
                });

                modalInstance.result.then(function () {
                    //loadUser();
                });
            };

            //创建用户权限
            vm.showUserPermission = function (index) {
                var scope = $rootScope.$new();
                scope.data = vm.users[index];
                var modalInstance = $modal.open({
                    templateUrl: abp.appPath + 'App/Main/views/user/permission.html',
                    controller: 'app.views.user.permission as vm',
                    size: 'md',
                    scope: scope
                });

                modalInstance.result.then(function () {
                    //loadUser();
                });
            };
        }
    ]);
})();