

$(document).ready(function () {

    $("#btnSave").click(function (event) {
        event.preventDefault();

        var addUrl = app.Urls.projectAddUrl;
        var redicrectUrl = app.Urls.taskAddUrl;

        var projectAddDto = {
            ProjectName: $("input[id=projectName]").val(),
            Description: $("input[id=projectDescription]").val(), 
            Budget: $("input[id=projectBudget]").val(), 
            StartDate: $("input[id=StartDate]").val(),
            EndDate: $("input[id=projectEndDate]").val(),
            Priority: $("input[id=projectPriority]").val(),

        }

        var jsonData = JSON.stringify(projectAddDto);
        console.log(jsonData)

        $.ajax({
            url: addUrl,
            type : "POST",
            contentType: "application/json; charset-utf-8",
            dataType : "json",
            data: jsonData,
            success : function (data) {
                setTimeout(function () {
                    window.location.href = redicrectUrl;
                }, 1500);
            },
            error: function () {
                toastr.error("Bir hata oluştu", "Hata");
            }

        });

    })
});