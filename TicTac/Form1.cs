using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool turnoPikachu = true; // true para Pikachu, false para Charizard
        private bool juegoActivo = true; // Indica si el juego está activo

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            RealizarMovimiento(btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            RealizarMovimiento(btn2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            RealizarMovimiento(btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            RealizarMovimiento(btn4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            RealizarMovimiento(btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            RealizarMovimiento(btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            RealizarMovimiento(btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            RealizarMovimiento(btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            RealizarMovimiento(btn9);
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ReiniciarJuego();
        }

        private void RealizarMovimiento(Button boton)
        {
            if (!juegoActivo || boton.Tag != null) return; // Ignorar si el juego no está activo o el botón ya está ocupado

            if (turnoPikachu)
            {
                boton.BackgroundImage = Properties.Resources.f_1;
                boton.Tag = "Pikachu";
            }
            else
            {
                boton.BackgroundImage = Properties.Resources.f_2;
                boton.Tag = "Charizard";
            }

            turnoPikachu = !turnoPikachu; // Cambiar el turno
            VerificarGanador();
        }

        private void VerificarGanador()
        {
            // Listas de combinaciones ganadoras (posiciones en filas, columnas y diagonales)
            if (EsGanador(btn1, btn2, btn3) || // fila 1
                EsGanador(btn4, btn5, btn6) || // fila 2
                EsGanador(btn7, btn8, btn9) || // fila 3
                EsGanador(btn1, btn4, btn7) || // columna 1
                EsGanador(btn2, btn5, btn8) || // columna 2
                EsGanador(btn3, btn6, btn9) || // columna 3
                EsGanador(btn1, btn5, btn9) || // diagonal principal
                EsGanador(btn3, btn5, btn7))   // diagonal inversa
            {
                // Si hay un ganador, mostrar quién ganó y desactivar los botones
                string ganador = turnoPikachu ? "Charizard" : "Pikachu";
                MessageBox.Show($"{ganador} es el ganador!", "¡Felicidades!");

                DesactivarBotones();
            }
        }

        private bool EsGanador(Button b1, Button b2, Button b3)
        {
            // Verificar que los tres botones tengan el mismo Tag y no sean null
            if (b1.Tag != null && b2.Tag != null && b3.Tag != null)
            {
                if (b1.Tag.ToString() == b2.Tag.ToString() &&
                    b2.Tag.ToString() == b3.Tag.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private void DesactivarBotones()
        {
            // Desactivar todos los botones después de que hay un ganador
            juegoActivo = false; // Cambia el estado del juego a inactivo
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
        }

        private void ReiniciarJuego()
        {
            // Reiniciar la imagen de todos los botones a la Pokebola
            btn1.BackgroundImage = Properties.Resources.f_0;
            btn2.BackgroundImage = Properties.Resources.f_0;
            btn3.BackgroundImage = Properties.Resources.f_0;
            btn4.BackgroundImage = Properties.Resources.f_0;
            btn5.BackgroundImage = Properties.Resources.f_0;
            btn6.BackgroundImage = Properties.Resources.f_0;
            btn7.BackgroundImage = Properties.Resources.f_0;
            btn8.BackgroundImage = Properties.Resources.f_0;
            btn9.BackgroundImage = Properties.Resources.f_0;

            // Reactivar los botones
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;

            // Restablecer el estado de los botones
            btn1.Tag = null;
            btn2.Tag = null;
            btn3.Tag = null;
            btn4.Tag = null;
            btn5.Tag = null;
            btn6.Tag = null;
            btn7.Tag = null;
            btn8.Tag = null;
            btn9.Tag = null;

            // Reiniciar el turno a Pikachu
            turnoPikachu = true;
            juegoActivo = true; // Activar el juego nuevamente
        }

    }
}



    

