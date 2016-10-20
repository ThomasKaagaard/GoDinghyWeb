jQuery.validator.unobtrusive.adapters.add(
    'notequalto', ['other'], function (options) {
        options.rules['notEqualTo'] = '#' + options.params.other;
        if (options.message) {
            options.messages['notEqualTo'] = options.message;
        }
    });

jQuery.validator.addMethod('notEqualTo', function (value, element, param) {
    return this.optional(element) || value != $(param).val();
}, '');

if ($.validator && $.validator.unobtrusive) {

    $.validator.unobtrusive.adapters.add("mandatory", function (options) {
        options.rules['mandatory'] = options.params;
        options.messages['mandatory'] = options.message;
    });

    $.validator.addMethod("mandatory", function (value, element, params) {
        return $(element).is(':checked');
    });

}