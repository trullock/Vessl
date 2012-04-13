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
			certificateStore.ExportAllPersonalCertificates( args[0], args[1]);
		}
	}
}
