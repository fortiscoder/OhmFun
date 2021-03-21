// Good input
const input = "([((({()})))])";

// Bad input
//const input = "([((({()}))))";

// Good input with some text in there...
//const input = "([((({(random text)})))])";

// Bad input with some text in there...
//const input = "([((({(random text)}))))";

var bracketResult = checkBrackets(input);
if (bracketResult) {
    console.log('true');
}
else {
    console.log('false');
}

function checkBrackets(input : string) : boolean
{
    const pair: { [open: string]: string } =
    {
        "(": ")",
        "[": "]",
        "{": "}"
    };


    let sanitizedInput = sanitzeInput(input);


    //console.log(`Sanitized input: ${sanitizedInput}`);

    let result = true;
    let strArray: string[] = [];
    strArray = sanitizedInput.split('');
    // check to see if it's even/symetrical
    if (strArray.length % 2 != 0) {
        console.log('Length is not even');
        result = false;
    }
    else {

        for (let i = 0; i < strArray.length / 2; i++) {
            // Get corresponding character
            let idx = strArray.length - i - 1;
            if (pair[strArray[i]] != strArray[idx]) {
                console.log(`'${strArray[i]}' is false`);
                result = false;
                break;
            }

        }
    }

    return result;
}


function sanitzeInput(input: string) : string
{
    const validRegexp = /^[()\]\[{}]$/
    let strArray = input.split('');

    let output = '';

    // clean input - strip away any non-bracket type characters
    console.log(strArray.length);
    for (let i = 0; i < strArray.length; i++) {
        if (validRegexp.test(strArray[i])) {
            output += strArray[i]
        }
    }

    return output;
}