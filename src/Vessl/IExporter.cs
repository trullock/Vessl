using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Vessl
{
	public interface IExporter
	{
		void Export(IEnumerable<X509Certificate2> certificates, string path, string password, string format);
	}
}