var gulp = require('gulp');
var concat = require('gulp-concat');
var cssmin = require('gulp-cssmin');
var uncss = require('gulp-uncss');
var browserSync = require('browser-sync').create();

gulp.task('browser-sync', function () {
    browserSync.init({
        proxy: 'https://localhost:5000/'
    });

    gulp.watch('./styles/**/*.css', ['css']);
    gulp.watch('./js/**/*.js', ['js']);
});

gulp.task('js', function () {
    return gulp.src([
        //'./node_modules/bootstrap/dist/js/bootstrap.min.js',
        //'./node_modules/jquery/dist/jquery.min.js',
        //'./node_modules/jquery-validation/dist/jquery.validate.min.js',
        //'./node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
        //'./js/site.js'
        './wwwroot/lib/bootstrap/dist/js/bootstrap.min.js',
        './wwwroot/lib/jquery/dist/jquery.min.js',
        './wwwroot/lib/jquery-validation/dist/jquery.validate.min.js',
        './wwwroot/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js',
        './js/site.js'
    ])
        .pipe(gulp.dest('wwwroot/js/'))
        .pipe(browserSync.stream());
});

gulp.task('css', function () {
    return gulp.src([
        //'./Styles/site.css',
        //'./node_modules/bootstrap/dist/css/bootstrap.css'
        './Styles/site.css',
        './wwwroot/lib/bootstrap/dist/css/bootstrap.css'
    ])
        .pipe(concat('site.min.css'))
        .pipe(cssmin())
        .pipe(uncss({ html: ['Views/**/*.cshtml'] }))
        .pipe(gulp.dest('wwwroot/css/'))
        .pipe(browserSync.stream());
});

// gulp.task('watch-css', function(){
//   gulp.watch('./styles/**/*.css', ['css']);
// });