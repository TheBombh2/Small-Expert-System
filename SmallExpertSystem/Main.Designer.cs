

namespace SmallExpertSystem
{
	partial class Main
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			premisesLB = new ListBox();
			addPremiseBTN = new Button();
			newPremiseTB = new TextBox();
			finalArgumentTB = new TextBox();
			proveBTN = new Button();
			resultLBL = new Label();
			label2 = new Label();
			removePremiseBTN = new Button();
			label3 = new Label();
			label4 = new Label();
			accuracyNUD = new NumericUpDown();
			label1 = new Label();
			accuracyTT = new ToolTip(components);
			methodsUsedLB = new ListBox();
			resultsGB = new GroupBox();
			numberOfAttempsLBL = new Label();
			rulesAppliedLBL = new Label();
			((System.ComponentModel.ISupportInitialize)accuracyNUD).BeginInit();
			resultsGB.SuspendLayout();
			SuspendLayout();
			// 
			// premisesLB
			// 
			premisesLB.Font = new Font("Segoe UI", 10F);
			premisesLB.FormattingEnabled = true;
			premisesLB.ItemHeight = 17;
			premisesLB.Location = new Point(12, 33);
			premisesLB.Name = "premisesLB";
			premisesLB.Size = new Size(362, 361);
			premisesLB.TabIndex = 0;
			// 
			// addPremiseBTN
			// 
			addPremiseBTN.Location = new Point(495, 90);
			addPremiseBTN.Name = "addPremiseBTN";
			addPremiseBTN.Size = new Size(165, 23);
			addPremiseBTN.TabIndex = 1;
			addPremiseBTN.Text = "Add Premise";
			addPremiseBTN.UseVisualStyleBackColor = true;
			addPremiseBTN.Click += addPremiseBTN_Click;
			// 
			// newPremiseTB
			// 
			newPremiseTB.Location = new Point(408, 61);
			newPremiseTB.Name = "newPremiseTB";
			newPremiseTB.Size = new Size(361, 23);
			newPremiseTB.TabIndex = 2;
			// 
			// finalArgumentTB
			// 
			finalArgumentTB.Location = new Point(408, 159);
			finalArgumentTB.Name = "finalArgumentTB";
			finalArgumentTB.Size = new Size(361, 23);
			finalArgumentTB.TabIndex = 3;
			// 
			// proveBTN
			// 
			proveBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			proveBTN.Location = new Point(604, 188);
			proveBTN.Name = "proveBTN";
			proveBTN.Size = new Size(165, 23);
			proveBTN.TabIndex = 4;
			proveBTN.Text = "Prove";
			proveBTN.UseVisualStyleBackColor = true;
			proveBTN.Click += proveBTN_Click;
			// 
			// resultLBL
			// 
			resultLBL.AutoSize = true;
			resultLBL.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
			resultLBL.Location = new Point(6, 43);
			resultLBL.Name = "resultLBL";
			resultLBL.Size = new Size(200, 51);
			resultLBL.TabIndex = 5;
			resultLBL.Text = "Not Valid!";
			resultLBL.Visible = false;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 14F);
			label2.Location = new Point(117, 5);
			label2.Name = "label2";
			label2.Size = new Size(120, 25);
			label2.TabIndex = 6;
			label2.Text = "Premises List";
			// 
			// removePremiseBTN
			// 
			removePremiseBTN.Location = new Point(130, 398);
			removePremiseBTN.Name = "removePremiseBTN";
			removePremiseBTN.Size = new Size(107, 44);
			removePremiseBTN.TabIndex = 7;
			removePremiseBTN.Text = "Clear Premises";
			removePremiseBTN.UseVisualStyleBackColor = true;
			removePremiseBTN.Click += removePremiseBTN_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 14F);
			label3.Location = new Point(510, 33);
			label3.Name = "label3";
			label3.Size = new Size(122, 25);
			label3.TabIndex = 8;
			label3.Text = "New Premise";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 14F);
			label4.Location = new Point(510, 131);
			label4.Name = "label4";
			label4.Size = new Size(141, 25);
			label4.TabIndex = 9;
			label4.Text = "Final Argument";
			// 
			// accuracyNUD
			// 
			accuracyNUD.Location = new Point(495, 188);
			accuracyNUD.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			accuracyNUD.Name = "accuracyNUD";
			accuracyNUD.Size = new Size(65, 23);
			accuracyNUD.TabIndex = 10;
			accuracyNUD.Value = new decimal(new int[] { 10, 0, 0, 0 });
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 14F);
			label1.Location = new Point(401, 186);
			label1.Name = "label1";
			label1.Size = new Size(88, 25);
			label1.TabIndex = 11;
			label1.Text = "Accuracy";
			accuracyTT.SetToolTip(label1, "The number of times the proposition list will be looped over.");
			// 
			// accuracyTT
			// 
			accuracyTT.Popup += toolTip1_Popup;
			// 
			// methodsUsedLB
			// 
			methodsUsedLB.FormattingEnabled = true;
			methodsUsedLB.ItemHeight = 15;
			methodsUsedLB.Location = new Point(224, 43);
			methodsUsedLB.Name = "methodsUsedLB";
			methodsUsedLB.Size = new Size(178, 169);
			methodsUsedLB.TabIndex = 12;
			methodsUsedLB.Visible = false;
			// 
			// resultsGB
			// 
			resultsGB.Controls.Add(numberOfAttempsLBL);
			resultsGB.Controls.Add(rulesAppliedLBL);
			resultsGB.Controls.Add(resultLBL);
			resultsGB.Controls.Add(methodsUsedLB);
			resultsGB.Location = new Point(380, 219);
			resultsGB.Name = "resultsGB";
			resultsGB.Size = new Size(408, 223);
			resultsGB.TabIndex = 13;
			resultsGB.TabStop = false;
			resultsGB.Text = "Results";
			// 
			// numberOfAttempsLBL
			// 
			numberOfAttempsLBL.AutoSize = true;
			numberOfAttempsLBL.Font = new Font("Segoe UI", 14F);
			numberOfAttempsLBL.Location = new Point(6, 152);
			numberOfAttempsLBL.Name = "numberOfAttempsLBL";
			numberOfAttempsLBL.Size = new Size(187, 25);
			numberOfAttempsLBL.TabIndex = 14;
			numberOfAttempsLBL.Text = "Number of Attempts:";
			numberOfAttempsLBL.Visible = false;
			// 
			// rulesAppliedLBL
			// 
			rulesAppliedLBL.AutoSize = true;
			rulesAppliedLBL.Font = new Font("Segoe UI", 14F);
			rulesAppliedLBL.Location = new Point(244, 15);
			rulesAppliedLBL.Name = "rulesAppliedLBL";
			rulesAppliedLBL.Size = new Size(131, 25);
			rulesAppliedLBL.TabIndex = 13;
			rulesAppliedLBL.Text = "Rules Applied:";
			rulesAppliedLBL.Visible = false;
			// 
			// Main
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(resultsGB);
			Controls.Add(label1);
			Controls.Add(accuracyNUD);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(removePremiseBTN);
			Controls.Add(label2);
			Controls.Add(proveBTN);
			Controls.Add(finalArgumentTB);
			Controls.Add(newPremiseTB);
			Controls.Add(addPremiseBTN);
			Controls.Add(premisesLB);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "Main";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "SES Inference and Decision Making";
			((System.ComponentModel.ISupportInitialize)accuracyNUD).EndInit();
			resultsGB.ResumeLayout(false);
			resultsGB.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}




		#endregion

		private ListBox premisesLB;
		private Button addPremiseBTN;
		private TextBox newPremiseTB;
		private TextBox finalArgumentTB;
		private Button proveBTN;
		private Label resultLBL;
		private Label label2;
		private Button removePremiseBTN;
		private Label label3;
		private Label label4;
		private NumericUpDown accuracyNUD;
		private Label label1;
		private ToolTip accuracyTT;
		private ListBox methodsUsedLB;
		private GroupBox resultsGB;
		private Label numberOfAttempsLBL;
		private Label rulesAppliedLBL;
	}
}
