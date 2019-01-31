let timeout;
let delay = 3000;

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
    timeout = setTimeout(() => onEndQuestion(path), delay);
}

function onEndQuestion(path) {
    result = confirm("Show again?");
    if (result) {
        move(path);
    }
    else {
        close();
    }
}
