module.exports = function (grunt) {
    var libs = ['wwwroot/lib/angular/angular.js', 'wwwroot/lib/angular-ui-router/angular-ui-router.js', 'wwwroot/lib/angular-animate/angular-animate.js'];
    var appFiles = ['wwwroot/app/*.module.js', 'wwwroot/app/*.directive.js', 'wwwroot/app/*.controller.js', 'wwwroot/app/Posts/Services/posts.service.js'];
    var configs = ['wwwroot/app/Posts/Services/routes.js'];
    var testFiles = ['wwwroot/lib/angular-mocks/angular-mocks.js', 'tests/**/*.spec.js'];

    // configure plugins
    grunt.initConfig({
        bower: {
            install: {
                options: {
                    targetDir: "wwwroot/lib",
                    layout: "byComponent",
                    cleanTargetDir: false
                }
            }
        },
        uglify: {
            options: {
                mangle: false,
                compress: false,
                sourceMap: true,
                sourceMapName: 'wwwroot/app/applib.js.map',
                sourceMapIncludeSources: true
            },
            applib: {
                src: [].concat(appFiles, configs),
                dest: 'wwwroot/app/applib.js'
            }
        },
        karma: {
            unit: {
                configFile: 'karma.conf.js',
                options: {
                    files: [].concat(libs, appFiles, testFiles)
                }
            }
        },

        watch: {
            js: {
                files: ['wwwroot/app/**/*.js'],
                tasks: ["uglify"],
                options: {

                    livereload: true
                }
            }
        },
        js: {
            files: ['wwwroot/app/**/*.js'],
            tasks: ['uglify', 'karma'],
            options: {

                livereload: true
            }
        },
        tests: {
            files: ['tests/**/*.js'],
            tasks: ['karma'],
            options: {

                livereload: true
            }
        }
    });

    // define tasks
    grunt.registerTask("default", ["bower:install"]);


    grunt.loadNpmTasks("grunt-karma");
    grunt.loadNpmTasks("grunt-bower-task");

    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-watch");
};