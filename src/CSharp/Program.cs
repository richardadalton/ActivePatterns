using System;

namespace CSharp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int y = ReturningSwitchStatement(3);

			Console.WriteLine (y);
			Console.ReadKey ();
		}

		private static void SimpleSwitchStatement()
		{
			int x = 1;

			switch(x) {
			case 1:
				Console.WriteLine ("Tiny");
				break;
			case 2:
			case 3:
			case 4:
				Console.WriteLine("Small");
				break;
			case 5:
			case 6:
			case 7:
				Console.WriteLine("Big");
				break;
			case 8:
			case 9:
			case 10:
				Console.WriteLine("Huge");
				break;
			default:
				Console.WriteLine("I dunno");
				break;
			}
		}





		private static void GotoSwitchStatement()
		{
			int x = 1;

			switch(x) {
			case 1:
				Console.WriteLine ("Tiny");
				goto case 2;
			case 2:
			case 3:
			case 4:
				Console.WriteLine("Small");
				break;
			case 5:
			case 6:
			case 7:
				Console.WriteLine("Big");
				break;
			case 8:
			case 9:
			case 10:
				Console.WriteLine("Huge");
				break;
			default:
				Console.WriteLine("I dunno");
				break;
			}
		}








		private static int ReturningSwitchStatement(int x)
		{
			switch(x) {
			case 1:
			case 3:
			case 5:
			case 7:
			case 9:
				return x * 2;
			case 2:
			case 4:
			case 6:
			case 8:
				return x;
			default:
				return 0;
			}
		}














		private static int IllegalSwitchStatement(int x)
		{			
			int y = switch(x) {
			case 1:
			case 3:
			case 5:
			case 7:
			case 9:
				x * 2;
			case 2:
			case 4:
			case 6:
			case 8:
				x;
			default:
				0;
			}

            return y;
		}
	}
}
