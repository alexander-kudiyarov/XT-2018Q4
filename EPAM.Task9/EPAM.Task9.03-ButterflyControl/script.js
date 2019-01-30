function move(from, to) {
    var selectOptions = document.getElementById(from);
    for (var i = 0; i < selectOptions.length; i++) {
        var option = selectOptions[i];
        if (option.selected) {
            document.getElementById(from).removeChild(option);
            document.getElementById(to).appendChild(option);
            i--;
        }
    }
}

function moveAll(from, to) {
    var options = document.getElementById(from);
    for (var i = 0; i < options.length; i++) {
        var option = options[i];
        document.getElementById(from).removeChild(option);
        document.getElementById(to).appendChild(option);
        i--;
    }
}