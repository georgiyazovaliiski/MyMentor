function gotoquestions(rangeA, rangeB) {
    let answers = $('.answer:checked');
    //alert($('.answer:checked').length);
    if (answers.length == 3) {
    $(`.questions${rangeA}`).fadeOut();
    setTimeout(function () {
            $(`.questions${rangeA}`).remove()
            if (rangeB == "123")
                $('#questionaire').append(questions123);

            else if (rangeB == "456") {
                Questionaire.Questions[0] = $(answers[0]).val();
                Questionaire.Questions[1] = $(answers[1]).val();
                Questionaire.Questions[2] = $(answers[2]).val();
                $('#questionaire').append(questions456);
            }
            else if (rangeB == "789") {
                Questionaire.Questions[3] = $(answers[0]).val();
                Questionaire.Questions[4] = $(answers[1]).val();
                Questionaire.Questions[5] = $(answers[2]).val();
                $('#questionaire').append(questions789);
            }
            $(`.questions${rangeB}`).fadeIn();
    }, 700
    )
        }
        else {
            alert('Попълни всички въпроси :)')
        }

}
function finishEntryTest() {
    let answers = $('.answer:checked');
    if (answers.length == 4) {
        Questionaire.Questions[6] = $(answers[0]).val();
        Questionaire.Questions[7] = $(answers[1]).val();
        Questionaire.Questions[8] = $(answers[2]).val();
        Questionaire.Questions[9] = $(answers[3]).val();
        //console.log(Questionaire)
        sendAnswersToAnalyse(Questionaire);
    }
    else {
        alert('Моля попълни всички полета :)')
    }
}

function sendAnswersToAnalyse(questionaire) {

    let Questionaire = JSON.stringify(questionaire);   
    $.ajax({
        url: "/Home/GetDataFromQuestionaire",
        type: "POST",
        data: Questionaire,
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) { location.reload() },
        error: function (result) { console.log("shit "); console.log(result) }
    });
}

let Questionaire = {
    Questions: [
        {

        }
    ]
}
let questions123 = `
            <div class="col-md questions123" style="display:none">
            <h3>Биологичен Пол: </h3>
                <ul>
                  <input class="answer" type="radio" name="gender" value="male" checked> Мъж<br>
                  <input class="answer" type="radio" name="gender" value="female"> Жена<br>
                </ul>
            </div>
            <div class="col-md questions123 text-center" style="display:none">
                <h3>Ако имаш 3 свободни часа ще: </h3>
                <ul>
                  <input class="answer" type="radio" name="hobby" value="fitness" checked> тренираш<br>
                  <input class="answer" type="radio" name="hobby" value="education"> четеш книга/списание<br>
                  <input class="answer" type="radio" name="hobby" value="social"> се видиш с приятели
                </ul>
            </div>
            <div class="col-md questions123 text-center" style="display:none">
                <h3>В училище си: </h3>
                <ul>
                  <input class="answer" type="radio" name="inschool" value="fitness" checked> Шумен<br>
                  <input class="answer" type="radio" name="inschool" value="education"> Прилежен<br>
                  <input class="answer" type="radio" name="inschool" value="social"> Небрежен
                </ul>
            </div>
            <div class="col-md questions123 text-center">
                <a href="#" onclick="gotoquestions(123,456)" class="custombutton">Продължи</a>
            </div>
`

let questions456 = `<div class="col-md questions456" style="display:none">
                <h3>Кога последно тренира?: </h3>
                <ul>
                  <input class="answer" type="radio" name="trainingfrequency" value="fitness" checked> Преди по-малко от седмица<br>
                  <input class="answer" type="radio" name="trainingfrequency" value="social" > Повече от седмица<br>
                  <input class="answer" type="radio" name="trainingfrequency" value="education" > Повече от месец
                </ul>
            </div>
            <div class="col-md questions456 text-center" style="display:none">
                <h3>В петък вечер: </h3>
                <ul>
                  <input class="answer" type="radio" name="fridaynight" value="education" checked> Си стоя вкъщи<br>
                  <input class="answer" type="radio" name="fridaynight" value="social" > Купонясвам, петък е!
                </ul>
            </div>
            <div class="col-md questions456 text-center" style="display:none">
                <h3>Кое е по-важно?: </h3>
                <ul>
                  <input class="answer" type="radio" name="themostimportant" value="education" checked> Силен ум<br>
                  <input class="answer" type="radio" name="themostimportant" value="fitness" > Силно тяло
                </ul>
            </div>
            <div class="col-md questions456 text-center">
                <a href="#" onclick="gotoquestions(456,789)" class="custombutton">Продължи</a>
            </div>
`
let questions789 = `<div class="col-md questions789" style="display:none">
                <h3>Би предпочел да: </h3>
                <ul>
                  <input class="answer" type="radio" name="youpreferto" value="education" checked> Решаваш проблеми и задачи<br>
                  <input class="answer" type="radio" name="youpreferto" value="fitness"> Рисуваш и създаваш<br>
                  <input class="answer" type="radio" name="youpreferto" value="social"> Продаваш и купуваш
                </ul>
            </div>
            <div class="col-md questions789 text-center" style="display:none">
                <h3>Първото нещо, което правиш сутрин: </h3>
                <ul>
                  <input class="answer" type="radio" name="firstthinginthemorning" value="fitness" checked> Проверявам дали още имам мускулна<br>
                  <input class="answer" type="radio" name="firstthinginthemorning" value="social"> Проверявам дали някой не ми е писал<br>
                  <input class="answer" type="radio" name="firstthinginthemorning" value="education"> Замислям първата си дейност за деня
                </ul>
            </div>
            <div class="col-md questions789 text-center" style="display:none">
                <h3>Твоята най-лоша черта от изброените: </h3>
                <ul>
                  <input class="answer" type="radio" name="worstpart" value="fitness" checked> Небрежност<br>
                  <input class="answer" type="radio" name="worstpart" value="education"> Памет<br>
                  <input class="answer" type="radio" name="worstpart" value="social"> Неловкост
                </ul>

            <h3>Учебна смяна: </h3>
                <ul>
                  <input class="answer" type="radio" name="StudyPeriod" value="1" checked> Първа<br>
                  <input class="answer" type="radio" name="StudyPeriod" value="2"> Втора<br>
                </ul>
            </div>
            <div class="col-md questions789 text-center">
                <a href="#" onclick="finishEntryTest()" id="finish" class="custombutton">Завърши</a>
            </div>
`


$('#start-questionaire').click(function () {
    $('.scheduleheader').removeClass('flipInY');
    $('.scheduleheader').addClass('fadeOut');
    setTimeout(function () {
        $('.scheduleheader').remove()


        $('#questionaire').append(questions123);
        $('.questions123').fadeIn();
    }, 700
    )
});

