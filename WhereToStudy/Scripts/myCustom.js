$(document).on("click", ".question input[type='radio']", function () {
    var clickedIndex = $(this).data("index");
    $(this).closest(".question").find("input[type='hidden']").val(clickedIndex);

});

$(document).on("click", ".course-info-js", function () {
    var courseId = $(this).closest("td").find("input[type='hidden']").val();
    $.ajax({
        url: "/Warehouse/Warehouse/Search?Model=" + Model
    })
        .done(function (data) {
            $("#course-info-container").html(data)
        });
});

$(document).on("change", "select[name='UniversitiesDropdown']", function () {
    var chosenUniversityId = $("select[name='UniversitiesDropdown']").val();
    $.ajax({
        url: "/Warehouse/Specialties/AddSpecialty?isPartial=true&universityId=" + chosenUniversityId
    })
        .done(function (data) {
            $("#specialty-form-container").html(data)
        });
});



$(document).on("click", ".specialty-info-js", function () {
    var specialtyId = $(this).closest("td").find("input[type='hidden']").val();
    $.ajax({
        url: "/Warehouse/Specialties/Details?specialtyId=" + specialtyId
    })
        .done(function (data) {
            $("#specialty-info-container ").html(data)
        });
});

$(document).on("click", ".search-info-js", function () {
    var model = '@Model'
    $.ajax({
        url: "/Warehouse/AdvancedSearchController/Search?model=" + model
    })
        .done(function (data) {
            $("#course-info-container").html(data)
        });
});