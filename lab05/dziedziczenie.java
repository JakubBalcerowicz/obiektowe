import java.io.*;

class A{
 A() { System.out.println("konstruuje A");}
 void akuku(){System.out.println("kuku z A");}
}

class B extends A{
 B() 
  { System.out.println("konstruuje B");}
  //void akuku(){System.out.println("kuku z B");}
}


class C extends B{
 C() 
  { System.out.println("konstruuje C");}
  //void akuku(){System.out.println("kuku z C");}

  public static void main(String[] args)
  {
  C c = new C();
  c.akuku();
  }
}
