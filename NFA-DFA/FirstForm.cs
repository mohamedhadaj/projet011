using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace NFA_DFA
{
    public partial class FirstForm : Form
    {
        #region Global Varibale
        public static bool FileOK = false;
        public static Boolean[, ,] nfaMatris;
        public static int[,] dfaMatris;
        public static bool[,] dfVertexNom;
        public ArrayList AlphabetName = new ArrayList();
        public static string[] Alphabet;
        public TextBox[] tAlphabet;
        public Label[] AlphabetCa; // ","


        public static int NumrVertex = 0;
        public static int NewVertexx = 1;
        



        public ArrayList FinalVertexName = new ArrayList();
        public Label[] FinalVertexAc; 
		
        public Label[] FinalVertexCo; // ","
        public Label[] FinalVertexEn; // "}"
        public NumericUpDown[] UPFinalVerte;
        public static int[] VertexNFA;
        public static ArrayList FinalVertexDFA = new ArrayList();
        //---------------------------------------------------------------------------

        public Label[] VectorBegin; 
        public Label[] VectorDestin; 
        public Label[] VectorAro;  
        public ComboBox[] VectorBeginnn;
        public ComboBox[] bVectorDes;
        public TextBox[] tVectore;
		
        public ArrayList VectorBeginning = new ArrayList();
		
        public ArrayList VectorDestination = new ArrayList();
        public ArrayList VectorArrow = new ArrayList();
        
        // Print Varibale
        public static string[] PrintDFA;

        #endregion

        public FirstForm()
        {
            InitializeComponent();
        }


        bool FirstRun = false;

        private void Solve()
        {
            ClearAllLanda();
            dfaMatris = new int[NewVertexx, Alphabet.Length - 1];
            for (int i = 0; i < NewVertexx; i++) // Cleanup dfaMatris by Number '-1'
                for (int j = 0; j < Alphabet.Length - 1; j++)
                    dfaMatris[i, j] = -1;
            
            dfVertexNom = new bool[NewVertexx, NumrVertex + 1];
            
            dfVertexNom[0, 0] = true; // it mean is q0 name is 0
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            
            for (int i = 0; i < NewVertexx; i++)
                for (int j = 0; j < Alphabet.Length - 1; j++)
                    SearchNewVertex(i, j);

            Trapping(); // Find '-1' and create Trap or NewVertex for Self-Loop 
            DefineFinalVertexDFA(); // Define Final Vertex in DFA Matris2D
            PrintToFile();

            FirstRun = true;
            btnShowGraph.Enabled = true;
        }

        private void DefineFinalVertexDFA()
        {
            FinalVertexDFA.Clear();
            for (int i = 0; i < VertexNFA.Length; i++) // for enum in 'int VertexNFA[]' 
                for (int j = 0; j < NewVertexx; j++) // for Search and enum in dfVertexNom[j,int[strAlphabet]]
                    if (dfVertexNom[j, VertexNFA[i]])
                        if (!FinalVertexDFA.Contains(j))
                            FinalVertexDFA.Add(j);
        }

        private void Trapping()
        {
            int VirtualNum = NewVertexx;
            Boolean Trapping = false;
            for (int i = 0; i < VirtualNum; i++)
                for (int j = 0; j < Alphabet.Length - 1; j++)
                    if (dfaMatris[i, j] == -1)
                        if (Trapping)
                        {
                            dfaMatris[i, j] = NewVertexx - 1;
                        }
                        else
                        {
                            Trapping = true;
                            increaseArrays();
                            dfaMatris[i, j] = NewVertexx - 1;
                            // Create Loop by All Alphabet Words Arrow to Self Vertex
                            for (int L = 0; L < Alphabet.Length - 1; L++)
                                dfaMatris[NewVertexx - 1, L] = NewVertexx - 1;
                        }
        }

		
		
		
		
        private void PrintToFile()
        {
            //Print DFA in File-------------------------------------------------------------------------------------------------
            PrintDFA = new string[(NewVertexx * (Alphabet.Length - 1)) + 4];
            int index2 = 0;
            PrintDFA[index2] = "∑ = {";
            for (int i = 0; i < Alphabet.Length - 2; i++)
                PrintDFA[index2] += Alphabet[i] + ", ";
            PrintDFA[index2] += Alphabet[Alphabet.Length - 2];
            PrintDFA[index2] += "}";

            index2++;
            PrintDFA[index2] = "Vertex Name = {q0";
            for (int i = 1; i < NewVertexx; i++)
                PrintDFA[index2] += ", q" + i.ToString();
            PrintDFA[index2] += "}";

            index2++;
            PrintDFA[index2] = "Final Vertex Name = {";
            int Counter = FinalVertexDFA.Count;
            foreach (int FinalV in FinalVertexDFA)
            {
                if (Counter == 1) //Last Home of FinalVertexDFA
                {
                    PrintDFA[index2] += "q" + FinalV.ToString() + "}";
                    break; // foreach Self be breaken and not necessary this "break;" 
                }
                else
                {
                    PrintDFA[index2] += "q" + FinalV.ToString() + " , ";
                    Counter--;
                }
            }
            // Print Vector Between Two Vertex
            index2++;
            PrintDFA[index2] = "All Vector : ";
            index2++;
            for (int i = 0; i < NewVertexx; i++)
                for (int j = 0; j < Alphabet.Length - 1; j++)
                {
                    PrintDFA[index2] = "                    q" + i.ToString() + "  Arrow(" + Alphabet[j] + ")  q" + (dfaMatris[i, j]).ToString();
                    index2++;
                }
            
        }

        private void FindLanadaInfo(int Q1, int Q2)
        {
            for (int i = 0; i < Alphabet.Length; i++) // for enum AlphabetWord
                for (int j = 0; j < NumrVertex; j++) // for enum Vertex
                    if (nfaMatris[Q2, i, j]) // The Vector is True
                    {
                        if (i == Alphabet.Length - 1) // Q2 has λ vector
                            FindLanadaInfo(Q1, j);
                        else
                            nfaMatris[Q1, i, j] = true;
                    }
        }

		
		
		
        public void ClearAllLanda()
        {
            // Find λ for delete and return vertex's
            for (int i = 0; i <= NumrVertex; i++)
                for (int k = 0; k <= NumrVertex; k++)
                    if (nfaMatris[i, Alphabet.Length - 1, k]) 
                        {
                            nfaMatris[i, Alphabet.Length - 1, k] = false;
                            FindLanadaInfo(i, k);
                        }
        }

        private void increaseArrays()
        {
            int[,] matris3d = new int[NewVertexx, Alphabet.Length - 1];
            bool[,] matris2d = new bool[NewVertexx, NumrVertex + 1];



            for (int i = 0; i < NewVertexx; i++)
                for (int j = 0; j < Alphabet.Length - 1; j++)
                        matris3d[i, j] = dfaMatris[i, j];
            
            // Copy of dfVertexNom to matris2d
            for (int i = 0; i < NewVertexx; i++)
                for (int j = 0; j <= NumrVertex; j++)
                    matris2d[i, j] = dfVertexNom[i, j];
            

            dfaMatris = new int[NewVertexx + 1, Alphabet.Length - 1];
            
            for (int j = 0; j < Alphabet.Length - 1; j++)
                dfaMatris[NewVertexx, j] = -1;
            

            dfVertexNom = new bool[NewVertexx + 1, NumrVertex + 1];

            for (int i = 0; i < NewVertexx; i++)
                for (int j = 0; j < Alphabet.Length - 1; j++)
                        dfaMatris[i, j] = matris3d[i, j];

            for (int i = 0; i < NewVertexx; i++)
                for (int k = 0; k <= NumrVertex; k++)
                    dfVertexNom[i, k] = matris2d[i, k];

            NewVertexx += 1;
        }

        private bool Compare2Array(bool[] Q, int index)
        {
            for (int i = 0; i <= NumrVertex; i++) 
                if (Q[i] != dfVertexNom[index, i]) 
                    return false;
            return true;
        }

        private void SearchNewVertex(int Q, int numArrow)
        {
            bool[] newVertex = new bool[NumrVertex + 1]; // for Save New Vertex

            for (int i = 0; i <= NumrVertex; i++)
                if (dfVertexNom[Q, i]) // 
                    for (int j = 0; j <= NumrVertex; j++)
                        if (nfaMatris[i, numArrow, j]) // enum for Vertex Neme
                            newVertex[j] = true; // Find and Checked
							
            for (int i = 0; i < NewVertexx; i++) 
                if (Compare2Array(newVertex, i)) // If (True) then the newVertex was Exist in matris
                {
                    dfaMatris[Q, numArrow] = i;
                    return;
                }
            increaseArrays();
            for (int i = 0; i <= NumrVertex; i++)
                if (newVertex[i])
                {
                    dfVertexNom[NewVertexx - 1, i] = true; //Add newVertex to Matrix2D List
                }
            dfaMatris[Q, numArrow] = NewVertexx - 1; // Conjunctive newVertex to Array List and OldnewVertex in dfaMatris3D 
        }
        #endregion

        #region Dynamical Form
        private void FirstForm_Load(object sender, EventArgs e)
        {
            btnShowGraph.Enabled = false;

            this.tAlphabet = new TextBox[1];
            this.AlphabetCa = new Label[1];

            this.FinalVertexAc = new Label[1];
            this.UPFinalVerte = new NumericUpDown[1];
            this.FinalVertexEn = new Label[1];
            this.FinalVertexCo = new Label[1];

            this.VectorBegin = new Label[1];
            this.VectorDestin = new Label[1];
            this.VectorAro = new Label[1];
            this.tVectore = new TextBox[1];
            this.VectorBeginnn = new ComboBox[1];
            this.bVectorDes = new ComboBox[1];

            //*****************************************************************************************************
            this.tAlphabet[0] = new TextBox();
            this.tAlphabet[0].Location = new Point(157 + lblTextAlphabet.Location.X, 21 + lblTextAlphabet.Location.Y);
            this.tAlphabet[0].Size = new Size(28, 22);
            this.tAlphabet[0].MaxLength = 3;
            this.tAlphabet[0].TextAlign = HorizontalAlignment.Center;
            this.tAlphabet[0].BackColor = Color.NavajoWhite;
            this.tAlphabet[0].KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.tAlphabet[0].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.Controls.Add(this.tAlphabet[0]);
            this.Controls.Add(this.AlphabetCa[0]);
            lblEndSigma.Location = new Point(lblTextAlphabet.Location.X + 188, lblTextAlphabet.Location.Y + 20);
            //*****************************************************************************************************
















            this.FinalVertexAc[0] = new Label();
            this.FinalVertexAc[0].Font = new Font(FinalVertexAc[0].Font.Name, 12, FontStyle.Bold);
            this.FinalVertexAc[0].Text = "{q";
            this.FinalVertexAc[0].Location = new Point(144 + lblTextFinalVertex.Location.X, 19 + lblTextFinalVertex.Location.Y);
            this.FinalVertexAc[0].Size = new Size(25, 20);
            this.FinalVertexAc[0].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(this.FinalVertexAc[0]);







            this.UPFinalVerte[0] = new NumericUpDown();
            this.UPFinalVerte[0].Location = new Point(165 + lblTextFinalVertex.Location.X, 30 + lblTextFinalVertex.Location.Y);
            this.UPFinalVerte[0].Size = new Size(35, 16);
            this.UPFinalVerte[0].Maximum = 999;
            this.UPFinalVerte[0].BorderStyle = BorderStyle.None;




            this.UPFinalVerte[0].BackColor = Color.Pink;
            this.UPFinalVerte[0].InterceptArrowKeys = false;
            this.UPFinalVerte[0].ThousandsSeparator = true;
            this.UPFinalVerte[0].Maximum = (decimal)(0);
            this.Controls.Add(this.UPFinalVerte[0]);
            this.UPFinalVerte[0].BringToFront();

            //Create FinalVertexEn[0] && Add(FinalVertexCo[0])
            this.FinalVertexEn[0] = new Label();
            this.FinalVertexEn[0].Font = new Font(FinalVertexEn[0].Font.Name, 12, FontStyle.Bold);
            this.FinalVertexEn[0].Text = "}";
            this.FinalVertexEn[0].Location = new Point(197 + lblTextFinalVertex.Location.X, 19 + lblTextFinalVertex.Location.Y);
            this.FinalVertexEn[0].Size = new Size(15, 20);
            this.FinalVertexEn[0].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(this.FinalVertexEn[0]);
            this.Controls.Add(this.FinalVertexCo[0]);
            //---------------------------------------------------------------------------------------------------------
            this.VectorBegin[0] = new Label();
            this.VectorBegin[0].Font = new Font(VectorBegin[0].Font.Name, 12);
            this.VectorBegin[0].Text = "q";
           

		   this.VectorBegin[0].Location = new Point(51 + lblTextVector.Location.X, 16 + lblTextVector.Location.Y);
            this.VectorBegin[0].Size = new Size(15, 24);
            this.VectorBegin[0].TextAlign = ContentAlignment.MiddleCenter;
            this.VectorBegin[0].UseCompatibleTextRendering = true;
            this.toolTip.SetToolTip(this.VectorBegin[0], "Define Beginning Vertex ");
            this.Controls.Add(this.VectorBegin[0]);





            this.VectorDestin[0] = new Label();
            this.VectorDestin[0].Font = new Font(VectorDestin[0].Font.Name, 12);
            this.VectorDestin[0].Text = "q";
            this.VectorDestin[0].Location = new Point(156 + lblTextVector.Location.X, 16 + lblTextVector.Location.Y);
            this.VectorDestin[0].Size = new Size(15, 24);
            this.VectorDestin[0].TextAlign = ContentAlignment.MiddleCenter;
            this.VectorDestin[0].UseCompatibleTextRendering = true;
            this.toolTip.SetToolTip(this.VectorDestin[0], "Define Destination Vertex ");
            this.Controls.Add(this.VectorDestin[0]);

            this.VectorBeginnn[0] = new ComboBox();
            this.VectorBeginnn[0].BackColor = System.Drawing.Color.PaleGreen;
            this.VectorBeginnn[0].Cursor = System.Windows.Forms.Cursors.Hand;
            this.VectorBeginnn[0].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VectorBeginnn[0].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        
		this.VectorBeginnn[0].FormatString = "N0";
            this.VectorBeginnn[0].FormattingEnabled = true;
            this.VectorBeginnn[0].Location = new System.Drawing.Point(69 + lblTextVector.Location.X, 21 + lblTextVector.Location.Y);
            this.VectorBeginnn[0].MaxLength = 3;
            this.VectorBeginnn[0].Size = new System.Drawing.Size(44, 21);
            this.VectorBeginnn[0].Sorted = true;
            this.toolTip.SetToolTip(this.VectorBeginnn[0], "Define Beginning Vertex ");
            this.Controls.Add(VectorBeginnn[0]);
          
            //Create bVectorDes[0]
            this.bVectorDes[0] = new ComboBox();
            this.bVectorDes[0].BackColor = System.Drawing.Color.PaleGreen;
            this.bVectorDes[0].Cursor = System.Windows.Forms.Cursors.Hand;
            this.bVectorDes[0].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bVectorDes[0].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           
		   this.bVectorDes[0].FormatString = "N0";
            this.bVectorDes[0].FormattingEnabled = true;
            this.bVectorDes[0].Location = new System.Drawing.Point(174 + lblTextVector.Location.X, 21 + lblTextVector.Location.Y);
            this.bVectorDes[0].MaxLength = 3;
            this.bVectorDes[0].Size = new System.Drawing.Size(44, 21);
            this.bVectorDes[0].Sorted = true;
            this.toolTip.SetToolTip(this.bVectorDes[0], "Define Destination Vertex ");
            this.Controls.Add(bVectorDes[0]);

            //Create tVectore[0]
            this.tVectore[0] = new TextBox();
            this.tVectore[0].BackColor = System.Drawing.Color.PaleGreen;
            this.tVectore[0].BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tVectore[0].Location = new System.Drawing.Point(119 + lblTextVector.Location.X, 24 + lblTextVector.Location.Y);
            this.tVectore[0].MaxLength = 3;
            this.tVectore[0].Size = new System.Drawing.Size(25, 13);
            this.tVectore[0].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tVectore[0], "Alphabet Word\'s for Vector ");
            this.tVectore[0].KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.tVectore[0].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.Controls.Add(tVectore[0]);
            this.tVectore[0].BringToFront();

            //Create VectorAro[0]
            this.VectorAro[0] = new Label();
            this.VectorAro[0].AutoSize = true;
            this.VectorAro[0].Location = new System.Drawing.Point(114 + lblTextVector.Location.X, 32 + lblTextVector.Location.Y);
            this.VectorAro[0].Size = new System.Drawing.Size(43, 13);
            this.VectorAro[0].Text = "---------->";
            this.toolTip.SetToolTip(this.VectorAro[0], "Alphabet Word\'s for Vector ");
            this.Controls.Add(VectorAro[0]);

            btnDelVector.Location = new Point(lblTextVector.Location.X, lblTextVector.Location.Y + 19);
            btnAddVector.Location = new Point(lblTextVector.Location.X + 224, lblTextVector.Location.Y + 19);
            btnTypeLanda.Location = new Point(lblTextVector.Location.X + 281, lblTextVector.Location.Y + 16);

            FillComboBox(1);
            //=================================================================================================================================
        }

        bool Space = false;
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                Space = true;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Space) e.Handled = true;
            Space = false;
        }

        
		
		
		private void btnAddAlphabet_Click(object sender, EventArgs e)
        {
            AlphabetName.Clear();
            int index = 0;
            foreach (TextBox Checktxt in tAlphabet)
            {
                if (Checktxt.Text == " " || Checktxt.Text == "  " || Checktxt.Text == "   " || Checktxt.Text == string.Empty)
                {
                    MessageBox.Show("TextBox is Empty", "Syntax Error");
                    tAlphabet[index].Select();
                    return;
                }
                else AlphabetName.Add(Checktxt.Text);
                index++;
            }
            CleanupAlphabet();
            CreateAlphabet(index);
        }

        private void CreateAlphabet(int index)
        {
            //Move lblEndSigma to End of Textbox
            lblEndSigma.Location = new Point(157 + lblTextAlphabet.Location.X + ((index * 47) + 31), lblTextAlphabet.Location.Y + 21);

            this.tAlphabet = new TextBox[index + 1];
            this.AlphabetCa = new Label[index];
            //Create tAlphabet[index] 
            for (int i = 0; i <= index; i++)  
            {
                this.tAlphabet[i] = new TextBox();
                this.tAlphabet[i].Location = new Point(157 + lblTextAlphabet.Location.X + (i * 47), lblTextAlphabet.Location.Y + 21);
                this.tAlphabet[i].Size = new Size(28, 22);
                this.tAlphabet[i].MaxLength = 3;
                this.tAlphabet[i].TextAlign = HorizontalAlignment.Center;
                this.tAlphabet[i].KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
                this.tAlphabet[i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
                this.tAlphabet[i].BackColor = Color.NavajoWhite;
                if (i != index) // Because The Final tAlphabet Not Value & is Empty
                    this.tAlphabet[i].Text = (string)AlphabetName[i];
                this.Controls.Add(this.tAlphabet[i]);
            }
            //Create txtAlphabetCama[index - 1] 
            for (int i = 0; i < index; i++)
            {
                this.AlphabetCa[i] = new Label();
                this.AlphabetCa[i].Font = new Font(AlphabetCa[i].Font.Name, 12, FontStyle.Bold);
                this.AlphabetCa[i].Text = ",";
                this.AlphabetCa[i].Location = new Point(tAlphabet[i].Location.X + 30, lblTextAlphabet.Location.Y + 21);
                this.AlphabetCa[i].Size = new Size(14, 20);
                this.Controls.Add(this.AlphabetCa[i]);
            }
            tAlphabet[tAlphabet.Length - 1].Select();
        }

        public void CleanupAlphabet()
        {
            for (int j = 0; j < tAlphabet.Length; j++) 
            {
                this.Controls.Remove(this.tAlphabet[j]);
            }
            for (int j = 0; j < AlphabetCa.Length; j++)
                this.Controls.Remove(this.AlphabetCa[j]);
        }

        private void btnDelAlphabet_Click(object sender, EventArgs e)
        {
            AlphabetName.Clear();
            int index = 0;
            for (int i = 0; i < tAlphabet.Length - 1; i++)
            {
                if (tAlphabet[i].Text == " " || tAlphabet[i].Text == "  " || tAlphabet[i].Text == "   "
                    || tAlphabet[i].Text == string.Empty)
                {
                    MessageBox.Show("TextBox is Empty", "Syntax Error");
                    tAlphabet[i].Select();
                    return;
                }
                else AlphabetName.Add(tAlphabet[i].Text);
                index = i;
            }
            CleanupAlphabet();
            CreateAlphabet(index);
        }

        private void btnAddFinalVertex_Click(object sender, EventArgs e)
        {
            FinalVertexName.Clear();
            int index = 0;
            foreach (NumericUpDown Checktxt in UPFinalVerte)
            {
                FinalVertexName.Add(Checktxt.Value);
                index++;
            }
            CleanupFinalVertex();
            CreateFinalVertex(index);
        }

        private void CleanupFinalVertex()
        {
            for (int j = 0; j < UPFinalVerte.Length; j++)
            {
                this.Controls.Remove(this.UPFinalVerte[j]);
                this.Controls.Remove(this.FinalVertexAc[j]);
                this.Controls.Remove(this.FinalVertexEn[j]);
            }
            for (int j = 0; j < FinalVertexCo.Length; j++)
                this.Controls.Remove(this.FinalVertexCo[j]);
        }

        private void CreateFinalVertex(int index)
        {
            this.FinalVertexAc = new Label[index + 1];
            this.UPFinalVerte = new NumericUpDown[index + 1];
            this.FinalVertexEn = new Label[index + 1];
            this.FinalVertexCo = new Label[index];

            //Create FinalVertexAc[i]
            for (int i = 0; i <= index; i++)
            {
                this.FinalVertexAc[i] = new Label();
                this.FinalVertexAc[i].Font = new Font(FinalVertexAc[i].Font.Name, 12, FontStyle.Bold);
                this.FinalVertexAc[i].Text = "{q";
                this.FinalVertexAc[i].Location = new Point(144 + lblTextFinalVertex.Location.X + (i * 74), lblTextFinalVertex.Location.Y + 19);
                this.FinalVertexAc[i].Size = new Size(25, 20);
                this.FinalVertexAc[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(this.FinalVertexAc[i]);
            }

            //Craete UPFinalVerte[i]
            for (int i = 0; i <= index; i++)
            {
                this.UPFinalVerte[i] = new NumericUpDown();
                this.UPFinalVerte[i].Location = new Point(165 + lblTextFinalVertex.Location.X + (i * 74), lblTextFinalVertex.Location.Y + 30);
                this.UPFinalVerte[i].Size = new Size(35, 16);
                this.UPFinalVerte[i].Maximum = 999;
                this.UPFinalVerte[i].BorderStyle = BorderStyle.None;
                this.UPFinalVerte[i].BackColor = Color.Pink;
                this.UPFinalVerte[i].InterceptArrowKeys = false;
                this.UPFinalVerte[i].ThousandsSeparator = true;
                if (i != index)
                    this.UPFinalVerte[i].Value = (Decimal)FinalVertexName[i];
                this.Controls.Add(this.UPFinalVerte[i]);
                this.UPFinalVerte[i].BringToFront();
                this.UPFinalVerte[i].Maximum = (decimal)(NumrVertex);
            }

            //Create FinalVertexEn[i] 
            for (int i = 0; i <= index; i++)
            {
                this.FinalVertexEn[i] = new Label();
                this.FinalVertexEn[i].Font = new Font(FinalVertexEn[i].Font.Name, 12, FontStyle.Bold);
                this.FinalVertexEn[i].Text = "}";
                this.FinalVertexEn[i].Location = new Point(197 + lblTextFinalVertex.Location.X + (i * 74), lblTextFinalVertex.Location.Y + 19);
                this.FinalVertexEn[i].Size = new Size(15, 20);
                this.FinalVertexEn[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(this.FinalVertexEn[i]); 
            }
            //Create FinalVertexCo[i] 
            for (int i = 0; i < index; i++)
            {
                this.FinalVertexCo[i] = new Label();
                this.FinalVertexCo[i].Font = new Font(FinalVertexCo[i].Font.Name, 12, FontStyle.Bold);
                this.FinalVertexCo[i].Text = ",";
                this.FinalVertexCo[i].Location = new Point(208 + lblTextFinalVertex.Location.X + (i * 74), lblTextFinalVertex.Location.Y + 21);
                this.FinalVertexCo[i].Size = new Size(12, 20);
                this.FinalVertexCo[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(this.FinalVertexCo[i]);
                FinalVertexCo[i].BringToFront();
            }   
        }

        private void btnDelFinalVertex_Click(object sender, EventArgs e)
        {
            FinalVertexName.Clear();
            int index = 0;
            for (int i = 0; i < UPFinalVerte.Length - 1; i++)
            {
                FinalVertexName.Add(UPFinalVerte[i].Value);
                index = i;
            }
            CleanupFinalVertex();
            CreateFinalVertex(index);
        }

        private void btnAddVector_Click(object sender, EventArgs e)
        {
            VectorArrow.Clear();
            VectorBeginning.Clear();
            VectorDestination.Clear();
            int index = 0;
            foreach (TextBox Checktxt in tVectore)
            {
                if (Checktxt.Text == " " || Checktxt.Text == "  " || Checktxt.Text == "   " || Checktxt.Text == string.Empty)
                {
                    MessageBox.Show("TextBox is Empty", "Syntax Error");
                    tVectore[index].Select();
                    return;
                }
                else if (VectorBeginnn[index].SelectedIndex == -1)
                {
                    MessageBox.Show("ComboBox is Empty", "Syntax Error");
                    VectorBeginnn[index].Select();
                    return;
                }
                else if (bVectorDes[index].SelectedIndex == -1)
                {
                    MessageBox.Show("ComboBox is Empty", "Syntax Error");
                    bVectorDes[index].Select();
                    return;
                }
                else
                {
                    VectorArrow.Add(tVectore[index].Text);
                    VectorBeginning.Add(VectorBeginnn[index].SelectedItem.ToString());
                    VectorDestination.Add(bVectorDes[index].SelectedItem.ToString());
                    index++;
                }
            }
            CleanupVector();
            CreateVector(index + 1);
        }

        private void CleanupVector()
        {
            for (int j = 0; j < tVectore.Length; j++)
            {
                this.Controls.Remove(this.tVectore[j]);
                this.Controls.Remove(this.VectorAro[j]);
                this.Controls.Remove(this.VectorBegin[j]);
                this.Controls.Remove(this.VectorDestin[j]);
                this.Controls.Remove(this.VectorBeginnn[j]);
                this.Controls.Remove(this.bVectorDes[j]);
            }
        }

        private void CreateVector(int index)
        {
            //Vector Information Dynamical Varibale
            this.VectorBegin = new Label[index];
            this.VectorDestin = new Label[index];
            this.VectorAro = new Label[index];
            this.tVectore = new TextBox[index];
            this.VectorBeginnn = new ComboBox[index];
            this.bVectorDes = new ComboBox[index];

            //Create VectorBegin[i]
            for (int i = 0; i < index; i++)
            {
                this.VectorBegin[i] = new Label();
                this.VectorBegin[i].Font = new Font(VectorBegin[i].Font.Name, 12);
                this.VectorBegin[i].Text = "q";
                this.VectorBegin[i].Location = new Point(51 + lblTextVector.Location.X, 16 + lblTextVector.Location.Y + (i * 27));
                this.VectorBegin[i].Size = new Size(15, 24);
                this.VectorBegin[i].TextAlign = ContentAlignment.MiddleCenter;
                this.VectorBegin[i].UseCompatibleTextRendering = true;
                this.toolTip.SetToolTip(this.VectorBegin[i], "Define Beginning Vertex ");
                this.Controls.Add(this.VectorBegin[i]);
            }

            //Create VectorDestin[i]
            for (int i = 0; i < index; i++)
            {
                this.VectorDestin[i] = new Label();
                this.VectorDestin[i].Font = new Font(VectorDestin[i].Font.Name, 12);
                this.VectorDestin[i].Text = "q";
                this.VectorDestin[i].Location = new Point(156 + lblTextVector.Location.X, 16 + lblTextVector.Location.Y + (i * 27));
                this.VectorDestin[i].Size = new Size(15, 24);
                this.VectorDestin[i].TextAlign = ContentAlignment.MiddleCenter;
                this.VectorDestin[i].UseCompatibleTextRendering = true;
                this.toolTip.SetToolTip(this.VectorDestin[i], "Define Destination Vertex ");
                this.Controls.Add(this.VectorDestin[i]);
            }

            //Create VectorBeginnn[i]
            for (int i = 0; i < index; i++)
            {
                this.VectorBeginnn[i] = new ComboBox();
                this.VectorBeginnn[i].BackColor = System.Drawing.Color.PaleGreen;
                this.VectorBeginnn[i].Cursor = System.Windows.Forms.Cursors.Hand;
                this.VectorBeginnn[i].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.VectorBeginnn[i].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.VectorBeginnn[i].FormatString = "N0";
                this.VectorBeginnn[i].FormattingEnabled = true;
                this.VectorBeginnn[i].Location = new System.Drawing.Point(69 + lblTextVector.Location.X, 21 + lblTextVector.Location.Y + (i * 27));
                this.VectorBeginnn[i].MaxLength = 3;
                this.VectorBeginnn[i].Size = new System.Drawing.Size(44, 21);
                this.toolTip.SetToolTip(this.VectorBeginnn[i], "Define Beginning Vertex ");
                this.Controls.Add(VectorBeginnn[i]);
            }

            //Create bVectorDes[i]
            for (int i = 0; i < index; i++)
            {
                this.bVectorDes[i] = new ComboBox();
                this.bVectorDes[i].BackColor = System.Drawing.Color.PaleGreen;
                this.bVectorDes[i].Cursor = System.Windows.Forms.Cursors.Hand;
                this.bVectorDes[i].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.bVectorDes[i].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.bVectorDes[i].FormatString = "N0";
                this.bVectorDes[i].FormattingEnabled = true;
                this.bVectorDes[i].Location = new System.Drawing.Point(174 + lblTextVector.Location.X, 21 + lblTextVector.Location.Y + (i * 27));
                this.bVectorDes[i].MaxLength = 3;
                this.bVectorDes[i].Size = new System.Drawing.Size(44, 21);
                this.toolTip.SetToolTip(this.bVectorDes[i], "Define Destination Vertex ");
                this.Controls.Add(bVectorDes[i]);
                
            }

            //Create tVectore[i]
            for (int i = 0; i < index; i++)
            {
                this.tVectore[i] = new TextBox();
                this.tVectore[i].BackColor = System.Drawing.Color.PaleGreen;
                this.tVectore[i].BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.tVectore[i].Location = new System.Drawing.Point(119 + lblTextVector.Location.X, 24 + lblTextVector.Location.Y + (i * 27));
                this.tVectore[i].MaxLength = 3;
                this.tVectore[i].Size = new System.Drawing.Size(25, 13);
                this.tVectore[i].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.toolTip.SetToolTip(this.tVectore[i], "Alphabet Word\'s for Vector ");
                this.tVectore[i].KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
                this.tVectore[i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
                this.Controls.Add(tVectore[i]);
                this.tVectore[i].BringToFront();                    
            }

            //Create VectorAro[i]
            for (int i = 0; i < index; i++)
            {
                this.VectorAro[i] = new Label();
                this.VectorAro[i].AutoSize = true;
                this.VectorAro[i].Location = new System.Drawing.Point(114 + lblTextVector.Location.X, 32 + lblTextVector.Location.Y + (i * 27));
                this.VectorAro[i].Size = new System.Drawing.Size(43, 13);
                this.VectorAro[i].Text = "---------->";
                this.toolTip.SetToolTip(this.VectorAro[i], "Alphabet Word\'s for Vector ");
                this.Controls.Add(VectorAro[i]);
            }
            btnAddVector.Location = new Point(224 + lblTextVector.Location.X, bVectorDes[bVectorDes.Length - 1].Location.Y - 2);
            btnDelVector.Location = new Point(lblTextVector.Location.X, bVectorDes[bVectorDes.Length - 1].Location.Y - 2);
            btnTypeLanda.Location = new Point(lblTextVector.Location.X + 281, btnAddVector.Location.Y - 3);
            //Add AutoCompleteCustomSource & ComboBox.item Information
            FillComboBox(index);  
        }

        public void FillComboBox(int index) // ComboBox.item Information
        {
            // First Remove All Information
            for (int i = 0; i < index; i++)
            {
                VectorBeginnn[i].Items.Clear();
                bVectorDes[i].Items.Clear();
            }
            // Second Adding All Information to ItemList
            for (int j = 0; j <= NumrVertex; j++)
            {
                for (int k = 0; k < index; k++)
                {
                    VectorBeginnn[k].Items.Add(j);
                    bVectorDes[k].Items.Add(j);
                }
            }
            if (FileOK) // Fill For as File
            {
                for (int l = 0; l < VectorBeginnn.Length; l++)
                {
                    VectorBeginnn[l].Text = (string)VectorBeginning[l];
                    bVectorDes[l].Text = (string)VectorDestination[l];
                    this.tVectore[l].Text = (string)VectorArrow[l];
                }
            }
            else
            {
                // Back ComboBox Text
                for (int l = 0; l < VectorBeginnn.Length - 1; l++)
                {
                    VectorBeginnn[l].Text = (string)VectorBeginning[l];
                    bVectorDes[l].Text = (string)VectorDestination[l];
                    this.tVectore[l].Text = (string)VectorArrow[l];
                }
            }
        }

        private void msktxtNumrVertex_Leave(object sender, EventArgs e)
        {
            if (msktxtNumrVertex.Text != string.Empty)
            {
                NumrVertex = Convert.ToInt16(msktxtNumrVertex.Text) - 1;
                FillComboBox(bVectorDes.Length);
                for (int i = 0; i < UPFinalVerte.Length; i++)
                    this.UPFinalVerte[i].Maximum = (decimal)(NumrVertex);
            }
        }

        private void btnDelVector_Click(object sender, EventArgs e)
        {
            VectorArrow.Clear();
            VectorBeginning.Clear();
            VectorDestination.Clear();
            int index = 0;
            for (int i = 0; i < bVectorDes.Length - 1; i++)
            {
                if (tVectore[i].Text == " " || tVectore[i].Text == "  " || tVectore[i].Text == "   "
                    || tVectore[i].Text == string.Empty)
                {
                    MessageBox.Show("TextBox is Empty", "Syntax Error");
                    tVectore[i].Select();
                    return;
                }
                else if (VectorBeginnn[i].SelectedIndex == -1)
                {
                    MessageBox.Show("ComboBox is Empty", "Syntax Error");
                    VectorBeginnn[i].Select();
                    return;
                }
                else if (bVectorDes[i].SelectedIndex == -1)
                {
                    MessageBox.Show("ComboBox is Empty", "Syntax Error");
                    bVectorDes[i].Select();
                    return;
                }
                else
                {
                    VectorArrow.Add(tVectore[index].Text);
                    VectorBeginning.Add(VectorBeginnn[index].SelectedItem.ToString());
                    VectorDestination.Add(bVectorDes[index].SelectedItem.ToString());
                    index = i;
                }
            }
            CleanupVector();
            CreateVector(index + 1);
        }

        private void btnTypeLanda_Click(object sender, EventArgs e)
        {
            tVectore[tVectore.Length - 1].Text = "λ";
        }

        #endregion

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (!FirstRun)
            {
                //
                // Definition Varibale
                //
                Alphabet = new string[tAlphabet.Length + 1];
                Alphabet[Alphabet.Length - 1] = "λ";
                VertexNFA = new int[UPFinalVerte.Length];
                int[] VectorBeginningINT = new int[tVectore.Length];
                int[] VectorDestinationINT = new int[tVectore.Length];
                string[] strAlphabetInterfaceQ = new string[tVectore.Length];
                //
                //check Alphabet Words trust ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                for (int i = 0; i < tAlphabet.Length; i++)
                {
                    if (tAlphabet[i].Text == " " || tAlphabet[i].Text == "  "
                        || tAlphabet[i].Text == "   " || tAlphabet[i].Text == string.Empty) // Check Empty
                    {
                        MessageBox.Show("TextBox is Empty", "Syntax Error");
                        tAlphabet[i].Select();
                        return;
                    }
                    for (int j = i + 1; j < tAlphabet.Length; j++) // Check Repeat
                        if (tAlphabet[i].Text == tAlphabet[j].Text)
                        {
                            MessageBox.Show("Alphabet Word Repeated", "Synatax Error");
                            tAlphabet[j].Select();
                            return;
                        }
                    Alphabet[i] = tAlphabet[i].Text.Trim();
                }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                //check Number of Vertex trust %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                if (msktxtNumrVertex.Text == " " || msktxtNumrVertex.Text == "  "
                    || msktxtNumrVertex.Text == "   " || msktxtNumrVertex.Text == string.Empty)
                {
                    MessageBox.Show("TextBox Number Of Vertex is Empty", "Syntax Error");
                    msktxtNumrVertex.Select();
                    return;
                }
                else
                    if (int.TryParse(msktxtNumrVertex.Text, out NumrVertex))
                    {
                        if (NumrVertex < 0)
                        {
                            MessageBox.Show("Number Of Vertex Does not Negative", "Syntax Error");
                            msktxtNumrVertex.Select();
                            msktxtNumrVertex.SelectAll();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Number Of Vertex Just be Number", "Syntax Error");
                        msktxtNumrVertex.Select();
                        msktxtNumrVertex.SelectAll();
                        return;
                    }
                //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                // Check Final Vertex number trust &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                for (int V = 0; V < UPFinalVerte.Length; V++)
                {
                    for (int S = V + 1; S < UPFinalVerte.Length; S++)
                        if (UPFinalVerte[V].Value == UPFinalVerte[S].Value)
                        {
                            MessageBox.Show("Number Of Final Vertex Repeated", "Syntax Error");
                            UPFinalVerte[S].Select();
                            return;
                        }
                    VertexNFA[V] = (int)UPFinalVerte[V].Value;
                }
                //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                // Check Vector Information trust ############################################################################
                for (int m = 0; m < tVectore.Length; m++)
                {
                    if (tVectore[m].Text == " " || tVectore[m].Text == "  " || tVectore[m].Text == "   " || tVectore[m].Text == "")
                    {
                        MessageBox.Show("TextBox is Empty", "Syntax Error");
                        tVectore[m].Select();
                        return;
                    }
                    else if (VectorBeginnn[m].SelectedIndex == -1)
                    {
                        MessageBox.Show("ComboBox is Empty", "Syntax Error");
                        VectorBeginnn[m].Select();
                        return;
                    }
                    else if (bVectorDes[m].SelectedIndex == -1)
                    {
                        MessageBox.Show("ComboBox is Empty", "Syntax Error");
                        bVectorDes[m].Select();
                        return;
                    }
                    bool FindWord = false;
                    for (int d = 0; d < Alphabet.Length; d++)
                    {
                        if (tVectore[m].Text == Alphabet[d])
                        {
                            FindWord = true;
                            break;
                        }
                    }
                    if (!FindWord)
                    {
                        MessageBox.Show("Vector Arrow Text is not a Alphabet Word's", "Syntax Error");
                        tVectore[m].Select();
                        tVectore[m].SelectAll();
                        return;
                    }
                    VectorDestinationINT[m] = Convert.ToInt16(bVectorDes[m].Text);
                    VectorBeginningINT[m] = Convert.ToInt16(VectorBeginnn[m].Text);
                    strAlphabetInterfaceQ[m] = tVectore[m].Text;
                }
                //############################################################################################################
                nfaMatris = new Boolean[NumrVertex + 1, Alphabet.Length, NumrVertex + 1];
                // Clean All nfaMatris by False
                for (int i = 0; i <= NumrVertex; i++)
                    for (int j = 0; j < Alphabet.Length; j++)
                        for (int k = 0; k <= NumrVertex; k++)
                            nfaMatris[i, j, k] = false;
                // add all nfa information to nfaMatris
                for (int i = 0; i < strAlphabetInterfaceQ.Length; i++)
                    for (int j = 0; j < Alphabet.Length; j++)
                        if (strAlphabetInterfaceQ[i] == Alphabet[j])
                            nfaMatris[VectorBeginningINT[i], j, VectorDestinationINT[i]] = true;

                // All Information is Checked and now Solve this Question
                Solve();
            }
            else
            {
                ShownAnswer Answer = new ShownAnswer();
                Answer.ShowDialog();
            }
        }

        private  void btnCleanUp_Click(object sender, EventArgs e)
        {
            btnAddVector.Enabled = true;
            btnDelVector.Enabled = true;
            FileOK = false;
            FirstRun = false;
            msktxtNumrVertex.Text = string.Empty;
            CleanupAlphabet();
            CleanupFinalVertex();
            CleanupVector();
            AlphabetName.Clear();
            VectorArrow.Clear();
            VectorBeginning.Clear();
            VectorDestination.Clear();
            FinalVertexName.Clear();
            FirstForm_Load(sender, e);
            NumrVertex = 0;
            NewVertexx = 1;
            FinalVertexDFA.Clear();
            btnShowGraph.Enabled = false;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }

       
        private void btnShowGraph_Click(object sender, EventArgs e)
        {
            DrawGraph DFA = new DrawGraph();
            DFA.ShowDialog();
        }

        

        private void groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }
    }
}
