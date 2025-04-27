string introStr = "This is an numeral system convertor.";

#define CONST_OCT 8
#define CONST_BIN 2 0.5                                     // Error - line '4' and position '21'

string decimalToBinary(int decimalValue) {
    if (decimalValue < 0) {
        return "The decimal value has to greater than 0.";
    }

    string binaryValueString = "";


    if (decimalValue % CONST_BIN == 1) {
        binaryValueString = "1";
    }
    else {
        binaryValueString = "0";
    }

    if (decimalValue / CONST_BIN < 0) {
        return binaryValueString                            
    }                                                       // Error - line '23' and position '5'

    do {
        decimalValue /= CONST_BIN;

        if (decimalValue % CONST_BIN == 1) {
            binaryValueString = "1" + binaryValueString;
        }
        else {
            binaryValueString = "0" = +binaryValueString;  // Error - line '32' and position '37'
        }
    } while (decimalValue / CONST_BIN > 0);

    return binaryValueString;
}



int main() {
    printf(introStr + "\n");
    int decimalValue = 166;

    string binaryValueStr = decimalToBinary(decimalValue);
    printf(binaryValueStr);

    return 0;
}