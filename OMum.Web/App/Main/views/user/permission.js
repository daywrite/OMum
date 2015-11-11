﻿(function () {
    var controllerId = 'app.views.user.permission';
    App.controller(controllerId, [
        'abp.services.app.user','abp.services.app.permission', '$modalInstance', '$scope', 'appSession',
         function (userService,permissionService, $modalInstance, $scope, appSession) {
             var vm = this;
             var tenant = appSession.tenant;
             var data = $scope.data;
             var data_id = data.id;

             permissionService.getPermissions().success(function (r) {
                 $('#tree_permissions').bind("loaded.jstree", function (e, data) {

                     userService.getUserPermissions(data_id).success(function (pResult) {
                         if (pResult) {
                             $.each(pResult, function (i, v) {
                                 $('#tree_permissions').jstree(true)
                               .select_node(v);
                             });
                             //data.inst.open_all(-1); // -1 opens all nodes in the container
                         }
                     })
                 }).jstree({
                     'plugins': ["wholerow", "checkbox", "types"],
                     'core': {
                         "themes": {
                             "responsive": false
                         },
                         'data': r
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
                 //vm.userModel.grantRoleNames = $('#tree_permissions').jstree().get_selected();
                 userService
                     .updateUserPermissions({ userId: data_id, grantedPermissionNames: $('#tree_permissions').jstree().get_selected() })
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