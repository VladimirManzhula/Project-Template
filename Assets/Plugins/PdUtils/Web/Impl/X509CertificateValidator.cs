using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Networking;

namespace PdUtils.Web.Impl
{
	public class X509CertificateValidator : CertificateHandler, IX509CertificateValidator
	{
		private readonly string _publicCertKey;

		public X509CertificateValidator(string publicCertKey)
		{
			_publicCertKey = publicCertKey;
		}

		public bool ValidateCertificate(object sender,
			X509Certificate certificate,
			X509Chain chain,
			SslPolicyErrors sslPolicyErrors)
		{
			var pk = certificate.GetPublicKeyString();
			return pk != null && pk.Equals(_publicCertKey);
		}
		
		bool IX509CertificateValidator.ValidateCertificate(byte[] certificateData)
		{
			return ValidateCertificate(certificateData);
		}

		protected override bool ValidateCertificate(byte[] certificateData)
		{
			var certificate = new X509Certificate2(certificateData);
			var pk = certificate.GetPublicKeyString();
			return pk != null && pk.Equals(_publicCertKey);
		}
	}
}