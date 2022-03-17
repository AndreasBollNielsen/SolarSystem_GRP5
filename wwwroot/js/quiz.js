//Question bank
//var questionBank= [
//    {
//        question : 'How many planets are there in the Solar System?',
//        option : ['7','8','9','10'],
//        answer : '9'
//    },
//    {
//        question : 'What planet is closest to the sun?',
//        option : ['Mars','Mercury','Earth','Venus'],
//        answer : 'Mercury'
//    },
//    {
//        question : 'What is the farthest planet from the sun?',
//        option : ['Pluto','Mars','Venus','Neptune'],
//        answer : 'Pluto'
//    },
//    {
//        question : 'Which planet is not a gas giant?',
//        option : ['Neptune','Saturn','Mars','Jupiter'],
//        answer : 'Neptune'
//    },
//    {
//        question : 'Which planet is not a terrestrial planet?',
//        option : ['Saturn','Earth','Mars','Venus'],
//        answer : 'Saturn'
//    },
//    {
//        question : 'What is the largest terrestrial planet?',
//        option : ['Mars','Mercury','Venus','Earth'],
//        answer : 'Earth'
//    },
//    {
//        question : 'What is the Earths radius?',
//        option : ['6371 Km','1237 Km','12400 Km','25000 Km'],
//        answer : '6371 Km'
//    },
//    {
//        question : 'What is the rotational period of Earth?',
//        option : ['1 Year','48 Hours','24 Hours','12 Hours'],
//        answer : '24 Hours'
//    },
//    {
//        question : 'How long could a long-period comet take to orbit around the Sun?',
//        option : ['1000 Year','10 000 Years','100 000 Years','30 Million Years'],
//        answer : '100 000 Years'
//    },
//    {
//        question : 'Which moon is a moon of Mars?',
//        option : ['Phobos','Io','Ganymede','Charon'],
//        answer : 'Phobos'
//    },
//]
var questionBank = [
    {
        question: dict["lang.quiz.question1"],
        option: [dict["lang.quiz.q1.answer1"], dict["lang.quiz.q1.answer2"], dict["lang.quiz.q1.answer3"], dict["lang.quiz.q1.answer4"]],
        answer: dict["lang.quiz.rightAnswer1"]
    },
    {
        question: dict["lang.quiz.question2"],
        option: [dict["lang.quiz.q2.answer2"], dict["lang.quiz.q2.answer2"], dict["lang.quiz.q2.answer3"], dict["lang.quiz.q2.answer4"]],
        answer: dict["lang.quiz.rightAnswer2"]
    },
    {
        question: dict["lang.quiz.question3"],
        option: [dict["lang.quiz.q3.answer3"], dict["lang.quiz.q3.answer2"], dict["lang.quiz.q3.answer3"], dict["lang.quiz.q3.answer4"]],
        answer: dict["lang.quiz.rightAnswer3"]
    },
    {
        question: dict["lang.quiz.question4"],
        option: [dict["lang.quiz.q4.answer4"], dict["lang.quiz.q4.answer2"], dict["lang.quiz.q4.answer3"], dict["lang.quiz.q4.answer4"]],
        answer: dict["lang.quiz.rightAnswer4"]
    },
    {
        question: dict["lang.quiz.question5"],
        option: [dict["lang.quiz.q5.answer5"], dict["lang.quiz.q5.answer2"], dict["lang.quiz.q5.answer3"], dict["lang.quiz.q5.answer4"]],
        answer: dict["lang.quiz.rightAnswer5"]
    },
    {
        question: dict["lang.quiz.question6"],
        option: [dict["lang.quiz.q6.answer6"], dict["lang.quiz.q6.answer2"], dict["lang.quiz.q6.answer3"], dict["lang.quiz.q6.answer4"]],
        answer: dict["lang.quiz.rightAnswer6"]
    },
    {
        question: dict["lang.quiz.question7"],
        option: [dict["lang.quiz.q7.answer7"], dict["lang.quiz.q7.answer2"], dict["lang.quiz.q7.answer3"], dict["lang.quiz.q7.answer4"]],
        answer: dict["lang.quiz.rightAnswer7"]
    },
    {
        question: dict["lang.quiz.question8"],
        option: [dict["lang.quiz.q8.answer8"], dict["lang.quiz.q8.answer2"], dict["lang.quiz.q8.answer3"], dict["lang.quiz.q8.answer4"]],
        answer: dict["lang.quiz.rightAnswer8"]
    },
    {
        question: dict["lang.quiz.question9"],
        option: [dict["lang.quiz.q9.answer9"], dict["lang.quiz.q9.answer2"], dict["lang.quiz.q9.answer3"], dict["lang.quiz.q9.answer4"]],
        answer: dict["lang.quiz.rightAnswer9"]
    },
    {
        question: dict["lang.quiz.question10"],
        option: [dict["lang.quiz.q10.answer10"], dict["lang.quiz.q10.answer2"], dict["lang.quiz.q10.answer3"], dict["lang.quiz.q10.answer4"]],
        answer: dict["lang.quiz.rightAnswer10"]
    },
]

var question= document.getElementById('question');
var quizContainer= document.getElementById('quiz-container');
var scorecard= document.getElementById('scorecard');
var option0= document.getElementById('option0');
var option1= document.getElementById('option1');
var option2= document.getElementById('option2');
var option3= document.getElementById('option3');
var next= document.querySelector('.next');
var points= document.getElementById('score');
var span= document.querySelectorAll('span');
var i=0;
var score= 0;
//function to display questions
function displayQuestion(){
    for(var a=0;a<span.length;a++){
        span[a].style.background='none';
    }
    question.innerHTML= 'Q.'+(i+1)+' '+questionBank[i].question;
    option0.innerHTML= questionBank[i].option[0];
    option1.innerHTML= questionBank[i].option[1];
    option2.innerHTML= questionBank[i].option[2];
    option3.innerHTML= questionBank[i].option[3];
    stat.innerHTML= "Question"+' '+(i+1)+' '+'of'+' '+questionBank.length;
}

//function to calculate scores
function calcScore(e){
    if(e.innerHTML===questionBank[i].answer && score<questionBank.length)
    {
        score= score+1;
        document.getElementById(e.id).style.background= 'limegreen';
    }
    else{
        document.getElementById(e.id).style.background= 'tomato';
    }
    setTimeout(nextQuestion,300);
}

//function to display next question
function nextQuestion(){
    if(i<questionBank.length-1)
    {
        i=i+1;
        displayQuestion();
    }
    else{
        points.innerHTML= score+ '/'+ questionBank.length;
        quizContainer.style.display= 'none';
        scoreboard.style.display= 'block'
    }
}

//click events to next button
next.addEventListener('click',nextQuestion);

//Back to Quiz button event
function backToQuiz(){
    location.reload();
}

//function to check Answers
function checkAnswer(){
    var answerBank= document.getElementById('answerBank');
    var answers= document.getElementById('answers');
    answerBank.style.display= 'block';
    scoreboard.style.display= 'none';
    for(var a=0;a<questionBank.length;a++)
    {
        var list= document.createElement('li');
        list.innerHTML= questionBank[a].answer;
        answers.appendChild(list);
    }
}


displayQuestion();