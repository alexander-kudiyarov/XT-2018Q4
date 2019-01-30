function MathCalculator(input) {
    input = input.replace('=', '');
    var exForNumbers = /(-?\d+)(\.\d+)?/g;
    var exForPairs = /(-?\d+)(\.\d+)?((\s)*[+\-*/](\s)*((-?\d+)(\.\d+)?))?/;
    var pairs = input.match(exForNumbers).length - 1;

    function calcFirstMatch(numbers) {
        return new Function("return " + numbers);
    }

    for (var i = 0; i < pairs; i++) {
        matches = input.match(exForPairs);
        input = input.replace(exForPairs, calcFirstMatch(matches[0]));
    }

    input = parseFloat(input);
    return input.toFixed(2);
}