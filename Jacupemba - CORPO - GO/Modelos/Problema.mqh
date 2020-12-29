//+------------------------------------------------------------------+
//|                                                     Problema.mqh |
//|                        Copyright 2020, MetaQuotes Software Corp. |
//|                                          https://gabrielochoa.me |
//+------------------------------------------------------------------+
#property copyright "Copyright 2020, MetaQuotes Software Corp."
#property link      "https://gabrielochoa.me"
#property version   "1.00"
class Problema
  {
private:
   double _Saida;
   int Quantidade;

public:
                     Problema();
                     Problema(const int Quant);
                    ~Problema();
                    
                    double     Random() { return round((double)MathRand()/32767); }
                    
                    void   Entrada(double &Resultado[]);
                    double   Saida() { return _Saida; }
  };
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
Problema::Problema()
{ }
Problema::Problema(const int Quant)
{
   this.Quantidade = Quant;
}
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
Problema::~Problema()
{
}
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
void Problema::Entrada(double &Resultado[])
{
   //Quantidade = 4;
   
   ArrayResize(Resultado, Quantidade);

   _Saida = 0;

   for (int i = 0; i < Quantidade; i++)
   {
       Resultado[i] = Random();

       _Saida += (int)Resultado[i] * (int)MathPow(2, i);
   }
}
//+------------------------------------------------------------------+
