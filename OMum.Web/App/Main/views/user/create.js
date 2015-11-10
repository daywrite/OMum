(function () {
    var controllerId = 'app.views.user.create';
    App.controller(controllerId, [
        'abp.services.app.user', '$modalInstance', '$scope', 'appSession',
         function (userService, $modalInstance, $scope, appSession) {
             var vm = this;
             var tenant = appSession.tenant;
             vm.user = {
                 id: 0,
                 name: '',
                 surname: '',
                 userName: '',
                 emailAddress: '',
                 isEmailConfirmed: false,
                 isActive: false,
                 tenantId: appSession ? tenant.id : null
             };

             var data = $scope.data;
             if (data != null) {
                 vm.user = {
                     id: data.id,
                     name: data.name,
                     surname: data.surname,
                     userName: data.userName,
                     emailAddress: data.emailAddress,
                     isEmailConfirmed: data.isEmailConfirmed,
                     isActive: data.isActive,
                     tenantId: data.tenantId
                 };
             }

             vm.save = function () {
                 userService
                     .saveUser(vm.user)
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