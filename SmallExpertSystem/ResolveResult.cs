using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallExpertSystem
{
	public class ResolveResult
	{
        public List<string> methodsUsed { get; set; }
		public bool isValid { get; set; }
		public int numberOfAttempts { get; set; }
    }
}
