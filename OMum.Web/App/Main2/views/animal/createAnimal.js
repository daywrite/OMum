(function () {
    var controllerId = 'app.views.animal.createAnimal';
    angular.module('app').controller(controllerId, [
        'abp.services.app.animal', '$modalInstance',
        function (questionService, $modalInstance) {
            var vm = this;

            vm.animal = {
                name: '',
                text: ''
            };

            vm.save = function () {
                questionService
                    .createAnimal(vm.animal)
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