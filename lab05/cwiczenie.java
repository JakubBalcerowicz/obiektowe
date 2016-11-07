import java.io.*;






class Bakteria{
    static void print(String s){System.out.println(s);}
   Bakteria()
   {
   print("jestem bakteria zyje");
   }
}

class Pierwotniak extends Bakteria{
  Pierwotniak()
{
print("jestem czyms wiecej niz bakteria");
}
}

class czlowiek extends Pierwotniak{
   czlowiek()
   { System.out.println("czlowiek");}
    public static void main(String[] args){
  
  //Bakteria b = new Bakteria();
  Pierwotniak p = new Pierwotniak();

  }
}
