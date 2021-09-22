$(document).ready(function () {
    var i;
    var quiz = [];
    var Count;
    var imageChoice;
    var correct = 0;
    var missed = 0;
    var attempted = 0;
    var rightAns;
    var intervalTimer;
    var delayButtonAlert;
    var newQuest;
    var ansAttempt;

    temizle();
    quizBuild();

    i = 1;

    hideStuff();
    $("#new-question").on("click", displayNewQuestion);
    $("#new-question").on("click", displayStats);
    $("#new-question").on("click", imageInsert);

    function temizle() {
        document.getElementById("cont").style.visibility = "hidden";
    }
    function displayNewQuestion() {

        document.getElementById("cont").style.visibility = "visible";

        if (i > 0) {
            clearTimeout(newQuest);
        }

        $("#new-question").hide();
        videoInsert()
        imageInsert();
        hideStuff();


        ansAttempt = false;
        quizWrite();

        Count = 60;
        intervalTimer = setInterval(countDown, 1000)

        delayButtonAlert = setTimeout(notAttempted, 60000)
        clearButton();


    }
    $(document).on("click", ".answer", Attempted);

    function countDown() {
        Count -= 1;
        $("#seconds-count").html('<h3> ' + Count + " Saniye </h3> ")
        return Count;
    }
    function hideStuff() {
        $("#message").hide();
        $("#picture").hide();
        $("#reveal").hide();
    }
    function Attempted() {

        clearTimeout(delayButtonAlert);
        clearTimeout(intervalTimer);

        ansAttempt = true;
        $("#message").show();

        userChoice = parseInt($(this).val());
        console.log(userChoice, i);

        attempted += 1;

        if (userChoice == quiz[i].ans) {

            $("#message").html('Doğru!');
            correct += 1;
        }
        else {
            $("#message").html('Yanlış!');
            missed += 1;
        }

        $(".stats").show();
        displayStats();

        displayAnsImg();
    }
    function notAttempted() {

        if (ansAttempt != true) {

            clearTimeout(delayButtonAlert);
            clearTimeout(intervalTimer);

            missed += 1;
            attempted += 1;
            $(".stats").show();
            displayStats();

            displayAnsImg();
        }
        else {
            return
        }
    }
    function displayAnsImg() {

        if (i < quiz.length) {

            newQuest = setTimeout(displayNewQuestion, 2000);
            $("video").remove();

        }

        imageChoice = imageInsert();
        $("#picture").html(imageChoice);
        $("#reveal").html("Doğru Cevap: " + quizAnswer());

        $("#picture").show();
        $("#reveal").show();

        i++;
    }
    function quizConstructor(question, answ1, answ2, answ3, answ4, ans, imageURL, attempted, videoURL) {
        this.question = question;
        this.answ1 = answ1;
        this.answ2 = answ2;
        this.answ3 = answ3;
        this.answ4 = answ4;
        this.ans = ans;
        this.imageURL = imageURL;
        this.attempted = attempted;
        this.videoURL = videoURL;
    }
    function quizBuild() {
        quiz[1] = new quizConstructor(
        "Sarayburnu Tepesi üzerinde yer alan ve İstanbul'un fethinden sonra, 1460-1478 yılları arasında Fatih Sultan Mehmed'in inşa ettirdiği ikinci saray olarak günümüze dünyanın en büyük müzeleri arasında yer alan yapının adı nedir",
        'Topkapı Sarayı', 'Yıldız Sarayı', 'Dolmabahçe Sarayı', 'Beylerbeyi Sarayı',
        1, "", false, "soru1.MOV");
        quiz[2] = new quizConstructor(
        "1609-1617 yılları arasında Osmanlı padişahı 1. Ahmed tarafından tarihi yarım adada, Mimar Sedefkar Mehmed Ağa'ya yaptırılan, 20.000'den fazla iznik tarzı seramik ile kaplanmış ve 6 minaresi ile dikkat çeken yapının adı nedir",
        'Ayasofya Cami', 'Süleymaniye Cami', 'Sultan Ahmet Cami', 'Çamlıca Cami',
        3, "", false, "pics/soru2.MOV");
        quiz[3] = new quizConstructor(
        "Bizans İmparatorluğu zamanında İmparator Justinianos tarafından 532 yılında inşaatına başlanan ve tamamlanması 5 yıl süren, eski Yunancada 'Kutsal Bilgelik' anlamına gelen ismi ile günümüzde cami olarak kullanılmakta olan ayrıca İstanbul'da inşa edilen en büyük klise olarak da bilinen yapının adı nedir",
        'Ayasofya Cami', 'Fatih Cami', 'Süleymaniye Cami', 'Sultan Ahmet Cami',
        1, "", false, "pics/soru3.MOV");
        quiz[4] = new quizConstructor(
        "Alman İmparatoru olan 2. Wilhelm tarafından İstanbul'a ve Sultan II. Abdülhamid'e hediye edilen, Almanya'da yapılıp 1901'de İstanbul'daki yerine monte edilmiş yapının adı nedir",
        'Milyon Taşı', 'Alman Çeşmesi', 'Alman Kulesi', 'Barış Heykeli',
        2, "", false, "pics/soru4.MOV");
        quiz[5] = new quizConstructor();
        return quiz
    }

    function clearButton() {
        $("#answer-1").css("background-color", "#366B6B");
        $("#answer-2").css("background-color", "#366B6B");
        $("#answer-3").css("background-color", "#366B6B");
        $("#answer-4").css("background-color", "#366B6B");
        $("#answer-5").css("background-color", "#366B6B");
    }
    function quizWrite() {
        $("#question").html("" + quiz[i].question + " ?");

        console.log(quiz[i].videoURL);
        if (quiz[i].videoURL == null) {
            imageChoice = imageInsert();
            $("#picture").show();
            $("#picture").html(imageChoice);
        }
        else {
            imageChoice = videoInsert();
            $("#video").show();
            $("#video").html(imageChoice);
        }
        if (i == 5) {
            var x = document.getElementById("cont");
            if (x.style.display === "none") {
                x.style.display = "block";
            } else {
                x.style.display = "none";
            }

            var x = document.getElementById("seconds-count");
            if (x.style.display === "none") {
                x.style.display = "block";
            } else {
                x.style.display = "none";
            }
            alert("Oyun Bitti!\n" + "Doğru Cevap Sayısı: " + correct + "\nYanlış Cevap Sayı: " + missed);
            location.reload();
        }
        $("#answer-1").html(quiz[i].answ1);
        $("#answer-2").html(quiz[i].answ2);
        $("#answer-3").html(quiz[i].answ3);
        $("#answer-4").html(quiz[i].answ4);

    }
    function quizAnswer() {
        if (quiz[i].ans == 1) {
            quizAns = quiz[i].answ1;
        } else if (quiz[i].ans == 2) {
            quizAns = quiz[i].answ2;
        } else if (quiz[i].ans == 3) {
            quizAns = quiz[i].answ3;
        } if (quiz[i].ans == 4) {
            quizAns = quiz[i].answ4;
        }
        if (1 == quiz[i].ans) {
            $("#answer-1").css("background-color", "green");
            $("#answer-2").css("background-color", "red");
            $("#answer-3").css("background-color", "red");
            $("#answer-4").css("background-color", "red");
        }
        if (2 == quiz[i].ans) {
            $("#answer-1").css("background-color", "red");
            $("#answer-2").css("background-color", "green");
            $("#answer-3").css("background-color", "red");
            $("#answer-4").css("background-color", "red");
        }
        if (3 == quiz[i].ans) {
            $("#answer-1").css("background-color", "red");
            $("#answer-2").css("background-color", "red");
            $("#answer-3").css("background-color", "green");
            $("#answer-4").css("background-color", "red");
        }
        if (4 == quiz[i].ans) {
            $("#answer-1").css("background-color", "red");
            $("#answer-2").css("background-color", "red");
            $("#answer-3").css("background-color", "red");
            $("#answer-4").css("background-color", "green");
        }
        return quizAns;
    }
    function displayStats() {
        $(".stats").html("<h4> Doğru Cevaplar: " + correct + '<br>' + "Yanlış Cevaplar: " + missed + '<br>' + "Soru Sayısı: " + attempted + '</h4>');
    }
    function imageInsert() {
        var imageChoice = $('<img>');
        imageChoice.attr('src', quiz[i].imageURL);
        imageChoice.attr('width', '500px');
        return imageChoice;
    }
    function videoInsert() {
        var imageChoice = $('<video>');
        imageChoice.attr("controls", "controls");
        imageChoice.html('<source src=\'/assets/yarisma/' + quiz[i].videoURL + '\' ' + 'type=\'video/mp4\'>');
        //<source src=" ~/assets/yarisma/ " soru1.mov="" type="video/mp4">
        /*<iframe width="1514" height="610" src="https://www.youtube.com/embed/uX7jKlNTx3Q" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>*/
        imageChoice.attr('width', '500px');
        return imageChoice;
    }
})
