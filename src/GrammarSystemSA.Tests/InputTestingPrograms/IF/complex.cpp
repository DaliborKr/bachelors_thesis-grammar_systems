int main(){
    if (true){
        if (i <= idFunc2(a, i + 2)){
            i++;
        }
        else if (false){
            if (true){
                i++;
            }
            else if (false){
                i--;
            }
            else if ( i <= 123 || i % 2 == 0){
                ++i;
            }
            else{
                -- i;
            }
        }
    }
    else if (false){
        if (true){
            while (i < 123){
                i--;
            }
        }
        else{
            i--;
        }
    }
    else if ( i <= 123 || i % 2 == 0){
        ++i;
    }
    else{
        -- i;
    }
}