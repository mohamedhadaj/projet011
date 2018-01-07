namespace NFA_DFA
{
    partial class FirstForm
    {
       
        private System.ComponentModel.IContainer components = null;

         protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// 
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
			
			
			
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstForm));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddAlphabet = new System.Windows.Forms.Button();
            this.btnDelAlphabet = new System.Windows.Forms.Button();
            
			
			
			
			
			
			
			
			
			
            this.btnTypeLanda = new System.Windows.Forms.Button();
            this.btnShowGraph = new System.Windows.Forms.Button();
            this.btnCleanUp = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
			this.msktxtNumrVertex = new System.Windows.Forms.MaskedTextBox();
            this.btnAddFinalVertex = new System.Windows.Forms.Button();
            this.btnDelVector = new System.Windows.Forms.Button();
            this.btnDelFinalVertex = new System.Windows.Forms.Button();
            this.btnAddVector = new System.Windows.Forms.Button();
			
			
			
			
			
			
			
			
			
			
			
            this.lblSigma = new System.Windows.Forms.Label();
            this.lblTextAlphabet = new System.Windows.Forms.Label();
            this.lblEndSigma = new System.Windows.Forms.Label();
            this.lblTextNumrVertex = new System.Windows.Forms.Label();
            this.lblTextFinalVertex = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTextVector = new System.Windows.Forms.Label();
            
			this.openFileDialogImport = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            this.btnAddAlphabet.AutoEllipsis = true;
            this.btnAddAlphabet.BackColor = System.Drawing.Color.Silver;
            this.btnAddAlphabet.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnAddAlphabet, "btnAddAlphabet");
            this.btnAddAlphabet.Name = "btnAddAlphabet";
            this.toolTip.SetToolTip(this.btnAddAlphabet, resources.GetString("btnAddAlphabet.ToolTip"));
            this.btnAddAlphabet.UseVisualStyleBackColor = false;
            this.btnAddAlphabet.Click += new System.EventHandler(this.btnAddAlphabet_Click);

            // 
            this.btnDelAlphabet.AutoEllipsis = true;
            this.btnDelAlphabet.BackColor = System.Drawing.Color.Silver;
            this.btnDelAlphabet.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDelAlphabet, "btnDelAlphabet");
            this.btnDelAlphabet.Name = "btnDelAlphabet";
            this.toolTip.SetToolTip(this.btnDelAlphabet, resources.GetString("btnDelAlphabet.ToolTip"));
            this.btnDelAlphabet.UseVisualStyleBackColor = false;
            this.btnDelAlphabet.Click += new System.EventHandler(this.btnDelAlphabet_Click);
            // 
            // 
            this.msktxtNumrVertex.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.msktxtNumrVertex.BeepOnError = true;
            this.msktxtNumrVertex.Culture = new System.Globalization.CultureInfo("");
            this.msktxtNumrVertex.HidePromptOnLeave = true;
            resources.ApplyResources(this.msktxtNumrVertex, "msktxtNumrVertex");
            this.msktxtNumrVertex.Name = "msktxtNumrVertex";
            this.msktxtNumrVertex.RejectInputOnFirstFailure = true;
            this.toolTip.SetToolTip(this.msktxtNumrVertex, resources.GetString("msktxtNumrVertex.ToolTip"));
            this.msktxtNumrVertex.Leave += new System.EventHandler(this.msktxtNumrVertex_Leave);
            //             // 
            this.btnAddFinalVertex.AutoEllipsis = true;
            this.btnAddFinalVertex.BackColor = System.Drawing.Color.Silver;
            this.btnAddFinalVertex.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnAddFinalVertex, "btnAddFinalVertex");
            this.btnAddFinalVertex.Name = "btnAddFinalVertex";
            this.toolTip.SetToolTip(this.btnAddFinalVertex, resources.GetString("btnAddFinalVertex.ToolTip"));
            this.btnAddFinalVertex.UseVisualStyleBackColor = false;
            this.btnAddFinalVertex.Click += new System.EventHandler(this.btnAddFinalVertex_Click);
            //             // 
            this.btnDelVector.AutoEllipsis = true;
            this.btnDelVector.BackColor = System.Drawing.Color.Silver;
            this.btnDelVector.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDelVector, "btnDelVector");
            this.btnDelVector.Name = "btnDelVector";
            this.toolTip.SetToolTip(this.btnDelVector, resources.GetString("btnDelVector.ToolTip"));
            this.btnDelVector.UseVisualStyleBackColor = false;
            this.btnDelVector.Click += new System.EventHandler(this.btnDelVector_Click);
            //              
            this.btnDelFinalVertex.AutoEllipsis = true;
            this.btnDelFinalVertex.BackColor = System.Drawing.Color.Silver;
            this.btnDelFinalVertex.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDelFinalVertex, "btnDelFinalVertex");
            this.btnDelFinalVertex.Name = "btnDelFinalVertex";
            this.toolTip.SetToolTip(this.btnDelFinalVertex, resources.GetString("btnDelFinalVertex.ToolTip"));
            this.btnDelFinalVertex.UseVisualStyleBackColor = false;
            this.btnDelFinalVertex.Click += new System.EventHandler(this.btnDelFinalVertex_Click);
            // 
            // 
            this.btnAddVector.AutoEllipsis = true;
            this.btnAddVector.BackColor = System.Drawing.Color.Silver;
            this.btnAddVector.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnAddVector, "btnAddVector");
            this.btnAddVector.Name = "btnAddVector";
            this.toolTip.SetToolTip(this.btnAddVector, resources.GetString("btnAddVector.ToolTip"));
            this.btnAddVector.UseVisualStyleBackColor = false;
            this.btnAddVector.Click += new System.EventHandler(this.btnAddVector_Click);
            // 
            // 
            this.btnTypeLanda.BackColor = System.Drawing.SystemColors.Control;
            this.btnTypeLanda.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnTypeLanda, "btnTypeLanda");
            this.btnTypeLanda.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTypeLanda.Name = "btnTypeLanda";
            this.toolTip.SetToolTip(this.btnTypeLanda, resources.GetString("btnTypeLanda.ToolTip"));
            this.btnTypeLanda.UseVisualStyleBackColor = false;
            this.btnTypeLanda.Click += new System.EventHandler(this.btnTypeLanda_Click);
            // 
            // 
            this.btnShowGraph.AutoEllipsis = true;
            this.btnShowGraph.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnShowGraph.BackgroundImage = global::NFA_DFA.Properties.Resources.graph;
            resources.ApplyResources(this.btnShowGraph, "btnShowGraph");
            this.btnShowGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowGraph.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnShowGraph.Name = "btnShowGraph";
            this.toolTip.SetToolTip(this.btnShowGraph, resources.GetString("btnShowGraph.ToolTip"));
            this.btnShowGraph.UseCompatibleTextRendering = true;
            this.btnShowGraph.UseVisualStyleBackColor = false;
            this.btnShowGraph.Click += new System.EventHandler(this.btnShowGraph_Click);
            // 
            // 
            this.btnCleanUp.AutoEllipsis = true;
            this.btnCleanUp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCleanUp.BackgroundImage = global::NFA_DFA.Properties.Resources.CleanUp;
            resources.ApplyResources(this.btnCleanUp, "btnCleanUp");
            this.btnCleanUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCleanUp.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCleanUp.Name = "btnCleanUp";
            this.toolTip.SetToolTip(this.btnCleanUp, resources.GetString("btnCleanUp.ToolTip"));
            this.btnCleanUp.UseCompatibleTextRendering = true;
            this.btnCleanUp.UseVisualStyleBackColor = false;
            this.btnCleanUp.Click += new System.EventHandler(this.btnCleanUp_Click);
            // 
            // 
            this.btnSolve.AutoEllipsis = true;
            this.btnSolve.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSolve.BackgroundImage = global::NFA_DFA.Properties.Resources.Solve;
            resources.ApplyResources(this.btnSolve, "btnSolve");
            this.btnSolve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSolve.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSolve.Name = "btnSolve";
            this.toolTip.SetToolTip(this.btnSolve, resources.GetString("btnSolve.ToolTip"));
            this.btnSolve.UseCompatibleTextRendering = true;
            this.btnSolve.UseVisualStyleBackColor = false;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // 
            resources.ApplyResources(this.lblSigma, "lblSigma");
            this.lblSigma.Name = "lblSigma";
            // 
            // 
            // 
            resources.ApplyResources(this.lblTextAlphabet, "lblTextAlphabet");
            this.lblTextAlphabet.BackColor = System.Drawing.Color.Lime;
            this.lblTextAlphabet.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTextAlphabet.Name = "lblTextAlphabet";
            // 
            // 
            resources.ApplyResources(this.lblEndSigma, "lblEndSigma");
            this.lblEndSigma.Name = "lblEndSigma";
            // 
            // 
            resources.ApplyResources(this.lblTextNumrVertex, "lblTextNumrVertex");
            this.lblTextNumrVertex.BackColor = System.Drawing.Color.Lime;
            this.lblTextNumrVertex.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTextNumrVertex.Name = "lblTextNumrVertex";
            // 
            // 
            resources.ApplyResources(this.lblTextFinalVertex, "lblTextFinalVertex");
            this.lblTextFinalVertex.BackColor = System.Drawing.Color.Lime;
            this.lblTextFinalVertex.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTextFinalVertex.Name = "lblTextFinalVertex";
            // 
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // 
            // 
            resources.ApplyResources(this.lblTextVector, "lblTextVector");
            this.lblTextVector.BackColor = System.Drawing.Color.Lime;
            this.lblTextVector.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTextVector.Name = "lblTextVector";
            // 
            
            // 
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "LogoNFA-DFA.png");
            // 
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTypeLanda);
            this.Controls.Add(this.btnAddVector);
            
			
			
			
			
			
			
			
			
			
			this.Controls.Add(this.btnDelVector);
            this.Controls.Add(this.btnDelFinalVertex);
            this.Controls.Add(this.btnAddFinalVertex);
            this.Controls.Add(this.msktxtNumrVertex);
            this.Controls.Add(this.lblEndSigma);
            this.Controls.Add(this.lblTextVector);
            this.Controls.Add(this.lblTextFinalVertex);
            this.Controls.Add(this.lblTextNumrVertex);
            this.Controls.Add(this.lblTextAlphabet);
           





















		   this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSigma);
            this.Controls.Add(this.btnDelAlphabet);
            this.Controls.Add(this.btnAddAlphabet);
            this.Controls.Add(this.btnShowGraph);
            this.Controls.Add(this.btnCleanUp);
            this.Controls.Add(this.btnSolve);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "FirstForm";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Load += new System.EventHandler(this.FirstForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnCleanUp;
        private System.Windows.Forms.Button btnShowGraph;
       





	   private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnAddAlphabet;
        private System.Windows.Forms.Button btnDelAlphabet;
        private System.Windows.Forms.Label lblSigma;
      








	  private System.Windows.Forms.Label lblTextAlphabet;
        private System.Windows.Forms.Label lblEndSigma;
        private System.Windows.Forms.Label lblTextNumrVertex;
       
	   private System.Windows.Forms.MaskedTextBox msktxtNumrVertex;
        private System.Windows.Forms.Label lblTextFinalVertex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddFinalVertex;
       




	   private System.Windows.Forms.Button btnDelFinalVertex;
        private System.Windows.Forms.Label lblTextVector;
        private System.Windows.Forms.Button btnDelVector;
        private System.Windows.Forms.Button btnAddVector;
        private System.Windows.Forms.Button btnTypeLanda;
        private System.Windows.Forms.OpenFileDialog openFileDialogImport;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
    }
}

