using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SmallExpertSystem
{
	public partial class Main : Form
	{
		Parser parser = new Parser();
		List<string> finalProps = new List<string>();
		public Main()
		{
			InitializeComponent();

		}

		private async void addPremiseBTN_Click(object sender, EventArgs e)
		{
			string newPremise = newPremiseTB.Text;
			if (string.IsNullOrEmpty(newPremise))
			{
				return;
			}

			premisesLB.Items.Add(newPremise);
			string premise = await parser.parsePremise(newPremise);
			finalProps.Add(premise);
			await Console.Out.WriteLineAsync(premise);

			newPremiseTB.Clear();
		}

		private async void removePremiseBTN_Click(object sender, EventArgs e)
		{
			premisesLB.Items.Clear();
			finalProps.Clear();
			parser.clearDefinitions();
			premisesLB.Update();

		}

		private void updateNumberOfAttempsLBL(int number)
		{
			numberOfAttempsLBL.Text = $"Number of Attempts:\n{number}";
		}
		private void updateMethodsUsedLB(List<string> methodsUsed)
		{
			methodsUsedLB.Items.Clear();
			foreach (string method in methodsUsed) {
				methodsUsedLB.Items.Add(method);
			}
			methodsUsedLB.Update();

		}

		private void clearAndShowResultsGB()
		{
			//resultsGB.Show();
			resultLBL.Hide();
			numberOfAttempsLBL.Hide();
			rulesAppliedLBL.Hide();
			methodsUsedLB.Hide();
	
		}

		private void showResults()
		{
			
			resultLBL.Show();
			numberOfAttempsLBL.Show();
			rulesAppliedLBL.Show();
			methodsUsedLB.Show();
		}

		private async void proveBTN_Click(object sender, EventArgs e)
		{
			clearAndShowResultsGB();
			string finalArgument = await parser.parsePremise(finalArgumentTB.Text);
			await Console.Out.WriteLineAsync(finalArgument);
			ResolveResult finalResult = ResolveInference.resolve(finalProps, finalArgument, (int)accuracyNUD.Value);
			showResults();
			updateNumberOfAttempsLBL(finalResult.numberOfAttempts);
			updateMethodsUsedLB(finalResult.methodsUsed);

			if (finalResult.isValid)
			{
				updateResultLabel("Valid!");
			}
			else
			{
				updateResultLabel("Not Valid!");
			}

			removePremiseBTN.PerformClick();
			finalArgumentTB.Clear();
		}


		private void updateResultLabel(string newText)
		{
			resultLBL.Text = newText;
		}

		private void toolTip1_Popup(object sender, PopupEventArgs e)
		{

		}
	}
}
