window.onload = function () { start() };

function restartSchedule() {
    $("#weekPicker").empty()
    $("#HelloAndCompo").empty()
    $("#daySchedule").empty()
    start();
}

function start() { let a = new Date(); let d = a.getDay(); checkDayOfWeekAndShow(d - 1); }

function checkDayOfWeekAndShow(dayIndex) {
    let currentDay = "Неделя"; 
    switch (dayIndex) {
        case 0:
            currentDay = "Понеделник"
            break;
        case 1:
            currentDay = "Вторник"
            break;
        case 2:
            currentDay = "Сряда"
            break;
        case 3:
            currentDay = "Четвъртък"
            break;
        case 4:
            currentDay = "Петък"
            break;
        case 5:
            currentDay = "Събота"
            break;
        default:
            currentDay = "Неделя"
    }
    getScheduleForDay(currentDay) 
}

$('.selectDay.left').click(
    function () {
        $('#daySchedule').removeClass('fadeInDown');
        $('#daySchedule').addClass('fadeOutRight');

        let text = $(this).text()
        getScheduleForDay(text)

    }
)

function getScheduleForDay(dayPassed) {
    let day = 0;
    switch (dayPassed) {
        case "Понеделник":
            day = 0
            break;
        case "Вторник":
            day = 1
            break;
        case "Сряда":
            day = 2
            break;
        case "Четвъртък":
            day = 3
            break;
        case "Петък":
            day = 4
            break;
        case "Събота":
            day = 5
            break;
        case "Неделя":
            day = 6
            break;
        default:
            day = day
    }
    if (day == -1) {
        day = 6
    }
    $.ajax({
        url: "/Home/GetScheduleForDay",
        dataType: "json",
        type: "GET",
        data: { day: day },
        success: function (data) {
            console.log(data);
            drawComponentsOnSchedule("componentsScheduleForDay", data, dayPassed);
        },
        error: function (data) {
        }
        })
}

function drawComponentsOnSchedule(listName, data, dayName) { 
            console.log(data)
            setTimeout(function () {
            $('#daySchedule').empty();
            $('#daySchedule').append(`<div class="gradiented text-right">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <h2><i class="fa fa-address-book"></i> ${dayName}</h2>
                    <ul id="${listName}">
                    </ul>
                </div>`);

            for (let i = 0; i < data.length; i++) {
                let li = //Component Control
                    `<li class="selectDay right" onclick="openComponent(${data[i].Id})">${('0' + data[i].StartHour).slice(-2)}:${('0' + data[i].StartMinutes).slice(-2)}-${('0' + data[i].EndHour).slice(-2)}.${('0' + data[i].EndMinutes).slice(-2)} - ${data[i].Name}</li>`;
                $(`#${listName}`).append(li);
            }

            $('#daySchedule').removeClass('fadeOutRight');
            $('#daySchedule').addClass('fadeInRight');
        },1000)
}

function openComponent(Id) {
    $.ajax({
        url: "/Home/GetComponent",
        dataType: "json",
        type: "GET",
        data: { id: Id },
        success: function (data) {
            console.log(data);
            drawComponent("ComponentDetails", data);
        },
        error: function (data) {
            console.log(data)
        }
    })
}

