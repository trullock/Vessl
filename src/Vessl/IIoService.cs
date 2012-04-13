namespace Vessl
{
	public interface IIoService
	{
		void WriteFile(string path, byte[] bytes);
	}
}