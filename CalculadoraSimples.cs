using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public static class CalculadoraSimples
    {

        public static double Calcular(double valor1, double valor2, string operador)
        {
            double resultado = 0;
            
            try
            {
                switch (operador)
                {
                    case "÷":
                        if (valor2 != 0)
                        {
                            resultado = valor1 / valor2;
                        }
                        else
                        {
                            resultado =  -0.0000; // error 
                        }
                        break;
                    case "×":
                        resultado = valor1 * valor2;
                        break;
                    case "+":
                        resultado = valor1 + valor2;
                        break;
                    case "-":
                        resultado = valor1 - valor2;
                        break;
                    case "":
                        resultado = valor1;
                        break;
                    default:
                        return -0.0000; // error 
                }
            }
            catch (Exception)
            {
                resultado = 0;
            }

            return resultado;
        }
    }
}