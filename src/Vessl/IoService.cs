using System.IO;

namespace Vessl
{
	sealed class IoService : IIoService
	{
		public void WriteFile(string path, byte[] bytes)
		{
			using (var fileStream = new FileStream(path, FileMode.CreateNew))
			using (var binaryWriter = new BinaryWriter(fileStream))
				binaryWriter.Write(bytes);
		}
	}
}