$(function () {
    $("#ProvinceID").change(
        function () {
            $("#CityID").empty();
            $("<option></option>").val(null).text("--Select--").appendTo($("#CityID"));
            $.getJSON('/en-us/Hotels/GetCities', { ProvinceID: $(this).val() }, function (data) {
                $.each(data, function (i, item) {
                    $("<option></option>").val(item["CityID"]).text(item["CityName"]).appendTo($("#CityID"))
                })
            })
        }
        );
    if (!Modernizr.inputtypes.date) {
        $(function () {
            $(".datepicker").datepicker({
                format: 'yyyy-mm-dd',
                autoclose: true,
                clearBtn:true,
            });
        });
    };
});

