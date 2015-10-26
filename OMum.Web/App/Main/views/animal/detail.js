(function () {
    var controllerId = 'app.views.animaldetail';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.animal', function ($scope, animalService) {
            var vm = this;
    
            var loadAnimalDetail = function () {
                abp.ui.setBusy(
                    null,
                animalService.queryCount().success(function (data) {
                    vm.animal.count = data;
                })
                );
            };

            loadAnimalDetail();
        }
    ]);
})();