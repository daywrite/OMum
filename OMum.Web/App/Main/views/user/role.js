(function () {
    var controllerId = 'app.views.user.role';
    App.controller(controllerId, [
        'abp.services.app.user', '$modalInstance', '$scope', 'appSession',
         function (userService, $modalInstance, $scope, appSession) {
             var vm = this;
             var tenant = appSession.tenant;
             var data = $scope.data;

             userService.getUser(data.id).success(function (result) {
                 vm.userModel = result;
                 var treedata = [];
                 $.each(result.allRoleNames, function (i, v) {
                     treedata.push({ text: v, id: v });
                 });

                 $('#tree_roles').bind("loaded.jstree", function (e, data) {
                     $.each(result.grantRoleNames, function (i, v) {
                         $('#tree_roles').jstree(true)
                       .select_node(v);
                     });

                 }).jstree({
                     'plugins': ["wholerow", "checkbox", "types"],
                     'core': {
                         "themes": {
                             "responsive": false
                         },
                         'data': treedata
                     },
                     "types": {
                         "default": {
                             "icon": "fa fa-folder icon-state-warning icon-lg"
                         },
                         "file": {
                             "icon": "fa fa-file icon-state-warning icon-lg"
                         }
                     }
                 });
             });

             vm.save = function () {
                 vm.userModel.grantRoleNames = $('#tree_roles').jstree().get_selected();
                 userService
                     .saveRole(vm.userModel)
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