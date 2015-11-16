(function () {
    var controllerId = 'app.views.animal.create';
    App.controller(controllerId, [
        'abp.services.app.animal', '$modalInstance', '$scope', 'appSession',
         function (animalService, $modalInstance, $scope, appSession) {
             var vm = this;
             var tenant = appSession.tenant;
             vm.entity = {
                 id: 0,
                 name: '',              
                 tenantId: appSession ? tenant.id : null
             };

             var data = $scope.data;
             if (data != null) {
                 vm.entity = {
                     id: data.id,
                     name: data.name,                   
                     tenantId: data.tenantId
                 };
             }

             vm.save = function () {
                 animalService
                     .createAnimal(vm.entity)
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