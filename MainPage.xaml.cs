using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        int estadoCorrente = 1;
        string operador;
        double primeiroNumero, segundoNumero;
        double resultado = 0;

	    private bool temPonto = false;

        public MainPage()
        {
            InitializeComponent();
            OnLimpar(this, null);
        }

        void OnSelecionarNumero(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            string clicado = botao.Text;

            
            //caso digite 0 ou estado seja menor que 0, significa que em algum momento foi digitado um operador
            if (this.resultadoTela.Text == "0" || estadoCorrente < 0)
            {
                if (!temPonto) {
                    this.resultadoTela.Text = "";
                }

                if (estadoCorrente < 0)
                    estadoCorrente *= -1;
            }

            this.resultadoTela.Text += clicado;

            //converte a string do visor para um double
            if (double.TryParse(this.resultadoTela.Text, out double numero))
            {
                //apresenta numeros grandes com virgulas Ex: 10,000,00
                //this.resultadoTela.Text = numero.ToString("N0");
                this.resultadoTela.Text = numero.ToString();


                //verifica se o estado corrente não tem um operador
                if (estadoCorrente == 1)
                {
                    primeiroNumero = numero;
                }
                else
                {
                    segundoNumero = numero;
                }
            }
        }

        void OnSelecionarOperadorMaisOuMenos(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            string clicado = botao.Text;

            //caso seja o operador +/-
            if (clicado == "+/-")
            {
                if (primeiroNumero >= 0 && estadoCorrente == 1)
                {
                    primeiroNumero = double.Parse(this.resultadoTela.Text) * (-1);
                    this.resultadoTela.Text = primeiroNumero.ToString();

                    this.resultadoTela.Text = (double.Parse(this.resultadoTela.Text) * (-1)).ToString();
                    segundoNumero = (segundoNumero * (-1));

                }
                else if (estadoCorrente == -1 || estadoCorrente == 2)
                {

                    this.resultadoTela.Text = (double.Parse(this.resultadoTela.Text) * (-1)).ToString();
                    segundoNumero = (segundoNumero * (-1));
                }
            }

            //estadoCorrente = -2;
        }

        void OnSelecionarOperador(object sender, EventArgs e)
        {

            Button botao = (Button)sender;
            string clicado = botao.Text;

            estadoCorrente = -2;
            temPonto = false;
            operador = clicado;

        }

        void OnSelecionarPonto(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
            
            if (estadoCorrente == 1)
            {

                //Verifique se já possui um ponto (caso contrario não faz nada)
                if(!temPonto){
                    if (this.resultadoTela.Text.Length != 0)
                    {
                       
                            this.resultadoTela.Text = this.resultadoTela.Text + button.Text;
                            //Alternar o sinalizador para verdadeiro (apenas 1 decimal por cálculo)
                            temPonto = true;
                    }
                }
            }
            else
            {
                this.resultadoTela.Text = "0.";
                temPonto = true;
               
            }
        }

        void OnLimpar(object sender, EventArgs e)
        {
            primeiroNumero = 0;
            segundoNumero = 0;
            resultado = 0;
            operador = "";
            estadoCorrente = 1;
            temPonto = false;
            this.resultadoTela.Text = "0";
        }

        void OnCalcular(object sender, EventArgs e)
        {
            if (estadoCorrente == 1)
            {
                resultado = CalculadoraSimples.Calcular(primeiroNumero, segundoNumero, operador);
            }

            if (estadoCorrente == 2)
            {
                resultado = CalculadoraSimples.Calcular(primeiroNumero, segundoNumero, operador);
            }
            else if (estadoCorrente == -2 || estadoCorrente == -1)
            {
                if (segundoNumero == 0)
                {
                    segundoNumero = Convert.ToDouble(this.resultadoTela.Text);
                }

                resultado = CalculadoraSimples.Calcular(primeiroNumero, segundoNumero, operador);
            }

            
            this.resultadoTela.Text = resultado.ToString();
            primeiroNumero = resultado;
            estadoCorrente = -1;
            temPonto = false;
        }
    }
}