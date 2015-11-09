(function () {
    var controllerId = 'app.views.tenant.create';
    App.controller(controllerId, [
        'abp.services.app.tenant', '$modalInstance', '$scope',
         function (tenantService, $modalInstance, $scope) {
             var vm = this;
             vm.tenant = {
                 id: 0,
                 name: '',
                 tenancyName: '',
                 isActive: false
             };

             var data = $scope.data;
             if (data != null) {
                 vm.tenant = {
                     id: data.id,
                     name: data.name,
                     tenancyName: data.tenancyName,
                     isActive: data.isActive
                 };
             }

             vm.save = function () {
                 tenantService
                     .createTenant(vm.tenant)
                     .success(function () {
                         $modalInstance.close();
                     });
             };

             vm.cancel = function () {
                 $modalInstance.dismiss('cancel');
             };
         }
    ]);
})();