using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TeamInit();
        }

        Dictionary<string, double> TeamParams = new Dictionary<string, double>();
        int day = 0;
        public int getValue(double lambda)
        {
            Random rnd = new Random();
            int m = 0;
            double a = rnd.NextDouble();
            double S = Math.Log(a);
            while (S > lambda)
            {
                m++;
                a = rnd.NextDouble();
                S += Math.Log(a);
            }
            return m;
        } 
        public void TeamInit()
        {
            TeamParams.Add("Man United", -4.5);
            TeamParams.Add("West Ham", -3.7);
            TeamParams.Add("Aston Villa", -3.5);
            TeamParams.Add("Brighton", -1.3);
            TeamParams.Add("Chelsea", -5.0);
            TeamParams.Add("Tottenham", -2.5);
            TeamParams.Add("Liverpool", -3.3);
            TeamParams.Add("Man City", -3.9);
        }
        private void play(Label team1, Label team2, Label result1, Label result2, Label winner)
        {
            int a, b;
            a = getValue(TeamParams[team1.Text]);
            b = getValue(TeamParams[team2.Text]);
            result1.Text = a.ToString();
            result2.Text = b.ToString();
            if (a > b) winner.Text = team1.Text;
            if (a < b) winner.Text = team2.Text;
            if (a == b) play(team1, team2, result1, result2, winner);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (day)
            {
                case 0:
                    play(label1, label4, label2, label3, label18);
                    play(label6, label8, label5, label7, label20);
                    play(label10, label12, label9, label11, label24);
                    play(label14, label16, label13, label15, label26);
                    break;
                case 1:
                    play(label18, label20, label17, label19, label22);
                    play(label24, label26, label23, label25, label28);
                    break;
                case 2:
                    play(label22, label28, label21, label27, label29);
					label30.Text = "The champion is:";
					break;
				default:
                    this.Close();
                    break;
            }
            day++;
		}
	}
}
