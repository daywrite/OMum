(function () {
    var controllerId = 'app.views.animal';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.animal', function ($scope, animalService) {
            var vm = this;
            vm.animal = {};

            vm.phones = [{ "name": "Nexus S", "snippet": "Fast just got faster with Nexus S." },
                        { "name": "Motorola XOOM™ with Wi-Fi", "snippet": "The Next, Next Generation tablet." },
                        { "name": "MOTOROLA XOOM™", "snippet": "The Next, Next Generation tablet." }
            ];

            var loadAnimal = function () {
                abp.ui.setBusy(
                    null,
                animalService.queryCount().success(function (data) {
                    vm.animal.count = data;
                })
                );
            };

            loadAnimal();
        }
    ]);
})();