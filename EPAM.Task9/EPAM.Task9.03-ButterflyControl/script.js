function moveSelected(from, to) {
    var selectOptions = document.getElementById(from);
    for (var i = 0; i < selectOptions.length; i++) {
        var option = selectOptions[i];
        if (option.selected) {
            move(from, to, option);
            i--;
        }
    }
}

function moveAll(from, to) {
    var options = document.getElementById(from);
    for (var i = 0; i < options.length; i++) {
        var option = options[i];
        move(from, to, option);
        i--;
    }
}

function move(from, to, option) {
    document.getElementById(from).removeChild(option);
    document.getElementById(to).appendChild(option);
}