using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

			// Create a label control
			Label dateLabel = new Label();
			dateLabel.Text = DateTime.Now.ToString("dd, MMMM , yyyy");

			// Set the location and size of the label control
			dateLabel.Location = new System.Drawing.Point(215, 195);
			dateLabel.Font = new System.Drawing.Font("Arial", 10);
			dateLabel.AutoSize = true;

			// Add the label control to the form
			this.Controls.Add(dateLabel);
		}

		Random randomizer = new Random();

        int addend1, addend2;

		int minuend, subtrahend;

		int multiplicand, multiplier;

		int dividend, divisor;
		
		int timeLeft;

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (CheckTheAnswer())
			{
				timer1.Stop();
				MessageBox.Show("You got all the answers right!",
								"Congratulations!");
				startButton.Enabled = true;
			}
			else if (timeLeft > 0)
			{
				timeLeft = timeLeft - 1;
				timeLabel.Text = timeLeft + " seconds";
			}
			else if (timeLeft <= 5)
			{
				timeLabel.BackColor = Color.Red;
			}
			else
			{
				timer1.Stop();
				timeLabel.Text = "Time's up!";
				MessageBox.Show("You didn't finish in time.", "Sorry!");
				sum.Value = addend1 + addend2;
				difference.Value = minuend - subtrahend;
				product.Value = multiplicand * multiplier;
				quotient.Value = dividend / divisor;
				startButton.Enabled = true;
			}
		}

		private void answer_Enter(object sender, EventArgs e)
		{
			NumericUpDown answerBox = sender as NumericUpDown;

			if (answerBox != null)
			{
				int lengthOfAnswer = answerBox.Value.ToString().Length;
				answerBox.Select(0, lengthOfAnswer);
			}
		}

		private void startButton_Click(object sender, EventArgs e)
		{
			StartTheQuiz();
			startButton.Enabled = false;
		}

		public void StartTheQuiz()
		{

			addend1 = randomizer.Next(51);
			addend2 = randomizer.Next(51);

			plusLeftLabel.Text = addend1.ToString();
			plusRightLabel.Text = addend2.ToString();

			sum.Value = 0;

			minuend = randomizer.Next(1, 101);
			subtrahend = randomizer.Next(1, minuend);
			minusLeftLabel.Text = minuend.ToString();
			minusRightLabel.Text = subtrahend.ToString();
			difference.Value = 0;

			multiplicand = randomizer.Next(2, 11);
			multiplier = randomizer.Next(2, 11);
			timesLeftLabel.Text = multiplicand.ToString();
			timesRightLabel.Text = multiplier.ToString();
			product.Value = 0;

			divisor = randomizer.Next(2, 11);
			int temporaryQuotient = randomizer.Next(2, 11);
			dividend = divisor * temporaryQuotient;
			dividedLeftLabel.Text = dividend.ToString();
			dividedRightLabel.Text = divisor.ToString();
			quotient.Value = 0;

			timeLeft = 30;
			timeLabel.Text = "30 seconds";
			timer1.Start();

		}

		private bool CheckTheAnswer()
		{
			if ((addend1 + addend2 == sum.Value)
				&& (minuend - subtrahend == difference.Value)
				&& (multiplicand * multiplier == product.Value)
				&& (dividend / divisor == quotient.Value))
				return true;
			else
				return false;
		}

	}
}
