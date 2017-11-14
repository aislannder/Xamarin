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

            switch (operador)
            {
                case "÷":
                    resultado = valor1 / valor2;
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
  
            }

            return resultado;
        }
    }
}