
import java.util.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

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

class Okno extends JFrame implements ActionListener{
  double x1;
  double x2;
  double delta;
  JTextField poleA,poleB,poleC,poleD;
  String dane;
  JButton guzikOff, LICZ;
  JLabel data,A,B,C,X1,X2,DELTA,dataX1,dataX2,dataDELTA,info;
  JButton zrobGuzik(int x, int y, int w, int h, String t){
    JButton b = new JButton(t);
    b.setBounds(x, y, w, h);
    b.addActionListener(this);
    return b;
   }
  JLabel zrobmetke(int x, int y, int w, int h, String t){
    JLabel c = new JLabel(t);
    c.setBounds(x, y, w, h);
    
    return c;
  }

  Okno(){
    super("Rownanie kwadratowe");     
    setLocation(550, 275);
    setSize(500, 250);
    setLayout(null);
    setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    setVisible(true);
    guzikOff = zrobGuzik(340, 200, 150, 30, "Zakończ");
    LICZ = zrobGuzik(10, 10, 150, 30, "LICZ");
    add(guzikOff);
    add(LICZ);
    A = zrobmetke(40, 40, 30, 50, "x^2");
    B = zrobmetke(70, 40, 10, 50, "+");
    C = zrobmetke(100, 40, 20, 50, "x+");
    X1 = zrobmetke ( 10 , 110 , 30 , 50, "X1:");
    dataX1 = zrobmetke ( 50 , 110 , 200 , 50, "");
    add(dataX1);
    X2 = zrobmetke ( 10 , 150 , 30 , 50, "X2:");
    dataX2 = zrobmetke ( 50 , 150 , 200 , 50, "");
    add(dataX2);
    DELTA = zrobmetke ( 10 , 70 , 60 , 50, "DELTA:");
    dataDELTA = zrobmetke ( 90 , 70 , 230 , 50, "");
    add(dataDELTA);
    add(DELTA);
    add(X1);
    add(X2);
    add(C);
    add(B);
    add(A);
    info =  zrobmetke ( 10 , 200 , 200 , 50, "Uzupelnij pola i klinij LICZ");
    add(info);
    poleA = new JTextField();
    poleA.setBounds(10, 50, 20, 30);
    add(poleA);
    
    poleB = new JTextField();
    poleB.setBounds(80, 50, 20, 30);
    add(poleB);


    poleC = new JTextField();
    poleC.setBounds(120, 50, 20, 30);
    add(poleC);
 
  }

  private void licz(String A,String B, String C){
        
        double deltasqrt;
        wartosci w = new wartosci();
	String x = A;
        String y = B; 
        String z = C;
        w.ustawX(Integer.valueOf(x));
        w.ustawY(Integer.valueOf(y));
        w.ustawZ(Integer.valueOf(z));
        {
             
             delta = w.dajY()*w.dajY()-4*(w.dajZ()*w.dajX());
            
             if(delta == 0)
             {
                x1= (-w.dajY())/2*w.dajX();
                System.out.println("x1="+x1);
                
             } 
             else if(delta > 0)
             {
             deltasqrt = Math.sqrt(delta); 
             
             x1=(-w.dajY()+deltasqrt)/(2*w.dajX());
             x2=(-w.dajY()-deltasqrt)/(2*w.dajX());
             
             
             }
             else
             {
            
             }
        }

}
   
  public void actionPerformed (ActionEvent e){
    Object src = e.getSource();
    if (src == guzikOff){
      this.dispose();
    }
    else if (src == LICZ){
      licz(poleA.getText(),poleB.getText(),poleC.getText());
  
      if(delta == 0)
      { 
      
      dataDELTA.setText(""+delta+" x1 pierwaistek podwojny");
      dataX1.setText(""+x1);
      dataX2.setText("");

      }
      else if(delta > 0){
      
      dataX1.setText(""+x1);
      dataX2.setText(""+x2);
      dataDELTA.setText(""+delta);

      }

      else
      {
      dataDELTA.setText("UJEMNA nie ma rozwiazania");
      dataX1.setText("");
      dataX2.setText("");
     }
    }
  }
}

public class Zadanie4{
  public static void main(String[] args){
    EventQueue.invokeLater(new Runnable(){
      public void run(){
        new Okno();
       
      }
    });
  }
}
