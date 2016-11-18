//import java.io.File;
//import java.io.FileNotFoundException;
//import java.util.Scanner;
//import java.io.IOException;
import java.io.*;
import java.util.*;
public class Odczyt{
  public static void main(String[] args)throws IOException
               {
      

                File file = new File(args[0]);
                Scanner in = new Scanner(file);
                String linia;
                int i =0;
                int licznik;
                int suma=0;
		while (in.hasNextLine())
                       {
                        i++;
			licznik=((in.nextLine()).length());
                        suma=suma+licznik;
                       }
                System.out.println("ilosc lini: "+i+" ilosc znakow: "+suma);
               }
   
