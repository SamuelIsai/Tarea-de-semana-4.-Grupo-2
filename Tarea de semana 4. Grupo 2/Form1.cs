using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea_de_semana_4.Grupo_2
{
    public partial class Form1 : Form
    {
        // Crea un objeto aleatorio llamado randomizer
        // para generar números aleatorios.
        Random randomizer = new Random();

        // Estas variables enteras almacenan los números
        // para el problema de la suma.
        int addend1;
        int addend2;

        // Estas variables enteras almacenan los números
        // para el problema de resta.
        int minuend;
        int subtrahend;


        // Estas variables enteras almacenan los números
        // para el problema de multiplicación.
        int multiplicand;
        int multiplier;

        // Estas variables enteras almacenan los números
        // para el problema de la división.
        int dividend;
        int divisor;

        // Esta variable entera realiza un seguimiento de la
        // tiempo restante.
        int timeLeft;

        /// <resumen>
        /// Inicie el cuestionario completando todos los problemas
        /// e iniciando el temporizador.
        /// </summary>
        public void StartTheQuiz()
        {
            // Completa el problema de la suma.
            // Genera dos números aleatorios para sumar.
            // Almacenar los valores en las variables 'addend1' y 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convierte los dos números generados aleatoriamente
            // en cadenas para que se puedan mostrar
            // en los controles de la etiqueta.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'suma' es el nombre del control NumericUpDown.
            // Este paso asegura que su valor sea cero antes
            // añadiéndole cualquier valor.
            suma.Value = 0;

            // Completa el problema de resta.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            diferencia.Value = 0;

            // Completa el problema de multiplicación.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            Producto.Value = 0;

            // Completa el problema de división
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Inicia el temporizador.
            timeLeft = 30;
            timeLabel.Text = "30 segundos";
            timer1.Start();
            timeLabel.BackColor = Color.Red;
        }

        /// <resumen>
        /// Verifique la respuesta para ver si el usuario hizo todo bien.
        /// </summary>
        /// <returns> Verdadero si la respuesta es correcta, falso en caso contrario. </returns>
        
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == suma.Value)
                && (minuend - subtrahend == diferencia.Value)
                && (multiplicand * multiplier == Producto.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void plusLeftLabel_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // Si CheckTheAnswer () devuelve verdadero, entonces el usuario
                // tengo la respuesta correcta. Detén el cronómetro
                // y muestra un MessageBox.
                timer1.Stop();
                MessageBox.Show("¡Tienes todas las respuestas correctas!",
                                "¡Felicidades!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Muestra el nuevo tiempo restante
                // actualizando la etiqueta Tiempo restante.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " segundos";
            }
            else
            {
                // Si el usuario se quedó sin tiempo, detenga el temporizador, muestre
                // un MessageBox y complete las respuestas.
                timer1.Stop();
                timeLabel.Text = "¡Se acabó el tiempo!";
                MessageBox.Show("No terminaste a tiempo", "¡Lo siento!");
                suma.Value = addend1 + addend2;
                diferencia.Value = minuend - subtrahend;
                Producto.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }

        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

    }
}
