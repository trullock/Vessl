using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Vessl
{
	class CertificateStore : ICertificateStore
	{
		public void ExportAllPersonalCertificates(string path, string password)
		{
			var x509Store = new X509Store(StoreLocation.LocalMachine);
			x509Store.Open(OpenFlags.ReadOnly);
			foreach(var certificate in x509Store.Certificates)
			{
				var expirationDate = DateTime.Parse(certificate.GetExpirationDateString());
				
				var name = GetCN(certificate.Subject);
				name = name.Replace("*", "_");

				var filename = string.Format("{0:yyyyMMddHHmmss}-{1}.pfx", expirationDate, name);

				var bytes = certificate.Export(X509ContentType.Pfx, password);

				using (var fileStream = new FileStream(Path.Combine(path, filename), FileMode.CreateNew))
				using (var binaryWriter = new BinaryWriter(fileStream))
					binaryWriter.Write(bytes);

			}
			x509Store.Close();
		}

		static string GetCN(string subject)
		{
			var pairs = subject.Split(',');
			foreach(var pair in pairs)
			{
				var bits = pair.Split('=');
				if (bits[0] == "CN")
					return bits[1].Trim();
			}
			return null;
		}
	}
}