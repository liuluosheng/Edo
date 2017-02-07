require.config({
    baseUrl: "/scripts/modules/",
    paths: {
        'jquery': '/scripts/jquery-1.12.4.min',
        'jquery-scrollbars': '/scripts/ng-scrollbars/jquery.mCustomScrollbar.concat.min',
        'angular': '/scripts/angular',
        'bootstrap': '/scripts/bootstrap.min',
        'angular-messages': '/scripts/angular-messages.min',
        'angular-sanitize': '/scripts/angular-sanitize.min',
        'angular-scrollbars': '/scripts/ng-scrollbars/scrollbars',
        'moment': "/scripts/moment.min",
        'angular-datetimepicker': "/scripts/angular-datetimepicker/datetimepicker",
        'angular-datetimepicker-templates': "/scripts/angular-datetimepicker/datetimepicker.templates",
        'angular-toast': "/scripts/angular-toastr.tpls.min",
        'sweetalert': '/scripts/sweetalert.min',
        'angular-sweetalert': '/scripts/sweetalert-angular',
        'angularui-bootstrap': '/scripts/angular-ui/ui-bootstrap-tpls.min'
    },
    shim: {
        'jquery': {
            exports: '$'
        },
        'angular': {
            exports: 'angular',
            deps: ['jquery']
        },
        'angular-datetimepicker-templates': {
            deps: ['moment', 'bootstrap', 'angular-datetimepicker']
        },
        'angular-scrollbars': {
            deps: ['jquery-scrollbars']
        },
        'angular-sweetalert': {
            deps: ['sweetalert']
        }
    },
    deps: ['angular', 'app']
});