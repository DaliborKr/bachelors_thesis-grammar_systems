int idVar(){
    id = idF(a, b) + 123;
    id = idF1(a, b) + id;
    id = idF1(a, b) + idF2(c, d);
    id = idF1(a, b) + idF2(c, d) % id;
}