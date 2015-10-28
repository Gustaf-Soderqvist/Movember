describe('list controller', function () {

    beforeEach(module('movember'));

    var ctrl, scope;
    var $state;
    var postList = [{ name: "test" }];

    beforeEach(inject(function ($injector, $controller, $rootScope) {
        scope = $rootScope.$new();

        $state = jasmine.createSpyObj('$state', ['go']);

        ctrl = $controller('ListPostController', { $scope: scope, postlist: postList, $state: $state });
    }));

    describe('when loaded', function () {
        it('should have posts', function () {
            expect(ctrl.posts).toBe(postList);
        });
    });

    describe('new post', function () {
        it('should go to new post page', function () {

            ctrl.new();

            expect($state.go).toHaveBeenCalledWith('new');
        });
    });

});
