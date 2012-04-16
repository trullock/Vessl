using System;
using NDesk.Options;

namespace Vessl
{
	class Program
	{
		static void Main(string[] args)
		{
			string password = null;
			string format = "{0:yyyyMMddHHmmss}-{1}";

			var optionSet = new OptionSet
								{
									{"p|pass=", "The password for each certificate", x => password = x},
									{"f|format=", "The string format for certificate names", x => format = x}
								};
			var list = optionSet.Parse(args);

			if(list.Count != 1)
			{
				ShowUsage(optionSet);
				return;
			}

			var certificateStore = new CertificateStore();
			var exporter = new Exporter(new IoService());

			var certificates = certificateStore.GetCertificates();
			exporter.Export(certificates, list[0], password, format);
		}

		static void ShowUsage(OptionSet optionSet)
		{
			Console.WriteLine("Usage:");
			optionSet.WriteOptionDescriptions(Console.Out);
			Console.WriteLine("  Export Path");
		}
	}
}
