#include<stdio.h>
#include<string.h>


typedef struct {

    char word[255];
    //int word;
    }Lista;

Lista tab[5];
void dodaj(int i){

char slowo[255];
printf("podaj slowo: ");

scanf("%s", &slowo);

strcpy(tab[i].word,slowo);

}

int main(){


int menu;
printf("wybierz 1 aby dodac\n");
int i =0;

while ( i < 5){
   dodaj(i);
   i++;

   }

for(i =0 ; i < 5; i++)
printf("%s \n",tab[i].word);

return 0;
}

