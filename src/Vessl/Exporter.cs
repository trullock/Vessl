﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Vessl
{
	sealed class Exporter : IExporter
	{
		readonly IIoService ioService;

		public Exporter(IIoService ioService)
		{
			this.ioService = ioService;
		}

		public void Export(IEnumerable<X509Certificate2> certificates, string path, string password, string format)
		{
			foreach (var certificate in certificates)
			{
				// TODO: must be a better way?
				var expirationDate = DateTime.Parse(certificate.GetExpirationDateString());

				var name = GetCN(certificate.Subject).Replace("*", "_");
				
				var filename = string.Format(format, expirationDate, name) + ".pfx";

				var bytes = !string.IsNullOrEmpty(password) ? certificate.Export(X509ContentType.Pfx, password) : certificate.Export(X509ContentType.Pfx);

				ioService.WriteFile(Path.Combine(path, filename), bytes);
			}
		}

		/// <summary>
		/// Gets the CN property from the certificate subject
		/// </summary>
		/// <param name="subject"></param>
		/// <returns></returns>
		static string GetCN(string subject)
		{
			var pairs = subject.Split(',');
			foreach (var pair in pairs)
			{
				var bits = pair.Split('=');
				if (bits[0] == "CN")
					return bits[1].Trim();
			}
			return null;
		}
	}
}