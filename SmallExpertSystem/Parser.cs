using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SmallExpertSystem
{
	public class Parser
	{
		//Dictionary<string,string> premises = new Dictionary<string,string>();
		Dictionary<char,string> defs = new Dictionary<char,string>();
		

		public List<string> getDefs()
		{
			return defs.Values.ToList();

		}
		

		public void printDefs()
		{
			foreach (var def in defs)
			{
                Console.WriteLine(def.Key + " : " + def.Value);
            }
		}

		public void clearDefinitions()
		{
			defs.Clear();
		}


		public  Task<string> parsePremise(string premise)
		{		
			string cleanedPremise = cleanStatment(premise);
			foreach (Rule rule in RulesList.rulesList)
			{
				string result = applyRule(cleanedPremise, rule);
				if (result != "failed")
				{
					return Task.FromResult(result);
				}

			}
			printDefs();
			return Task.FromResult(applyLiteral(premise));
		}

		private string applyRule(string cleanedPremise, Rule rule)
		{
			foreach (string pattern in rule.patterns)
			{
				Match match = Regex.Match(cleanedPremise, pattern);
				if (match.Success)
				{
					var groups = match.Groups;
					var finalPatterns = new Dictionary<string,string>();
					
					foreach (var groupName in match.Groups.Keys)
					{
						if (groupName == "0")
						{
							continue;
						}
						finalPatterns[groupName] = parsePremise(groups[groupName].Value).Result;
						
					}
					

					return _translatePattern(finalPatterns,rule.output);


				}


			}

			return "failed";
		}

		private string applyLiteral(string premise)
		{
			string polarity = "";
			foreach(var word in RulesList.negationsList)
			{
				int n = Regex.Matches(premise,word.negative, RegexOptions.IgnoreCase).Count;
				premise = Regex.Replace(premise,word.negative,word.positive,RegexOptions.IgnoreCase);
				polarity += new string('~', n);
			}

			premise = cleanStatment(premise);
			char p = getPropositionName(premise);
			defs[p] = premise;
			return polarity + p;
		}

		private char getPropositionName(string premise)
		{
			string names = "PQRSTUVWXYZBCDEFGHJKLMN";
			Dictionary<string, char> inverted = defs.ToDictionary(pair => pair.Value, pair => pair.Key);
			if (inverted.ContainsKey(premise))
			{
				return inverted[premise];
			}
			else
			{
				foreach (char name in names)
				{
					
					if (!defs.ContainsKey(name))
					{
						return name;
					}
				}

				return 'N';
			}
		}

		

		private string _translatePattern(Dictionary<string, string> premises, string output)
		{
			string formattedOutput = "(" + string.Format(output, premises.Values.ToArray()) + ")";
			return formattedOutput;

		}

		private string cleanStatment(string statment)
		{
			string cleanedStatment = Regex.Replace(statment, @"\s+", " ");
			cleanedStatment = cleanedStatment.Replace("’", "'");
			cleanedStatment = cleanedStatment.TrimEnd('.', ',');
			return cleanedStatment.ToLower();
		}


	}
}
