var gulp = require('gulp'),
$ = require('gulp-load-plugins')({pattern: ['gulp-*']}),
paths = {src: 'src/', dist: 'dist/', dev: 'dev/', entry: 'entry.scss'};

var browserSync = require('browser-sync').create();
var cleanCSS = require('gulp-clean-css');

// Error handling
// 
var onError = function (err) {
	$.notify.onError({
		title: "Gulp",
		subtitle: "Failure!",
		message: "Error: <%= error.message %>",
		sound: "Beep"
	})(err);
	this.emit('end');
};

// Default tasks
// 
gulp.task('default', function() {
	return gulp.src(paths.src+paths.entry)
	.pipe($.plumber({errorHandler: onError}))
	.pipe($.sourcemaps.init())
	.pipe($.sass({compress: false, outputStyle: 'expanded'}).on('error', $.util.log))
	.pipe($.autoprefixer({
		browsers: ['last 3 versions'],
		cascade: false
	}))
	.pipe($.rename({
		basename: 'library'
	}))
	.pipe($.sourcemaps.write())
	.pipe(gulp.dest(paths.dev))
	.pipe($.size({title: 'Development', showFiles: true}))
	.pipe(browserSync.reload({
		stream: true
	}));
});

// Build production ready sass
// 
gulp.task('build', function() {
	return gulp.src(paths.src+paths.entry)
	.pipe($.plumber({errorHandler: onError}))
	.pipe($.sass({compress: true, outputStyle: 'compressed'}).on('error', $.util.log))
	.pipe($.autoprefixer({
		browsers: ['last 3 versions'],
		cascade: false
	}))
	.pipe($.combineMq({beautify: false}))
	.pipe($.csso())
	.pipe($.csscomb())
	.pipe(cleanCSS({keepSpecialComments: false, mediaMerging: true, roundingPrecision: 4, advanced: true, aggressiveMerging: true}))
	.pipe($.rename({
		basename: 'library',
		suffix: '.min'
	}))
	.pipe(gulp.dest(paths.dist))
	.pipe($.size({title: 'Production', showFiles: true}))
	.pipe(browserSync.reload({
		stream: true
	}));
});

// Build production ready sass for native projects (hybrid apps, no internet access, etc.)
// 
gulp.task('build-native', function() {
	return gulp.src(paths.src+paths.entry)
	.pipe($.plumber({errorHandler: onError}))
	.pipe($.sass({compress: true, outputStyle: 'compressed'}).on('error', $.util.log))
	.pipe($.autoprefixer({
		browsers: ['last 3 versions'],
		cascade: false
	}))
	.pipe($.combineMq({beautify: false}))
	.pipe($.csso())
	.pipe($.csscomb())
	.pipe(cleanCSS({keepSpecialComments: false, mediaMerging: true, roundingPrecision: 4, advanced: true, aggressiveMerging: true}))
	.pipe($.rename({
		basename: 'library',
		suffix: '.native.min'
	}))
	.pipe(gulp.dest(paths.dist))
	.pipe($.size({title: 'Production', showFiles: true}))
	.pipe(browserSync.reload({
		stream: true
	}));
});

// Watch
// 
// You can change "default" to "build" to see the production code.
// You can also simply - $ gulp build - to compile production code.
// 
gulp.task('watch', ['browserSync', 'default'], function (){
  // gulp.watch(['src/scss/**/*.scss', 'src/**/*.scss'], ['build']); 
  gulp.watch('src/**/*.scss', ['default']); 
  // Other watchers
  gulp.watch('*.html', browserSync.reload); 
  gulp.watch('js/**/*.js', browserSync.reload); 
});

// Browser Refresh
// 
gulp.task('browserSync', function() {
  browserSync.init({
    server: {
      // because gulpfile.js is in the root leave baseDir empty 
      baseDir: '../'
    },
  })
})