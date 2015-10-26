(function () {
    var controllerId = 'app.views.animalindex';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.animal', function ($scope, animalService) {
            var vm = this;
            vm.animalindex = {};

            var loadAnimalIndex = function () {
                abp.ui.setBusy(
                    null,
                animalService.GetAnimals({
                    MaxResultCount: 10,
                    SkipCount: 0,
                    Sorting: "Name DESC"
                }).success(function (data) {
                    vm.animalindex.count = data;
                })
                );
            };

            loadAnimalIndex();
        }
    ]);
})();