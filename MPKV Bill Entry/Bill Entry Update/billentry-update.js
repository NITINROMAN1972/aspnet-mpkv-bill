

$(document).ready(function () {

    // update search dropdowns

    // challan bill search
    $('#ddScBillRefNo').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // aggriculture college name
    $('#ddScAggriCollg').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // component
    $('#ddScComponent').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // acc head name
    $('#ddScAccHeadName').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });






    // university region
    $('#UniRegion').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // aggriculture college
    $('#AgriCollg').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // accounting rule
    $('#AccRule').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });





    // scheme category
    $('#SchCateg').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // scheme
    $('#Scheme').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // component
    $('#Component').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });





    // account head group name
    $('#AccHeadGroupName').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // account head sub group
    $('#AccHeadSubGroup').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // account head name
    $('#AccHeadName').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // mode of payment
    $('#ModeOfPayment').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });





    // item category
    $('#ItemCategory').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // item
    $('#Item').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // uom
    $('#UOM').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });






    // Reinitialize Select2 after UpdatePanel partial postback
    var prm = Sys.WebForms.PageRequestManager.getInstance();

    // Reinitialize Select2 for all dropdowns
    prm.add_endRequest(function () {

        setTimeout(function () {

            // update search dropdowns

            // challan bill search
            $('#ddScBillRefNo').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // aggriculture college name
            $('#ddScAggriCollg').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // component
            $('#ddScComponent').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // acc head name
            $('#ddScAccHeadName').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });






            // university region
            $('#UniRegion').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // aggriculture college
            $('#AgriCollg').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // accounting rule
            $('#AccRule').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });





            // scheme category
            $('#SchCateg').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // scheme
            $('#Scheme').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // component
            $('#Component').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });





            // account head group name
            $('#AccHeadGroupName').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // account head sub group
            $('#AccHeadSubGroup').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // account head name
            $('#AccHeadName').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // mode of payment
            $('#ModeOfPayment').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });



            // item category
            $('#ItemCategory').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // item
            $('#Item').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // uom
            $('#UOM').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });


        }, 0);
    });

});