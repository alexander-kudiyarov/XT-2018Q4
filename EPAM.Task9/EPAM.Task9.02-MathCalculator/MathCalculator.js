function MathCalculator(input) {
    input = input.replace(/=/g, '');
    let exForNumbers = /(-?\d+)(\.\d+)?/g;
    let exForPairs = /(-?\d+)(\.\d+)?((\s)*[+\-*/](\s)*((-?\d+)(\.\d+)?))?/;
    let pairs = input.match(exForNumbers).length - 1;

    function calcFirstMatch(numbers) {
        return new Function("return " + numbers);
    }

    for(let i = 0; i < pairs; i++) {
        matches = input.match(exForPairs);
        input = input.replace(exForPairs, calcFirstMatch(matches[0]));
    }

    input = parseFloat(input);
    return input.toFixed(2);
}