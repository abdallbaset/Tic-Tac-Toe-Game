using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
   


    public partial class Tic_Tac_Toe_Game : Form
    {
        enum enPlayer { X, O };
        struct stGameState
        {
           public  enPlayer PlayerTurn;
           public  byte NumberOfCellsSelected  ;
           public  short scoreX ;
           public  short scoreO ;

        };

        stGameState GameState;

        public Tic_Tac_Toe_Game()
        {
            InitializeComponent();
        }

      
        void DisableAllCellsOfEmpty()
        {

            if (lbl_1.Text == "")
                lbl_1.Enabled = false;

            if (lbl_2.Text == "")
                lbl_2.Enabled = false;

            if (lbl_3.Text == "")
                lbl_3.Enabled = false;

            if (lbl_4.Text == "")
                lbl_4.Enabled = false;

            if (lbl_5.Text == "")
                lbl_5.Enabled = false;

            if (lbl_6.Text == "")
                lbl_6.Enabled = false;

            if (lbl_7.Text == "")
                lbl_7.Enabled = false;

            if (lbl_8.Text == "")
                lbl_8.Enabled = false;

            if (lbl_9.Text == "")
                lbl_9.Enabled = false;

        }
        void RestartLable(Label label)
        {
            label.Enabled = true;
            label.Text = "";
            label.BackColor = Color.FromArgb(27, 35, 50); 
        }
        void RestartGame()
        {
            RestartLable(lbl_1);
            RestartLable(lbl_2);
            RestartLable(lbl_3);
            RestartLable(lbl_4);
            RestartLable(lbl_5);
            RestartLable(lbl_6);
            RestartLable(lbl_7);
            RestartLable(lbl_8);
            RestartLable(lbl_9);
            lbl_TurnValue.Text = "X";
            GameState.PlayerTurn = enPlayer.X;
            lbl_SelectPlayerTurn.Text = "Player X's Turn";
            lbl_MessageGameOver.Visible = false;
            GameState.NumberOfCellsSelected = 0;
            lbl_TurnValue.ForeColor = Color.FromArgb(239, 68, 68);


        }
        void UpdatePlayerTurn()
        {
            if(GameState.PlayerTurn == enPlayer.X)
            {
                GameState.PlayerTurn = enPlayer.O;
                lbl_TurnValue.ForeColor = Color.FromArgb(59, 130, 246);
                lbl_TurnValue.Text = GameState.PlayerTurn.ToString();
                lbl_SelectPlayerTurn.Text = "PlayerO Trun";
            }
            else
            {
                GameState.PlayerTurn = enPlayer.X;
                lbl_TurnValue.ForeColor = Color.FromArgb(239, 68, 68);
                lbl_TurnValue.Text = GameState.PlayerTurn.ToString();
                lbl_SelectPlayerTurn.Text = "PlayerX Trun";
            }
        }

        void UpdateScoreboard(string PlayerWinner)
        {
           
            if (PlayerWinner == enPlayer.X.ToString())
            {
                GameState.scoreX++;
                lbl_NumberOfWinX.Text = GameState.scoreX.ToString();
            }
            else
            {
                GameState.scoreO++;
                lbl_NumberOfWinO.Text = GameState.scoreO.ToString();
            }
        }


        void EndGame(Label Lbl1, Label Lbl2, Label Lbl3)
        {
            lbl_TurnValue.Text = "";
            lbl_MessageGameOver.Visible = true;
            Lbl1.BackColor = Color.FromArgb(255, 34, 197, 94);
            Lbl2.BackColor = Color.FromArgb(255, 34, 197, 94);
            Lbl3.BackColor = Color.FromArgb(255, 34, 197, 94);
            UpdateScoreboard(Lbl1.Text);
            DisableAllCellsOfEmpty();
        }
    bool CheckValues(Label Lbl1, Label Lbl2 ,Label Lbl3)
        {
            if (Lbl1.Text == "X" && Lbl2.Text == "X" && Lbl3.Text == "X")
            {
                EndGame(Lbl1, Lbl2, Lbl3);
                lbl_SelectPlayerTurn.Text = "Player X's Winner";
                return true;
            }

            if (Lbl1.Text == "O" && Lbl2.Text == "O" && Lbl3.Text == "O")
            {
                EndGame(Lbl1, Lbl2, Lbl3);
                lbl_SelectPlayerTurn.Text = "Player O's Winner";
                return true;
            }

            return false;  
        }
       void CheckForWinner()
        {
            if (CheckValues(lbl_1, lbl_2,lbl_3))
            {
                return;
            }

            if (CheckValues(lbl_4, lbl_5, lbl_6))
            {
                return;
            }

            if (CheckValues(lbl_7, lbl_8, lbl_9))
            {
                return;
            }

            if (CheckValues(lbl_1, lbl_4, lbl_7))
            {
                return;
            }

            if (CheckValues(lbl_2, lbl_5, lbl_8))
            {
                return;
            }

            if (CheckValues(lbl_3, lbl_6, lbl_9))
            {
                return;
            }

            if (CheckValues(lbl_1, lbl_5, lbl_9))
            {
                return;
            }

            if (CheckValues(lbl_3, lbl_5, lbl_7))
            {
                return;
            }
            else
            {
                if (GameState.NumberOfCellsSelected == 9)
                {
                    lbl_TurnValue.Text = "";
                    lbl_MessageGameOver.Visible = true;
                    lbl_SelectPlayerTurn.Text = "Draw";
                }
        
            }
        }
        void SetMarkAndSwitchTurn(object sender)
        {
           
            Label clickedLabel = sender as Label;
            if (clickedLabel != null && string.IsNullOrEmpty(clickedLabel.Text))
            {
                switch (GameState.PlayerTurn)
                {
                    case enPlayer.X:
                        {
                            clickedLabel.ForeColor = Color.FromArgb(239, 68, 68);
                  
                            clickedLabel.Text = "X";
                            GameState.NumberOfCellsSelected++;
                        }break;

                    case enPlayer.O:
                        {
                            clickedLabel.ForeColor = Color.FromArgb(59, 130, 246);
                            clickedLabel.Text = "O" ;
                            GameState.NumberOfCellsSelected++;
                        }
                        break;

                    default:
                        break;
                }

                UpdatePlayerTurn();
                CheckForWinner();
            }
            else
            {
                MessageBox.Show("Warning Choise", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void lbl_Click(object sender, EventArgs e)
        {
            SetMarkAndSwitchTurn(sender);
        }
       
        private void btn_Restartgame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            GameState.PlayerTurn = enPlayer.X;
            GameState.scoreO = 0;
            GameState.scoreX = 0;
            GameState.NumberOfCellsSelected = 0;
            lbl_TurnValue.Text = GameState.PlayerTurn.ToString();
            lbl_NumberOfWinO.Text = GameState.scoreO.ToString();
            lbl_NumberOfWinX.Text = GameState.scoreX.ToString();
            lbl_SelectPlayerTurn.Text = "Player X's Turn";
            lbl_MessageGameOver.Text = "Game Over";
            lbl_MessageGameOver.Visible = false;
        }
    }
    
}
