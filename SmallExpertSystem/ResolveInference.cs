using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmallExpertSystem
{
	public class ResolveInference
	{
		List<string> premises = new List<string>();
		static List<string> finalPropositions;
		

		public static ResolveResult resolve(List<string> propositions,string finalArgument,int numberOfTries)
		{
			List<string> methodsUsed = new List<string>();
			int originalNumberOfTries = numberOfTries;

			finalPropositions = new List<string>(propositions);


			while (finalPropositions.Count > 1 && numberOfTries > 0)
			{
				numberOfTries--;
				
				
				for(int i = 0; i <finalPropositions.Count;i++)
				{
					
					string prop1;
					try
					{
						prop1 = finalPropositions[i];
					}
					catch
					{
						break;
					}

					for (int j = 1; j < finalPropositions.Count; j++)
					{
						printDefs();
						string prop2;
						try
						{
							prop2 = finalPropositions[j];
						}
						catch
						{
							break;
						}

						if (prop1 == prop2) continue;

						if (ModusPonenus(prop1, prop2))
						{
							methodsUsed.Add("Modus Ponenus");
							break;
						}
						if (ModusTollens(prop1, prop2))
						{
							methodsUsed.Add("Modus Tollens");
							break;

						}
						if (HypotheticalSyllogism(prop1, prop2))
						{
							methodsUsed.Add("Hypothetical Syllogism");
							break;
						}
						if (DisjunctiveSyllogism(prop1, prop2))
						{
							methodsUsed.Add("Disjunctive Syllogism");
							break;
						}
						//if (Addition(prop1)) continue;
						if (Simplification(prop1))
						{
							methodsUsed.Add("Simplification");
							break;
						}
						if (Conjunction(prop1, prop2))
						{
							methodsUsed.Add("Conjunction");
							break;
						}
						if (Resolution(prop1, prop2))
						{
							methodsUsed.Add("Resolution");
							break;
						}

					}
				}

			}
			ResolveResult result = new();
			result.methodsUsed = methodsUsed;
			result.numberOfAttempts = (originalNumberOfTries - numberOfTries);
			try
			{
				
				if (finalPropositions[0] == finalArgument)
				{
					result.isValid = true;
					return result;
				}
				else if (numberOfTries <= 0)
				{

					result.isValid = false;
					return result;
				}
				else
				{
					result.isValid = false;
					return result;
				}
			}
			catch
			{
				result.isValid = false;
				return result;
			}
			

		}



		private static void printDefs()
		{
			foreach(var prop in finalPropositions)
			{
                Console.WriteLine(prop);
            }
			Console.WriteLine("------------------");
		}

		private static bool ModusPonenus(string statment1, string statment2)
		{
			string pattern = @"(.+?)\s*=>\s*(.+)";

			Match match = Regex.Match(statment1, pattern);
			if(match.Success)
			{
				if(statment2 == match.Groups[1].Value.Replace("(", "") && !finalPropositions.Contains(match.Groups[2].Value.Replace(")", "")))
				{
					finalPropositions.Add(match.Groups[2].Value.Replace(")", ""));
					finalPropositions.Remove(statment1);
					finalPropositions.Remove(statment2);
					return true;
				}

				
			}
			match = Regex.Match(statment2, pattern);
			if(match.Success)
			{
				if(statment1 == match.Groups[1].Value.Replace("(","") && !finalPropositions.Contains(match.Groups[2].Value.Replace(")", "")))
				{
					finalPropositions.Add(match.Groups[2].Value.Replace(")", ""));
					finalPropositions.Remove(statment1);
					finalPropositions.Remove(statment2);
					return true;
				}

				

			}

			return false;
			
		}
		private static bool ModusTollens(string statment1, string statment2)
		{
			string pattern = @"(.+?)\s*=>\s*(.+)";

			Match match = Regex.Match(statment1, pattern);
			if (match.Success)
			{
				if (statment2.Replace("~","") == match.Groups[2].Value.Replace(")", "") && !finalPropositions.Contains("~" + match.Groups[1].Value.Replace("(", "")))
				{
					finalPropositions.Add("~" + match.Groups[1].Value.Replace("(", ""));
					finalPropositions.Remove(statment1);
					finalPropositions.Remove(statment2);
					return true;
				}


			}
			match = Regex.Match(statment2, pattern);
			if (match.Success)
			{
				if (statment1.Replace("~","") == match.Groups[2].Value.Replace(")", "") && !finalPropositions.Contains("~" + match.Groups[1].Value.Replace("(", "")))
				{
					finalPropositions.Add("~" + match.Groups[1].Value.Replace("(", ""));
					finalPropositions.Remove(statment1);
					finalPropositions.Remove(statment2);
					return true;
				}



			}

			return false;
		}
		private static bool HypotheticalSyllogism(string statment1, string statment2)
		{
			string pattern = @"(.+?)\s*=>\s*(.+)";

			Match match1 = Regex.Match(statment1, pattern);
			Match match2 = Regex.Match(statment2, pattern);
			if (match1.Success && match2.Success)
			{
				if (match1.Groups[2].Value.Replace(")","") == match2.Groups[1].Value.Replace("(", "") && !finalPropositions.Contains(match1.Groups[1].Value + " => " + match2.Groups[2].Value))
				{
					finalPropositions.Add(match1.Groups[1].Value + " => " + match2.Groups[2].Value);
					finalPropositions.Remove(statment1);
					finalPropositions.Remove(statment2);
					return true;
				}

				if (match2.Groups[2].Value.Replace(")", "") == match1.Groups[1].Value.Replace("(", "") && !finalPropositions.Contains(match2.Groups[1].Value + " => " + match1.Groups[2].Value))
				{
					finalPropositions.Add(match2.Groups[1].Value + " => " + match1.Groups[2].Value);
					finalPropositions.Remove(statment1);
					finalPropositions.Remove(statment2);
					return true;
				}


			}
			
			

			return false;
		}
		private static bool DisjunctiveSyllogism(string statment1, string statment2)
		{
			string pattern = @"(.+?)\s*\|\|\s*(.+)";
			Match match = Regex.Match(statment1,pattern);
			if (match.Success)
			{
				if (match.Groups[1].Value.Replace("(", "") == statment2.Replace("~", "") && !finalPropositions.Contains(match.Groups[2].Value))
				{
					finalPropositions.Add(match.Groups[2].Value.Replace(")", ""));
					finalPropositions.Remove(statment1);
					finalPropositions.Remove(statment2);
					return true;

				}

				
			}

			match = Regex.Match(statment2, pattern);
			if (match.Success)
			{
				if (match.Groups[1].Value.Replace("(","") == statment1.Replace("~", "") && !finalPropositions.Contains(match.Groups[2].Value))
				{
					finalPropositions.Add(match.Groups[2].Value.Replace(")", ""));
					finalPropositions.Remove(statment1);
					finalPropositions.Remove(statment2);
					return true;
				}

				
			}

			return false;
		}
		private static string Addition(string statment)
		{
			throw new NotImplementedException();
		}
		private static bool Simplification(string statment)
		{
			string pattern = @"(.+?)\s*\&\&\s*(.+)";

			Match match = Regex.Match(statment,pattern);
			if(match.Success && !finalPropositions.Contains(match.Groups[1].Value.Replace("(", ""))
							&& !finalPropositions.Contains(match.Groups[2].Value.Replace(")", "")))
			{
				finalPropositions.Add(match.Groups[1].Value.Replace("(",""));
				finalPropositions.Add(match.Groups[2].Value.Replace(")", ""));
				finalPropositions.Remove(statment);
				return true;
			}
			return false;
		}
		private static bool Conjunction(string statment1, string statment2)
		{
			string pattern = @"^(?:(~)?(.))$";
			Match match1 = Regex.Match(statment1,pattern);
			Match match2 = Regex.Match(statment2,pattern);
			if(match1.Success && match2.Success && !finalPropositions.Contains($"{match1.Groups[0].Value} && {match2.Groups[0].Value}"))
			{
				finalPropositions.Add($"({match1.Groups[0].Value} && {match2.Groups[0].Value})");
				finalPropositions.Remove(statment1);
				finalPropositions.Remove(statment2);
				return true;
			}

			return false;

		}
		private static bool Resolution(string statment1, string statment2)
		{
			string pattern = @"(.+?)\s*\|\|\s*(.+)";
			Match match1 = Regex.Match(statment1,pattern);
			Match match2 = Regex.Match(statment2,pattern);

			if(match1.Success && match2.Success && match1.Groups[1].Value == "~" + match2.Groups[1].Value
												&& !finalPropositions.Contains($"({match1.Groups[2].Value} || {match2.Groups[2].Value})"))
			{
				finalPropositions.Add($"({match1.Groups[2].Value} || {match2.Groups[2].Value})");
				finalPropositions.Remove(statment1);
				finalPropositions.Remove(statment2);
				return true;

			}
			else if (match1.Success && match2.Success && match2.Groups[1].Value.Replace("~","") ==  match1.Groups[1].Value
												&& !finalPropositions.Contains($"({match1.Groups[2].Value} || {match2.Groups[2].Value})"))
			{
				finalPropositions.Add($"({match1.Groups[2].Value} || {match2.Groups[2].Value})");
				finalPropositions.Remove(statment1);
				finalPropositions.Remove(statment2);
				return true;

			}


			return false;

		}
	}
}
