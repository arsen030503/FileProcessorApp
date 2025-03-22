using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessorApp
{
	[TestClass]
	public class TestModule
	{
		[TestMethod]
		public void EncryptDecrypt_ShouldReturnOriginalText()
		{
			string originalText = "Тестовый текст для проверки шифрования и расшифровки.";

			string encrypted = CryptoUtils.Encrypt(originalText);
			string decrypted = CryptoUtils.Decrypt(encrypted);

			Assert.AreEqual(originalText, decrypted, "Расшифрованный текст не совпадает с исходным.");
		}
	}
}
