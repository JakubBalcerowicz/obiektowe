import java.io.*;

class Punkt{
  double x;
  double y;
  Punkt(){
  }
   Punkt(double x, double y)

      {
        this.x = x;
        this.y = y;
      }
   Punkt(int x,int y)
  {
    this.x = (double) x;
    this.y = (double) y;
  }
double iloczyn()
{
   return this.x * this.y;
}
}

class Punkt3D extends Punkt {
//double x;
//double y;
  double z;
}
