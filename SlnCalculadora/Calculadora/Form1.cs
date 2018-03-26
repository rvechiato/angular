using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        String Operacao = "";
        Decimal Numero1 = 0;
        Decimal Numero2 = 0;
        Decimal Resultado = 0;
        Boolean OperacaoRealizada = false;
                
        public Form1()
        {
            InitializeComponent();
        }
#region "Numeros"

        private void btnNumero1_Click(object sender, EventArgs e)
        {
            NumeroDoBotao("1");
        }

        private void btnNumero2_Click(object sender, EventArgs e)
        {
            NumeroDoBotao("2");
        }

        private void btnNumero3_Click(object sender, EventArgs e)
        {
            NumeroDoBotao("3"); 
        }

        private void btnNumero4_Click(object sender, EventArgs e)
        {
            NumeroDoBotao("4");
        }

        private void btnNumero5_Click(object sender, EventArgs e)
        {
            NumeroDoBotao("5");
        }

        private void btnNumero6_Click(object sender, EventArgs e)
        {
            NumeroDoBotao("6");
        }

        private void btnNumero7_Click(object sender, EventArgs e)
        {
            NumeroDoBotao("7");
        }

        private void btnNumero8_Click(object sender, EventArgs e)
        {
            NumeroDoBotao("8");
        }

        private void btnNumero9_Click(object sender, EventArgs e)
        {
            NumeroDoBotao("9");
        }

        private void btnNumero0_Click(object sender, EventArgs e)
        {
            NumeroDoBotao("0");
        }
        private void btnPonto_Click(object sender, EventArgs e)
        {
            if (IsValorVazio() == true)
            {
                NumeroDoBotao(",");                
            }
            else
            {
                NumeroDoBotao("0,");
            }
        }

        #endregion 
#region "Resultado" 
        private void btnResultado_Click(object sender, EventArgs e)
        {
            //Corrigir para  que repita a operação se o = for apertado nuvamente
            OperacaoRealizada = true;

            if (Operacao == "+")
            {
                RealizarOperacao();                       
            }
            else if (Operacao == "-")
            {
                RealizarOperacao();
            }
            else if (Operacao == "*")
            {
                RealizarOperacao();              
            }
            else if (Operacao == "/")
            {
                Numero2 = Convert.ToDecimal(txtTelaQueMostraOsNumeros.Text);//Erro segundo numero nulo
                if (Numero2 == 0)
                {
                    txtTelaQueMostraOsNumeros.Text = "Impossível Dividir por 0";
                    Numero1 = 0;
                    btnDividir.Enabled = false;
                    btnSoma.Enabled = false;
                    btnMultiplicar.Enabled = false;
                    btnSqrt.Enabled = false;
                    btnSubtracao.Enabled = false;
                    btnLimpaUltimo.Enabled = false;                    
                }
                else
                {
                    RealizarOperacao();
                }
            }   
        }
#endregion 
#region "Operar"
        
        private void btnSoma_Click(object sender, EventArgs e)
        {
            if (IsValorVazio() == true)
            {
                Processo("+");                
            }
            else
            {
                MensagemErro();
            }
        }
        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            if (IsValorVazio() == true)
            {
                Processo("-");
            }
            else
            {
                MensagemErro();
            }
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            if (IsValorVazio() == true)
            {
                Processo("*");
            }
            else
            {
                MensagemErro();
            }
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            if (IsValorVazio() == true)
            {
                Processo("/");

            }
            else
            {
                MensagemErro();
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (IsValorVazio() == true)
            {
                Numero1 = Convert.ToDecimal(txtTelaQueMostraOsNumeros.Text);
                txtValorAOperar.Text = "√" + txtTelaQueMostraOsNumeros.Text;
                Resultado = Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(Numero1)));
                txtTelaQueMostraOsNumeros.Text = Convert.ToString(Resultado);
                             
            }
            else
            {
                MensagemErro();
            }
        }      

        private void btnlimpar_Click(object sender, EventArgs e)
        {            
            txtValorAOperar.Text = "";
            txtTelaQueMostraOsNumeros.Text = "";
            Numero1 = 0;
            Numero2 = 0;
            AtivaBotoes();
        }
        
        private void btnLimpaUltimo_Click(object sender, EventArgs e)
        {            
            txtTelaQueMostraOsNumeros.Text = "";
        }

        private void txtTelaQueMostraOsNumeros_KeyDown(object sender, KeyEventArgs e)
        {
            IsValorEhLetra(e);
        }
