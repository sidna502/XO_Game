using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enPlayer PlayerTurn = enPlayer.Player1;
        stGameStatus GameStatus;
        enum enPlayer { Player1, Player2 };
        enum enWinner { Player1, Player2, Draw, InPgrogress };
        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayerCount;
        }
        void EndGame()
        {
            lblTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player 1";
                    break;
                case enWinner.Player2:
                    lblWinner.Text = "Player 2";
                    break;
                default:
                    lblWinner.Text = "Draw";
                    break;
            }
            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn2.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.YellowGreen;
                btn2.BackColor = Color.YellowGreen;
                btn3.BackColor = Color.YellowGreen;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }
            else
            {
                GameStatus.GameOver = false;
                return false;
            }
        }
        void CheckWinner()
        {
            if (CheckValues(button1, button2, button3)) return;
            if (CheckValues(button4, button5, button6)) return;
            if (CheckValues(button7, button8, button9)) return;
            if (CheckValues(button1, button4, button7)) return;
            if (CheckValues(button2, button5, button8)) return;
            if (CheckValues(button3, button6, button9)) return;
            if (CheckValues(button1, button5, button9)) return;
            if (CheckValues(button3, button5, button7)) return;
        }
        void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Properties.Resources.X;
                        lblTurn.Text = "Player 2";
                        PlayerTurn = enPlayer.Player2;
                        GameStatus.PlayerCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;

                    case enPlayer.Player2:
                        btn.Image = Properties.Resources.O;
                        lblTurn.Text = "Player 1";
                        PlayerTurn = enPlayer.Player1;
                        GameStatus.PlayerCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
            }
            else
                MessageBox.Show("You are already made a choice", "Wrong Choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (GameStatus.PlayerCount == 9)
            {
                GameStatus.Winner = enWinner.Draw;
                GameStatus.GameOver = true;
                EndGame();
            }
        }
        void RestButton(Button btn)
        {
            btn.Image = Properties.Resources.question_mark_96;
            btn.BackColor = Color.Transparent;
            btn.Tag = "?";
        }
        void RestartGame()
        {
            RestButton(button1); 
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);
            GameStatus.Winner = enWinner.InPgrogress;
            GameStatus.PlayerCount = 0;
            PlayerTurn = enPlayer.Player1;
            lblWinner.Text = "In Progress";
            lblTurn.Text = "Player 1";

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color white = Color.FromArgb(255, 255, 255, 255);
            Pen whitePen = new Pen(white);
            whitePen.Width = 15;
            //whitePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //draw Horizental lines
            e.Graphics.DrawLine(whitePen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(whitePen, 400, 460, 1050, 460);

            //draw Vertical lines
            e.Graphics.DrawLine(whitePen, 610, 140, 610, 620);
            e.Graphics.DrawLine(whitePen, 840, 140, 840, 620);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           ChangeImage(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           ChangeImage(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeImage(button3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
           ChangeImage(button5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
           ChangeImage(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
           ChangeImage(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage(button9);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
