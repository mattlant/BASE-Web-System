using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Web.Configuration;


namespace BASE.Web.Security
{
	/// <summary>
	/// Encrypts and decrypts strings by
	/// using the Rijndael (AES) algorithm
	/// </summary>
	public static class BASEEncryption
	{

		private static readonly byte[] Key;
		private static readonly byte[] IV;

		#region HASHING
		public static byte[] GetHash(string toHash, string extraData)
		{
			byte[] prehashBytes = Encoding.Unicode.GetBytes(toHash + extraData);
			return GetHash(prehashBytes);
		}

		public static byte[] GetHash(byte[] toHash, byte[] extraData)
		{
			byte[] newArr = new byte[toHash.Length + extraData.Length];
			toHash.CopyTo(newArr, 0);
			extraData.CopyTo(newArr, toHash.Length);
			return GetHash(newArr);
		}

		public static byte[] GetHash(byte[] toHash)
		{
			SHA1 sha1 = new SHA1CryptoServiceProvider();
			return sha1.ComputeHash(toHash);
		}

		public static string GetBase64Hash(string toHash, string extraData)
		{
			byte[] hashBytes = GetHash(toHash, extraData);
			return Convert.ToBase64String(hashBytes);
		}

		public static string GetBase64Hash(byte[] toHash, byte[] extraData)
		{
			byte[] hashBytes = GetHash(toHash, extraData);
			return Convert.ToBase64String(hashBytes);
		}


		public static bool VerifyHash(string original, string extraData, string hashBase64)
		{
			string hash1 = GetBase64Hash(original, extraData);
			return hash1 == hashBase64;
		}

		#endregion

		#region ENCRYPTION
		/// <summary>
		/// Encrypt a string using the machineKey decryptionKey
		/// attribute from the Web configuration file
		/// </summary>
		public static byte[] Encrypt(string text)
		{
			//Convert the data to a byte array.
			byte[] toEncrypt = Encoding.ASCII.GetBytes(text);
			return Encrypt(toEncrypt);
		}

		public static byte[] Encrypt(byte[] toEncrypt)
		{
			//Get an encryptor.
			RijndaelManaged myRijndael = new RijndaelManaged();
			ICryptoTransform encryptor = myRijndael.CreateEncryptor(Key, IV);

			//Encrypt the data.
			MemoryStream msEncrypt = new MemoryStream();
			CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

			//Write all data to the crypto stream and flush it.
			csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
			csEncrypt.FlushFinalBlock();

			//Get encrypted array of bytes.
			return msEncrypt.ToArray();

		}

		public static string EncryptToBase64(string text)
		{
			byte[] toEncrypt = Encoding.ASCII.GetBytes(text);
			return EncryptToBase64(toEncrypt);
		}

		public static string EncryptToBase64(byte[] toEncrypt)
		{
			byte[] results = Encrypt(toEncrypt);
			return Convert.ToBase64String(results);
		}


		/// <summary>
		/// Decrypts a string
		/// </summary>
		public static string DecryptToString(string encryptedBase64)
		{
			byte[] decrypted = DecryptToBytes(encryptedBase64);
			return Encoding.ASCII.GetString(decrypted);
		}

		/// <summary>
		/// Decrypts a string
		/// </summary>
		public static string DecryptToString(byte[] encrypted)
		{
			byte[] fromEncrypt = DecryptToBytes(encrypted);
			return Encoding.ASCII.GetString(fromEncrypt);
		}

		/// <summary>
		/// Decrypts a string
		/// </summary>
		public static byte[] DecryptToBytes(string encryptedBase64)
		{
			byte[] encrypted = Convert.FromBase64String(encryptedBase64);
			return DecryptToBytes(encrypted);
		}

		/// <summary>
		/// Decrypts a string
		/// </summary>
		public static byte[] DecryptToBytes(byte[] encrypted)
		{
			RijndaelManaged myRijndael = new RijndaelManaged();

			//Get a decryptor that uses the same key and IV as the encryptor.
			ICryptoTransform decryptor = myRijndael.CreateDecryptor(Key, IV);

			// Decrypt into memory stream
			MemoryStream msDecrypt = new MemoryStream(encrypted);
			CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

			byte[] fromEncrypt = new byte[encrypted.Length];

			//Read the data out of the crypto stream.
			csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

			//Convert the byte array back into a string.
			return fromEncrypt;
		}

		#endregion


		/// <summary>
		/// Load decryptionKey from machineKey section of the Web configuration file
		/// </summary>
		static BASEEncryption()
		{

			// Get the encryption key
			MachineKeySection section = (MachineKeySection)WebConfigurationManager.GetWebApplicationSection("system.web/machineKey");
			if (section.DecryptionKey == null)
				throw new Exception("You must specify a decryptionKey in the Web configuration file");
			string decryptionKey = section.DecryptionKey;

			// Derive the encryption Key and IV
			byte[] bSalt = Encoding.ASCII.GetBytes(SystemManager.Current._salt);
			Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(decryptionKey, bSalt);
			Key = pdb.GetBytes(32);
			IV = pdb.GetBytes(16);
		}

	}
}
