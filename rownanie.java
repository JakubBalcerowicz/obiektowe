import java.io.*;

class wartosci{
        int wartx;
        int warty;
        int wartz;
        

        void ustawX(int x){
		wartx = x;
	}
	void ustawY(int y){
		warty = y;
	}
        
        void ustawZ(int z){
		wartz = z;
	}

	int dajX(){
		return wartx;
	}
	int dajY(){
		return warty;
	}
        int dajZ(){
		return wartz;
	}
}

public class trojmian{
public static void main(String args[]){
	
        double delta;
        double deltasqrt;
        double x1;
        double x2;
        wartosci w = new wartosci();
		
        String x = args[0];
        String y = args[1]; 
        String z = args[2];
        w.ustawX(Integer.valueOf(x));
        w.ustawY(Integer.valueOf(y));
        w.ustawZ(Integer.valueOf(z));
	System.out.println("A="+w.dajX()+" "+"B="+w.dajY()+" "+"C="+w.dajZ());	
        System.out.println(x+"(x^2)"+"+"+y+"x"+"+"+z);
        System.out.println("Sprawdzamy czy rowanie jest kwadratowe");
        if(w.dajX() == 0)
         {
             System.out.println("to nie jets rowanie kwadratowe");
         }
        else
        {
             
             delta = w.dajY()*w.dajY()-4*(w.dajZ()*w.dajX());
             System.out.println("delta jets rowna:"+delta);
             if(delta == 0)
             {
                x1= (-w.dajY())/2*w.dajX();
                System.out.println("x1="+x1);
                
             } 
             else if(delta > 0)
             {
             deltasqrt = Math.sqrt(delta); 
             System.out.println("pierw delta="+deltasqrt);
             x1=(-w.dajY()+deltasqrt)/2*w.dajX();
             x2=(-w.dajY()-deltasqrt)/2*w.dajX();
             System.out.println("x1="+x1+" x2="+x2);
             }
             else
             {
             System.out.println("NIE MA ROZWIAZANIA delta ujemna");
             }
        }
}
}
