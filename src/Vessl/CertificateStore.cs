using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Vessl
{
	sealed class CertificateStore : ICertificateStore
	{
		public IEnumerable<X509Certificate2> GetCertificates()
		{
			var x509Store = new X509Store(StoreLocation.LocalMachine);
			x509Store.Open(OpenFlags.ReadOnly);
			
			var certificates = x509Store.Certificates;
			
			x509Store.Close();

			return certificates.Cast<X509Certificate2>();
		}
	}
}