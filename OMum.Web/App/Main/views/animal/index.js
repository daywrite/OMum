(function () {
    var controllerId = 'app.views.animalindex';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.animal', function ($scope, animalService) {
            var vm = this;
            vm.animalindex = {};

            vm.animals = [];
            vm.totalAnimalCount = 0;

            var loadAnimalIndex = function () {
                abp.ui.setBusy(
                    null,
                animalService.getAnimals({
                    MaxResultCount: 10,
                    SkipCount: 0,
                    Sorting: "Name DESC"
                }).success(function (data) {
                    for (var i = 0; i < data.items.length; i++) {
                        vm.animals.push(data.items[i]);
                    }

                    vm.totalAnimalCount = data.totalCount;
                })
                );
            };

            loadAnimalIndex();
        }
    ]);
})();