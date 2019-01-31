let timeout;
let delay = 5000;

function start(path) {
    timeout = setTimeout(() => move(path), delay);
}

function stop() {
    clearTimeout(timeout);
}

function move(path) {
    location.replace(path);
}

function onEnd(path) {
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

let i = delay / 1000;

function innerCounter() {
    setTimeout(function () {
        document.getElementById("timer").innerHTML = i - 1;
        i--;
        if (i > 0) {
            innerCounter();
        }
    }, 1005)
}

function counter() {
    document.getElementById("timer").innerHTML = i;
    innerCounter();
}