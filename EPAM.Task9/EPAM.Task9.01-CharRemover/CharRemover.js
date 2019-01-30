function CharRemover(input) {
    let splitInput;
    let joinedSplitInput = input;
    let sepators = [' ', '  ', '?', '!', ':', ';', '.'];

    sepators.forEach((element) => {
        splitInput = joinedSplitInput.split(element);
        joinedSplitInput = splitInput.join();
    });

    splitInput = joinedSplitInput.split(',');
    let charsToRemove = [];

    splitInput.forEach((element) => {
        for(let i = 0; i < element.length - 1; i++) {
            for(let j = i + 1; j < element.length; j++) {
                if(element[i] == element[j]) {
                    charsToRemove.push(element[i]);
                }
            }
        }
    });

    for(let i = 0; i < input.length; i++) {
        charsToRemove.forEach((element) => {
            input = input.replace(element, '');
        });
    }

    return input;
}