function drawUserDetails(UserDetails, PlaceToDraw) {
    $(PlaceToDraw).append(`<h1 class="UserDetail left diarytext"><u>ТВОЯТ ПРОФИЛ</u></h1>`);
    var colNum = 1;
    for (var key in UserDetails) {
        if (UserDetails.hasOwnProperty(key)) {
            if (typeof (UserDetails[key]) != "string") {
                $(PlaceToDraw).append(`<div class="col-md" id="col${colNum}"></div>`)
                $(`${PlaceToDraw} #col${colNum}`).append(`<h3 class="UserDetail left text-left diarytext" onclick="showSecondary('col${colNum}')">+ ${key}</h3>`);
                for (var keyInside in UserDetails[key]) {
                    console.log(keyInside)
                    if (keyInside == "Goal") {
                        $(`${PlaceToDraw} #col${colNum}`).append(`<p class="UserDetail diarytext SecondaryDetail" style="display:none">${keyInside} -> <select name="${keyInside}">
                        <option>Покачване на килограми</option>
                        <option>Сваляне на килограми</option>
                        <option>Поддържане на килограми</option>
</select></p>`);
                    }
                    else if (keyInside.toLowerCase().indexOf("day") >= 0) {

                    }
                    else {
                        $(`${PlaceToDraw} #col${colNum}`).append(`<p class="UserDetail SecondaryDetail diarytext">${keyInside} -> <input type="text" name="${keyInside}" value="${UserDetails[key][keyInside]}"></p>`);
                    }
                }
                colNum++;
            }
            else {
                if (key == "Email") {
                    $(PlaceToDraw).append(`<h3 class="UserDetail left text-left diarytext">${key} -> <input type="text" name="${key}" value="${UserDetails[key]}" disabled></h3>`);
                }
                else {
                    $(PlaceToDraw).append(`<h3 class="UserDetail left text-left diarytext">${key} -> <input type="text" name="${key}" value="${UserDetails[key]}"></h3>`);
                }                
            }
        }
    }
    $(PlaceToDraw).append(`<br><button class="custombutton" style="background:none" onclick="UpdateProfileData()" value="Submit">Запази промените</button>`);

    $(PlaceToDraw).append(`<br><br><br><br><br>`);
}

function UpdateProfileData() {
    //alert($("select[name=Goal] option:selected").val())
    var userdata = {
        "FirstName": $("input[name=FirstName]").val(),
        "LastName": $("input[name=LastName]").val(),
        "Email": $("input[name=Email]").val(),
        "Priorities": {
            "EducationParam": Number.parseInt($("input[name=EducationParam]").val()),
            "FitnessParam": Number.parseInt($("input[name=FitnessParam]").val()),
            "SocialParam": Number.parseInt($("input[name=SocialParam]").val()),
        },
        "UserFitnessGoals": {
            "MassInKG": Number.parseFloat($("input[name=MassInKG]").val()),
            "HeightInCM": Number.parseFloat($("input[name=HeightInCM]").val()),
            "BodyFat": Number.parseFloat($("input[name=BodyFat]").val()),
            "Goal": $("select[name=Goal] option:selected").val(),
            "CaloriesForDay": Number.parseInt($("input[name=CaloriesForDay]").val()),
            "ProteinGoalForDay": Number.parseInt($("input[name=ProteinGoalForDay]").val()),
            "FatGoalForDay": Number.parseInt($("input[name=FatGoalForDay]").val()),
            "CarbsGoalForDay": Number.parseInt($("input[name=CarbsGoalForDay]").val())
        }
    }

    if (userdata.UserFitnessGoals.MassInKG > 1.0 &&
        userdata.UserFitnessGoals.HeightInCM > 130.0 &&
        userdata.UserFitnessGoals.BodyFat > 5.0 &&
        userdata.UserFitnessGoals.Goal != null) {
        //console.log(userdata)
        $.ajax({
            url: "/Account/UpdateProfileData",
            dataType: "json",
            type: "POST",
            data: JSON.stringify(userdata),
            contentType: 'application/json;',
            success: function (data) {
                alert(data)
                location.reload();
            },
            error: function (data) {
                console.log(data)
            }
        })
    }
    else {
        alert("Въведи Стойности за Височина, Килограми и цел!")
    }
}

function showSecondary(col) {
    if ($(`#${col} .SecondaryDetail`).is(":visible")) {
        $(`#${col} .SecondaryDetail`).toggle(300);
    }
    else {
        $(`.SecondaryDetail`).hide();
        $(`#${col} .SecondaryDetail`).toggle(300);
    }
}

