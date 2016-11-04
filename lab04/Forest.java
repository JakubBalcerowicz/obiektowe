import java.io.*;
import java.util.Random;

class Forest{


public static void main(String[] args){

   int[][] forest = new int[10][10];
   int i;
   int j;
Random randomGenerator = new Random(); 
for (i = 0; i < 10; i++){

for (j = 0; j < 10; j++){

forest[i][j] = randomGenerator.nextInt(2);

System.out.printf("  %d  ",forest[i][j]);
}
System.out.printf("\n");
System.out.printf("\n");
}
 

}
}
