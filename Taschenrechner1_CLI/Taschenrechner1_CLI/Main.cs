using System;

namespace Taschenrechner1_CLI
{


	class MainClass
	{
		public static void Main (string[] args)
		{
			string term;
			string[] result;
			Taschenrechner myCalc = new Taschenrechner();
			myCalc.Initialize();


			try {
				term = args[0];
			} catch (IndexOutOfRangeException) {
				Console.WriteLine ("Enter your term:");
				term = Console.ReadLine();
			}
			result = myCalc.Analyze(term);
			Console.WriteLine();
			Console.WriteLine("Result: "+result[0]+"\n"+result[1]);

		}
	}
}
