function addNewsRead(linkToNews) {
    $.ajax({
        url: "/Home/AddReadNews",
        dataType: "json",
        type: "POST",
        data: { link: linkToNews },
        success: function (data) {
        },
        error: function (data) {
            alert("Възникна грешка провери интернета си и опитай отново!")
        }
    })
}