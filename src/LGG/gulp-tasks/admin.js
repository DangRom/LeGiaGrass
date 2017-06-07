var gulp = require('gulp');
var del = require('del');
var sass = require('gulp-sass');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var cleanCss = require('gulp-clean-css');
var uncss = require('gulp-uncss');
var ts = require('gulp-typescript');
var tsProject = ts.createProject('tsconfig.json');

function clean() {
    return del([
        'temp/admin/**',
        'wwwroot/admin/app/**'
    ]);
}

function styles() {
    return gulp.src(['./dev/admin/app.scss'])
        .pipe(sass({ outputStyle: 'compressed' })
            .on('error', sass.logError))
        .pipe(cleanCss({ keepSpecialComments: 0 }))
        .pipe(gulp.dest('wwwroot/admin/'));
}

function componentStyles() {
    return gulp.src(['./dev/admin/components/**/*.scss'])
        .pipe(sass({ outputStyle: 'compressed' })
            .on('error', sass.logError))
        .pipe(cleanCss({ keepSpecialComments: 0 }))
        .pipe(gulp.dest('wwwroot/admin/app/components'));
}

function libs() {
    return gulp.src([
        'wwwroot/lib/jquery/dist/jquery.js',
        'wwwroot/lib/foundation-sites/dist/js/plugins/foundation.core.js',
        'wwwroot/lib/foundation-sites/dist/js/plugins/foundation.responsiveToggle.js',
        'wwwroot/lib/foundation-sites/dist/js/plugins/foundation.util.mediaQuery.js'
    ])
        .pipe(concat('libs.js'))
        .pipe(uglify())
        .pipe(gulp.dest('wwwroot/admin/libs'));
}

function moveLibs() {
    var libs = {
        "@angular": '@angular/**/bundles/*.js',
        "systemjs": 'systemjs/dist/system.src.js',
        "rxjs": 'rxjs/**/*.js',
        "core-js": 'core-js/client/shim.min.js',
        "zone.js": 'zone.js/dist/zone.js',
        "quill": 'quill/dist/quill.min.js'
    };
   
    for (var name in libs) {
        if (libs.hasOwnProperty(name)) {
            gulp.src('node_modules/' + libs[name])
                .pipe(gulp.dest('wwwroot/admin/libs/' + name));
        }
    }
    
    return new Promise(function (resolve) {
        resolve();
    });
}

function moveStyles() {
    return gulp.src(['./node_modules/quill/dist/quill.snow.css'])
        .pipe(cleanCss({ keepSpecialComments: 0 }))
        .pipe(gulp.dest('wwwroot/admin/css'));
}

function scripts() {
    return gulp.src([
        'temp/admin/**/*'
    ], { base: './temp/admin/' })
        .pipe(gulp.dest('wwwroot/admin/app'));
}

function templates() {
    return gulp.src([
        'dev/admin/components/**/*.html'
    ], { base: './dev/admin/components/' })
        .pipe(gulp.dest('wwwroot/admin/app/components'));
}

function typescript() {
    return tsProject.src()
        .pipe(tsProject())
        .pipe(gulp.dest('temp'));
}

function watch() {
    gulp.watch('./dev/admin/**/*.scss', styles);
    gulp.watch('./dev/admin/components/**/*.html', templates);
    gulp.watch('./dev/admin/**/*.ts', gulp.series(typescript, scripts));
}

gulp.task('admin-dev', gulp.series(
    clean,
    moveLibs,
    moveStyles,
    libs,
    typescript,
    scripts,
    templates,
    styles,
    gulp.parallel(watch)
));

gulp.task('admin', gulp.series(
    clean,
    moveLibs,
    moveStyles,
    libs,
    typescript,
    scripts,
    templates,
    styles
));
