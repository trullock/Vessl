using System;

namespace Vessl
{
	class Program
	{
		static void Main(string[] args)
		{
			if(args.Length != 2)
			{
				Console.WriteLine("Usage: Vessl <Export Path> <Password>");
				return;
			}
			
			var certificateStore = new CertificateStore();
			var exporter = new Exporter(new IoService());

			var certificates = certificateStore.GetCertificates();
			exporter.Export(certificates, args[0], args[1]);
		}
	}
}
