int idFunc(){
    int a = 1;
    int i = 1;
    for (int i = 0; i <= 123; i++){
        a++;
        if (i % 123 == 0){
            break;
        }
        else{
            a *= i;
            continue;
        }
    }
}