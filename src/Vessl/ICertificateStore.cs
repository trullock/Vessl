namespace Vessl
{
	interface ICertificateStore
	{
		void ExportAllPersonalCertificates(string path, string password);
	}
}