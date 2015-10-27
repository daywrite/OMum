(function () {
    var controllerId = 'app.views.animalindex';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.animal', '$modal', function ($scope, animalService, $modal) {
            var vm = this;

            vm.animals = [];
            vm.totalAnimalCount = 0;
            vm.sorting = "Name DESC";

            vm.loadAnimalIndex = function (addpend) {
                var skipCount = addpend ? vm.animals.length : 0;
                abp.ui.setBusy(
                    null,
                animalService.getAnimals({
                    //MaxResultCount: 10,
                    SkipCount: skipCount,
                    Sorting: vm.sorting
                }).success(function (data) {
                    if (addpend) {
                        for (var i = 0; i < data.items.length; i++) {
                            vm.animals.push(data.items[i]);
                        }
                    } else {
                        vm.animals = data.items;
                    }

                    vm.totalAnimalCount = data.totalCount;
                })
                );
            };

            vm.showNewAnimal = function () {
                var modalInstance = $modal.open({
                    templateUrl: abp.appPath + 'App/Main/views/animal/createAnimal.cshtml',
                    controller: 'app.views.animal.createAnimal as vm',
                    size: 'md'
                });

                modalInstance.result.then(function () {
                    vm.loadAnimalIndex();
                });
            };

            vm.sort = function (sortingDirection) {
                vm.sorting = sortingDirection;
                vm.loadQuestions();
            };

            vm.showMore = function () {
                vm.loadAnimalIndex(true);
            };

            vm.loadAnimalIndex();
        }
    ]);
})();