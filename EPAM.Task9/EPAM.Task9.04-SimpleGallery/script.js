let timeout;
let delay = 5000;
let i = delay / 1000;
let isStop = false;

function start(path) {
    counter();
    timeout = setTimeout(() => move(path), delay);
    isStop = false;
}

function stop() {
    clearTimeout(timeout);
    isStop = true;
}

function move(path) {
    location.replace(path);
}

function onEnd(path) {
    counter();
    timeout = setTimeout(() => {
        return onEndQuestion(path);
    }, delay);
}

function onEndQuestion(path) {
    result = confirm("Show again?");
    if (result) {
        move(path);
    } else {
        close();
    }
}

function innerCounter() {
    setTimeout(function () {
        document.getElementById("timer").innerHTML = i - 1;
        i--;
        if (i > 1 & !isStop) {
            innerCounter();
        }
        if (isStop)
        {
            i = delay / 1000;
        }
    }, 1000)
}

function counter() {
    document.getElementById("timer").innerHTML = i;
    innerCounter();
}