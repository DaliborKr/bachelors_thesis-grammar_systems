int idFunc(){
    int a = 1;
    int i = 1;
    for (i = 2; i <= idFunc2(a, i + 2); ){
        a++;
    }
}