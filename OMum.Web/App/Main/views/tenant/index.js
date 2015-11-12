(function () {
    App.controller("TenantContraller", [
        '$scope', 'abp.services.app.tenant', '$modal', '$rootScope', function ($scope, tenantService, $modal, $rootScope) {
            var vm = this;

            vm.tenants = [];
            //分页基本参数
            $scope.paginationConf = {
                currentPage: 1,
                itemsPerPage: 10,
                perPageOptions: [5, 10, 15, 20]
            };

            var loadTenant = function () {

                //查询参数
                var postData = {
                    MaxResultCount: 100,
                    pageIndex: $scope.paginationConf.currentPage,
                    pageSize: $scope.paginationConf.itemsPerPage
                }

                abp.ui.setBusy(
                    null,
                    tenantService.getTenants(postData).success(function (data) {
                        $scope.paginationConf.totalItems = data.totalCount;
                        vm.tenants = data.items;
                    }).error(function (data) {
                        abp.message.info("错误",data.message);
                    })
                );
            };

            $scope.$watch('paginationConf.currentPage + paginationConf.itemsPerPage', loadTenant);

            //创建租户
            vm.showNewTenant = function () {
                var modalInstance = $modal.open({
                    templateUrl: abp.appPath + 'App/Main/views/tenant/create.html',
                    controller: 'app.views.tenant.create as vm',
                    size: 'md'
                });

                modalInstance.result.then(function () {
                    loadTenant();
                });
            };

            //更新租户
            vm.updateTenant = function (index) {

                var scope = $rootScope.$new();
                scope.data = vm.tenants[index];

                var modalInstance = $modal.open({
                    templateUrl: abp.appPath + 'App/Main/views/tenant/create.html',
                    controller: 'app.views.tenant.create as vm',
                    size: 'md',
                    scope: scope
                });

                modalInstance.result.then(function () {
                    loadTenant();
                });
            };

            //删除租户
            vm.updateTenant = function (index) {

                var scope = $rootScope.$new();
                scope.data = vm.tenants[index];

                var modalInstance = $modal.open({
                    templateUrl: abp.appPath + 'App/Main/views/tenant/create.html',
                    controller: 'app.views.tenant.create as vm',
                    size: 'md',
                    scope: scope
                });

                modalInstance.result.then(function () {
                    loadTenant();
                });
            };

            vm.deleteTenant = function (index) {
                var data = vm.tenants[index];
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("确定要删除此租户？", function (r) {
                    if (r) {
                        tenantService.deleteTenant(data.id).success(function (data) {
                            loadTenant();
                        });
                    }
                });
               
            };
        }
    ]);
})();