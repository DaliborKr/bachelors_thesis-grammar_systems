void 46 printNumbersDividing(int number) {              // Error - line '1' and position '6'
    printf("Cislo %d je delitene: ", number);

    for (int i = 1; i <= number; i++) {
        if (number % i == 0) {
            printf("%d,  ", i);
        }
    }
}

void whatShouldIEatRightNow(string timeOfDay) {
    int caseNumber;

    if (timeOfDay == "morning" {                       // Error - line '14' and position '32'
        caseNumber = 0;
    }
    else if (timeOfDay == "noon") {
        caseNumber = 1;
    }
    else if (timeOfDay == "afternoon") {
        caseNumber = 2;
    }
    else if (timeOfDay == "evening") {
        caseNumber = 3;
    }
    else if (timeOfDay == "night") {
        caseNumber = 4;
    }
    else {
        caseNumber = 100;
    }

    switch (caseNumber) {
    case 0<:                                            // Error - line '34' and position '12'
        printf("You should have BREAKFAST in the %s\n", timeOfDay);
        break;
    case 1:
        printf("You should have LUNCH at %s\n", timeOfDay);
        break;
    case 2:
        printf("You should have SNACK in the %s\n", timeOfDay);
        break;
    case 3:
        printf("You should have DINNER in the %s\n", timeOfDay);
        break;
    case 4:
        printf("You should NOT eat at %s\n", timeOfDay);
        break;
    default:
        printf("Unknown %s\n", timeOfDay);
    }
}

int main() {
    printNumbersDividing(128);

    whatShouldIEatRightNow("noon");

    whatShouldIEatRightNow("fwafaw");

    return 0;
}