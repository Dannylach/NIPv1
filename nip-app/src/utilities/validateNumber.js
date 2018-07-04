    
import {VALIDATOR_WEIGHTS, REGEX_REGON_NIP} from './const';

export function validateRegon(inputBeforeRegex) {
	if(inputBeforeRegex == 'Nieznany numer REGON.') return true;
	const INPUT = inputBeforeRegex.replace(REGEX_REGON_NIP, '');
	
	if (INPUT.length == 10) {
    	return true;
	} else if (INPUT.length == 7) {
      	var controlSum = VALIDATOR_WEIGHTS.REGON_SHORT.reduce(function(checkSum, currentArrayValue, index) {
			var Multiplied = currentArrayValue * parseInt(INPUT.charAt(index))
			return checkSum += Multiplied;
		}, 2);
    } else if (INPUT.length == 9) {
        var controlSum = VALIDATOR_WEIGHTS.REGON_SHORT.reduce(function(checkSum, currentArrayValue, index) {
			var Multiplied = currentArrayValue * parseInt(INPUT.charAt(index))
			return checkSum += Multiplied;
		}, 0);
        if(controlSum == 10) controlSum = 0;
	} else if(INPUT.length == 14) {
      	var controlSum = VALIDATOR_WEIGHTS.REGON_LONG.reduce(function(checkSum, currentArrayValue, index) {
			var Multiplied = currentArrayValue * parseInt(INPUT.charAt(index))
			return checkSum += Multiplied;
		}, 0);
    } else {
      	return false;
    }
	var controlNum = controlSum % 11;
    
	if (controlNum == 10) {
  		controlNum = 0;
    }
	var lastDigit = parseInt(INPUT.charAt(INPUT.length - 1));
    return (controlNum == lastDigit);
}

export function validateNip (inputBeforeRegex) {
	if(inputBeforeRegex == 'Nieznany numer NIP.') return true;
	const INPUT = inputBeforeRegex.replace(REGEX_REGON_NIP, '');
	
	if (INPUT.length == 10) {
    	var controlSum = VALIDATOR_WEIGHTS.NIP.reduce(function(checkSum, currentArrayValue, index) {
			var Multiplied = currentArrayValue * parseInt(INPUT.charAt(index))
			return checkSum += Multiplied;
		}, 0);
	} else return false;
	var controlNum = controlSum % 11;
    
	if (controlNum == 10) {
  		controlNum = 0;
    }
	var lastDigit = parseInt(INPUT.charAt(INPUT.length - 1));
    
	if(controlNum == lastDigit) return true;
	else return false;
}
