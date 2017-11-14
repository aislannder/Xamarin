using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string operador;
        double primeiroNumero, segundoNumero;
        double resultado = 0;

        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            //caso digite 0 ou 
            if (this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.resultText.Text += pressed;

            //converte a string do visor para um double
            if (double.TryParse(this.resultText.Text, out double numero))
            {
                //apresenta numeros grandes com virgulas Ex: 10,000,00
                //this.resultText.Text = numero.ToString("N0");
                this.resultText.Text = numero.ToString();


                //verifica se o estado corrente não é um operador
                if (currentState == 1)
                {
                    primeiroNumero = numero;
                }
                else
                {
                    int teste = currentState;
                    segundoNumero = numero;
                }
            }
        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            operador = pressed;
        }

        void OnSelectDot(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            string valorNaTela = this.resultText.Text;
            int tamanho = valorNaTela.Length;

            if (tamanho != 0)
            {
                string novoValor = valorNaTela.Substring(tamanho - 1, 1);

                if (novoValor != ".")
                {
                    if (novoValor == "-" || novoValor == "+" || novoValor == "*" || novoValor == "/")
                    {
                        string str1 = valorNaTela.Substring(0, tamanho - 1);
                        this.resultText.Text = str1;
                    }
                    this.resultText.Text = this.resultText.Text + button.Text;
                }
            }
        }

        void OnClear(object sender, EventArgs e)
        {
            primeiroNumero = 0;
            segundoNumero = 0;
            resultado = 0;
            operador = "";
            currentState = 1;
            this.resultText.Text = "0";
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 1)
            {
                    resultado = CalculadoraSimples.Calcular(primeiroNumero, segundoNumero, operador);
            }

            if (currentState == 2)
            {
                resultado = CalculadoraSimples.Calcular(primeiroNumero, segundoNumero, operador);
            }
            else if (currentState == -2 || currentState == -1)
            {
                if (segundoNumero == 0)
                {
                    segundoNumero = Convert.ToDouble(this.resultText.Text);
                }

                resultado = CalculadoraSimples.Calcular(primeiroNumero, segundoNumero, operador);
            }

            this.resultText.Text = resultado.ToString("N0");
            primeiroNumero = resultado;
            currentState = -1;
        }
    }
}