function drawComponent(objectToDrawOn, data) {
    $("#ComponentName").empty();
    $("#ComponentDuration").empty();
    $("#ComponentDescription").empty();
    $("#ComponentCompleteButton").empty();
    
    if (data["DETERMINATOR"] == 1) {
        if (data["MealPieces"].length == 0) {
            $("#weekPicker").empty()
            $("#HelloAndCompo").empty()
            $("#daySchedule").empty()
            showUserPanel("#home #HelloAndCompo");
            alert("Въведи своите Физически данни!")
            return;
        }
    }
    else if (data["DETERMINATOR"] == 0) {
        if (data["Workout"]["ExercisesInWorkout"] == null) {
            showUserPanel("#home #HelloAndCompo");
            alert("Въведи своите Физически данни!")
            return;
        }
    }

    for (var key in data) {
        if (data.hasOwnProperty(key)) {
            if (key.indexOf("id") >= 0 || key.indexOf("Id") >= 0 || key.indexOf("ID") >= 0 || key.indexOf("Day") >= 0) {
                continue;
            }
            switch (key) {
                case "Name":
                    $("#ComponentName").append(`<h2 class="text-left">${data[key]}</h2>`);
                    break;
                case "StartTime":
                    $("#ComponentDuration").append(`<h2 class="text-right">${('0' + data[key].Hours).slice(-2)}:${('0' + data[key].Minutes).slice(-2)}</h2>`);
                    break;
                case "EndTime":
                    $("#ComponentDuration h2").text(`${$("#ComponentDuration h2").text()} - ${('0' + data[key].Hours).slice(-2)}:${('0' + data[key].Minutes).slice(-2)}`);
                    break;
                case "Completed":
                case "Priority":
                case "DETERMINATOR":
                case "EduType":
                    break;
                case "Workout":
                    //DRAW WORKOUT IF PRESENT
                    break;
                case "MealPieces":
                    for (var item in data[key]) {
                        var mealPieceName = `<h5 class="diarytext" style="color:white">${data[key][item].Name}</h5>`;
                        var mealPiecePortionMassInGrams = `<h5 class="diarytext" style="color:white">${data[key][item].PortionMassInGrams.toFixed(2)} грама</h5>`;
                        var mealPieceCalories = `<h5 class="diarytext" style="color:white">${data[key][item].Calories.toFixed(2)} калории</h5>`;
                        var table = `<div class="row diarytext styleddetail">
                        <div class="col-md">
${mealPieceName}
                        </div>
                        <div class="col-md">
${mealPieceCalories} 
                        </div>
                        <div class="col-md">
${mealPiecePortionMassInGrams}
                        </div>
                    
                        </div><br>`;
                        $("#ComponentDescription").append(table);
                    }
                    break;
                default:
                    $("#ComponentDescription").append(`<p class="text-justify" style="color:white">${key} - ${data[key]}</p>`);
            }
        }
    }
    if (data["Completed"] == false) {
        var d = new Date();
        if (data["StartTime"].Hours < d.getHours()) {
            $("#ComponentCompleteButton").append(`<button class="custombutton2 hvr-grow-rotate" onclick="CompleteComponent(${data["Id"]})" style="background:none">Завърши <i class="fa fa-check" aria-hidden="true"></i></button>`);
        }
        else {
            $("#ComponentCompleteButton").append(`<b><p style="color:white">Все още не е време за това :)</p></b>`)
        }
    }
    else {
        $("#ComponentCompleteButton").append(`<b><p style="color:white">Тази част от деня вече е завършена! Поздравления!</p></b>`)
    }
}

function showUserPanel(PlaceToDraw) {
    $.ajax({
        url: "/Account/GetUserDetails",
        dataType: "json",
        type: "GET",
        success: function (data) {
            drawUserDetails(data, PlaceToDraw);
        },
        error: function (data) {
        }
    })
}
function CompleteComponent(Id) {
    console.log(Id)
    $.ajax({
        url: "/Home/CompleteComponent",
        dataType: "json",
        type: "POST",
        data: { id: Id },
        success: function (data) {
            alert("Поздравления! Разви себе си още малко!");
            $("#ComponentCompleteButton").empty(200);
        },
        error: function (data) {
            console.log(data)
        }
    })
}