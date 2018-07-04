export const VALIDATOR_WEIGHTS = {
    REGON_SHORT: [ 8, 9, 2, 3, 4, 5, 6, 7 ],
    REGON_LONG: [ 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 ],
    NIP: [ 6, 5, 7, 2, 3, 4, 5, 6, 7 ]
};

export const REGEX_REGON_NIP = new RegExp(/K|R|S|L|\-|P|\ /g);
