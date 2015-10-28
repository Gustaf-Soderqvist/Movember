describe('posts', function () {

    var service, $httpBackend;

    beforeEach(module('movember'));
    beforeEach(inject(function (posts, _$httpBackend_) {

        service = posts;
        $httpBackend = _$httpBackend_;
    }));


    describe('when listing posts', function () {


        beforeEach(function () {
            $httpBackend.when('GET', '/api/post/').respond([
            {
                name: "test"
            }]);
        });

        it('should get from api url', function () {

            $httpBackend.expectGET('/api/post/');

            service.list();

            $httpBackend.flush();
        });

        it('should return posts', function () {

            var data;

            service.list().then(function (res) {
                data = res;
            });

            $httpBackend.flush();

            expect(data.length).toBe(1);
        });

    });
});
