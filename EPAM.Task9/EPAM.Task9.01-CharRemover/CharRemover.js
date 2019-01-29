function CharRemover(input) {
	var splitInput;
	var joinedSplitInput = input;
	var sepators = [' ', '	', '?', '!', ':', ';', '.'];

	sepators.forEach(function(element) {
		splitInput = joinedSplitInput.split(element);
		joinedSplitInput = splitInput.join();
	});

	splitInput = joinedSplitInput.split(',');
	var charsToRemove = [];
		
	splitInput.forEach(function(element) {
		for(var i = 0; i < element.length - 1; i++) {
			for(var j = i + 1; j < element.length; j++) {
				if(element[i] == element[j]) {
					charsToRemove.push(element[i]);
				}
			}
		}
	});

	for(var i = 0; i < input.length; i++) {
		input = input.replace(charsToRemove[0], '').replace(charsToRemove[1], '');
	}

	console.log(input);
}