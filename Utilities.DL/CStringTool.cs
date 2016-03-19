using System;
using System.Collections.Generic;

namespace Utilities.DL
{
	public static class CStringTool
	{
		
		public static List<string> SplitStringNewline (string vsInput)
		{
			string[] allInputs = vsInput.Split (new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			var oList = new List<string> ();
			foreach (var s in allInputs) {
				var ss = s.Split (new string[] { @"\n" }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var r in ss) {
					var rr = r.Split (new string[] { @"\r" }, StringSplitOptions.RemoveEmptyEntries);
					oList.AddRange (rr);
				}
			}
			return oList;
		}

		public static IEnumerable<string> SplitString (string vsInput, string symbol)
		{
			string[] allInputs = vsInput.Split (new string[] { symbol }, StringSplitOptions.RemoveEmptyEntries);
			return allInputs;
		}

		public static string Concatinate (List<string> voList)
		{
			var output = String.Join (Environment.NewLine, voList);
			return output;
		}

	}
}

