let timeout;
let delay = 5000;
let i = delay / 100;
let isStoped = true;

function start(path) {
    if (isStoped) {
        counter();
        timeout = setTimeout(() => move(path), delay);
        isStoped = false;
    }
}

function stop() {
    if (!isStoped) {
        clearTimeout(timeout);
        isStoped = true;
    }
}

function move(path) {
    location.replace(path);
}

function onEnd(path) {
    isStoped = false;
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
        document.getElementById("timer").innerHTML = Math.ceil((i - 1) / 10);
        i--;
        
        if (i > 1 & !isStoped) {
            innerCounter();
        }
        if (isStoped) {
            i = delay / 100;
        }
    }, 100);
}

function counter() {
    document.getElementById("timer").innerHTML = Math.ceil(i / 10);
    innerCounter();
}