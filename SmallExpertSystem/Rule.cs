using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallExpertSystem
{
	public class Rule
	{
		public string output {  get; set; }
		public List<string> patterns { get; set; }

		public Rule(string Inoutput,params string[] Inpatterns)
		{
			output = Inoutput;
			patterns = new List<string>(Inpatterns);
		}

	}

	public class Word
	{
		public string positive { get; set; }
		public string negative { get; set; }

        public Word(string inNeg, string inPos)
        {
			positive = inPos;
			negative = inNeg;
        }
    }


	public class RulesList
	{
		public static List<Rule> rulesList = new List<Rule>
		{
			new Rule("{0} => {1}", "if (.+?) then (.+?)$", "if (.+?), (.+?)$"),
			new Rule("{0} || {1}", "either (.+?) or else (.+?)$", "either (.+?) or (.+?)$"),
			new Rule("{0} && {1}", "both (.+?) and (.+?)$"),
			new Rule("～{0} && ～{1}", "neither (.+?) nor (.+?)$"),
			new Rule("~{2}{0} && ~{2}{1}", "(.+?) neither (.+?) nor (.+?)$"),
			new Rule("~{0} => {1}", "(.+?) unless (.+?)$"),
			new Rule("{1} => {0}", "(.+?) provided that (.+?)$", "(.+?) whenever (.+?)$","(.+?) implies (.+?)$", "(.+?) therefore (.+?)$","(.+?), if (.+?)$", "(.+?) if (.+?)$", "(.+?) only if (.+?)$"),
			new Rule("{0} && {1}", "(.+?) and (.+?)$", "(.+?) but (.+?)$"),
			new Rule("{0} || {1}", "(.+?) or else (.+?)$", "(.+?) or (.+?)$")
		};

		public static List<Word> negationsList = new List<Word>
		{
			new Word(@"\bnot\b",""),
			new Word(@"\bcannot\b","can"),
			new Word(@"\bcan't\b","can"),
			new Word(@"\bwon't\b","will"),
			new Word(@"\bain't\b","is"),
			new Word("n't",""),
		};
	}


}