#endregion
#region "Funções e Procedimentos"

        private bool IsValorVazio()
        {
            if (txtTelaQueMostraOsNumeros.Text != "" )
            {
                return true;
            }
            else
            {
                return false;
            }  
        }

        private void Processo(string SinalOperacao)
        {
            Numero1 = Convert.ToDecimal(txtTelaQueMostraOsNumeros.Text);
            txtValorAOperar.Text = txtTelaQueMostraOsNumeros.Text + SinalOperacao;
            //txtTelaQueMostraOsNumeros.Text = Convert.ToString(Numero1);
            txtTelaQueMostraOsNumeros.Text = "";
            Operacao = SinalOperacao;
            txtTelaQueMostraOsNumeros.Focus();
            OperacaoRealizada = false;
            btnLimpaUltimo.Enabled = true;
        }

        private void MensagemErro()
        {
            MessageBox.Show("Favor informar os valores!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void NumeroDoBotao(string Numero)
        {
            if (OperacaoRealizada == true)
            {
                txtValorAOperar.Text = "";
                txtTelaQueMostraOsNumeros.Text="";
                txtTelaQueMostraOsNumeros.Text = txtTelaQueMostraOsNumeros.Text + Numero;                
                OperacaoRealizada = false;
                AtivaBotoes();
            }
            else
            {   
                AtivaBotoes();
                txtTelaQueMostraOsNumeros.Text = txtTelaQueMostraOsNumeros.Text + Numero;
                
            }
        }

        private void IsValorEhLetra(KeyEventArgs e)
        {
            if (e.KeyCode.ToString() != "NumPad0"
                && e.KeyCode.ToString() != "NumPad1"
                && e.KeyCode.ToString() != "NumPad2"
                && e.KeyCode.ToString() != "NumPad3"
                && e.KeyCode.ToString() != "NumPad4"
                && e.KeyCode.ToString() != "NumPad5"
                && e.KeyCode.ToString() != "NumPad6"
                && e.KeyCode.ToString() != "NumPad7"
                && e.KeyCode.ToString() != "NumPad8"
                && e.KeyCode.ToString() != "NumPad9")
            {                
                MessageBox.Show("Valor Incorredo");
                txtTelaQueMostraOsNumeros.Text = "";
            }
        }

        private void RealizarOperacao() 
        {
            Numero2 = Convert.ToDecimal(txtTelaQueMostraOsNumeros.Text);//Erro segundo numero nulo
            txtValorAOperar.Text += txtTelaQueMostraOsNumeros.Text;
            if (Operacao == "+")
            {
                Resultado = Numero1 + Numero2;
            }
            else if (Operacao == "-")
            {
                Resultado = Numero1 - Numero2; 
            }
            else if (Operacao == "*")
            {
                Resultado = Numero1 * Numero2;
            }
            else if (Operacao == "/")
            {
                Resultado = Numero1 / Numero2;
            }
            Numero1 = 0;
            txtTelaQueMostraOsNumeros.Text = Convert.ToString(Resultado);
            btnLimpaUltimo.Enabled = false;
        }

        private void AtivaBotoes()
        {
            btnLimpaUltimo.Enabled = true;
            btnDividir.Enabled = true;
            btnSoma.Enabled = true;
            btnMultiplicar.Enabled = true;
            btnSubtracao.Enabled = true;
            btnSqrt.Enabled = true;
            btnLimpaUltimo.Enabled = true;
        }
#endregion
    }
}
