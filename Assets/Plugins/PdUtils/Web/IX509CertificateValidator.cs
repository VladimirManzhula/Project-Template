using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace PdUtils.Web
{
	public interface IX509CertificateValidator
	{
		bool ValidateCertificate(object sender,
			X509Certificate certificate,
			X509Chain chain,
			SslPolicyErrors sslPolicyErrors);

		bool ValidateCertificate(byte[] certificateData);
	}
}