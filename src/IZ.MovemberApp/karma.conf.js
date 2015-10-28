module.exports = function (config) {
    config.set({

        basePath: './',

        frameworks: ['jasmine'],

        reporters: ['mocha'],

        junitReporter: {
            outputFile: 'test-results.xml'
        },

        port: 9876,

        colors: true,

        logLevel: config.LOG_INFO,

        autoWatch: true,

        browsers: ['PhantomJS'],

        captureTimeout: 20000,

        singleRun: true,

        reportSlowerThan: 500
    });
};