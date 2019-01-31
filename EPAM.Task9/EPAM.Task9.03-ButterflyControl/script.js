function moveSelected(from, to) {
    let selectOptions = document.getElementById(from);

    for (let i = 0; i < selectOptions.length; i++) {
        let option = selectOptions[i];

        if (option.selected) {
            move(from, to, option);
            i--;
        }
    }

    clearSelected(to);
}

function moveAll(from, to) {
    let options = document.getElementById(from);

    for (let i = 0; i < options.length; i++) {
        let option = options[i];
        move(from, to, option);
        i--;
    }

    clearSelected(to);
}

function move(from, to, option) {
    document.getElementById(from).removeChild(option);
    document.getElementById(to).appendChild(option);
}

function clearSelected(list) {
    let elements = document.getElementById(list).options;

    for (let i = 0; i < elements.length; i++) {
        elements[i].selected = false;
    }
}