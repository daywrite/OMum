(function () {
    App.controller("AnimalContraller", [
        '$scope', 'abp.services.app.animal', '$modal', '$rootScope', 'appSession', function ($scope, entityService, $modal, $rootScope, appSession) {
            var vm = this;
            var tenantId;

            var tenant = appSession.tenant;

            vm.entities = [];
            //分页基本参数
            $scope.paginationConf = {
                currentPage: 1,
                itemsPerPage: 10,
                perPageOptions: [5, 10, 15, 20]
            };

            var loadEntity = function () {
                //abp.message.success("1", "1");
                //查询参数
                var postData = {
                    MaxResultCount: 100,
                    pageIndex: $scope.paginationConf.currentPage,
                    pageSize: $scope.paginationConf.itemsPerPage,
                    sorting : "Name DESC",
                    tenantId: appSession ? tenant.id : null
                }

                abp.ui.setBusy(
                    null,
                    entityService.getAnimals(postData).success(function (data) {
                        $scope.paginationConf.totalItems = data.totalCount;
                        vm.entities = data.items;
                    })
                );
            };

            $scope.$watch('paginationConf.currentPage + paginationConf.itemsPerPage', loadEntity);

            //创建用户
            vm.showNewEntity = function () {
                var modalInstance = $modal.open({
                    templateUrl: abp.appPath + 'App/Main/views/animal/create.html',
                    controller: 'app.views.animal.create as vm',
                    size: 'md'
                });

                modalInstance.result.then(function () {
                    loadEntity();
                });
            };
        
            vm.delete = function (index) {
                var data = vm.entities[index];
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("确定要删除此动物？", function (r) {
                    if (r) {
                        entityService.deleteAnimal(data.id).success(function (data) {
                            loadEntity();
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
        }
    ]);
})();