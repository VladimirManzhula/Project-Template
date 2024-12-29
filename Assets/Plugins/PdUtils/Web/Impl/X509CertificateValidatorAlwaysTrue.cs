using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Networking;

namespace PdUtils.Web.Impl
{
	public class X509CertificateValidatorAlwaysTrue : CertificateHandler, IX509CertificateValidator
	{
		public bool ValidateCertificate(object sender,
			X509Certificate certificate,
			X509Chain chain,
			SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}
		
		bool IX509CertificateValidator.ValidateCertificate(byte[] certificateData)
		{
			return ValidateCertificate(certificateData);
		}

		protected override bool ValidateCertificate(byte[] certificateData)
		{
			return true;
		}
	}
}