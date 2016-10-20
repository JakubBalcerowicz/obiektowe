import java.io.*;

class Pesel2{
  String pesel;
  Pesel2(String pes){
    pesel = pes;
  }
  int at(int n){
    return Character.getNumericValue(pesel.charAt(n));
  }
  boolean valid(){
    int sum=at(0)+at(1)*3+at(2)*7+at(3)*9+
            at(4)+at(5)*3+at(6)*7+at(7)*9+
            at(8)+at(9)*3+at(10);
    if (sum%10 == 0) return true;
    else return false;
  }
  public static void main(String[] args){
    Pesel2 p = new Pesel2(args[0]);
    if (p.valid()) System.out.println("PESEL is OK");
    else System.out.println("PESEL is WRONG");
  }
}
