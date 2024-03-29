using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Vessl
{
	interface ICertificateStore
	{
		IEnumerable<X509Certificate2> GetCertificates();
	}
}