using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using HDF5CSharp;

namespace adfsummary
{
	internal class Program
	{


		public class Options
		{
			//[Option("verbose", Required = false, HelpText = "Set output to verbose messages.")]
			//public bool Verbose { get; set; }

			[Value(0, MetaName = "filename", Required = true, HelpText = "Positional argument")]
			public string InputPath { get; set; }
		}

		static void Main(string[] args)
		{

			var parser = new Parser(with => with.HelpWriter = null);
			var parserResult = parser.ParseArguments<Options>(args);
			//parserResult
			//  .WithParsed(opt => opt.Dump())


			//Parser.Default.ParseArguments<Options>(args)
			parserResult.WithParsed<Options>(o =>
			{
				// Command line arguments  
				Console.WriteLine("Argument length: " + args.Length);
				Console.WriteLine("Supplied Arguments are:");
				foreach (Object obj in args)
				{
					Console.WriteLine(obj);
				}

				//if (o.Verbose)
				//{
				//	Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
				//	Console.WriteLine("Quick Start Example! App is in Verbose mode!");
				//}
				//else
				//{
				//	Console.WriteLine($"Current Arguments: -v {o.Verbose}");
				//	Console.WriteLine("Quick Start Example!");
				//	Console.WriteLine($"Filename: {o.InputPath}");
				//}
			})
			.WithNotParsed(x =>
			{
				var helpText = HelpText.AutoBuild(parserResult, h =>
							{
								h.AdditionalNewLineAfterOption = false;
								h.Heading = new HeadingInfo("adfsummary | ams | ATAM");
								h.AutoHelp = true;     // hides --help
								h.AutoVersion = false;  // hides --version
								h.Copyright = new CopyrightInfo("Hüseyin YİĞİT", 2023);
								return HelpText.DefaultParsingErrorsHandler(parserResult, h);
							}, e => e);

				Console.WriteLine(helpText.ToString().Replace("(pos. 0)","        "));
			});




			
		}
	}
}
