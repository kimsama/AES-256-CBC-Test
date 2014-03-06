using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

/// <summary>
/// !! Decrpecated !!
/// 
/// http://www.codingvision.net/security/c-php-compatible-encryption-aes256
/// 
/// </summary>
public class MessageUtil 
{
	public static string EncryptMessage(byte[] text, string key)
	{
		RijndaelManaged aes = new RijndaelManaged();
		aes.KeySize = 256;  
		aes.BlockSize = 256;
		aes.Padding = PaddingMode.Zeros;
		aes.Mode = CipherMode.CBC;
		
		aes.Key = Encoding.Default.GetBytes(key);
		aes.GenerateIV();  
		
		string IV = ("-[--IV-[-" + Encoding.Default.GetString(aes.IV));
		
		ICryptoTransform AESEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
		byte[] buffer = text;
		
		return Convert.ToBase64String(Encoding.Default.GetBytes(Encoding.Default.GetString(AESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length)) + IV));
		
	}

	public static string DecryptMessage(string text, string key)
	{
		RijndaelManaged aes = new RijndaelManaged();
		aes.KeySize = 256;
		aes.BlockSize = 256;
		aes.Padding = PaddingMode.Zeros;
		aes.Mode = CipherMode.CBC;
		
		aes.Key = Encoding.Default.GetBytes(key);
		
		text = Encoding.Default.GetString(Convert.FromBase64String(text));
		
		string IV = text;
		IV = IV.Substring(IV.IndexOf("-[--IV-[-") + 9);
		text = text.Replace("-[--IV-[-" + IV, "");
		
		text = Convert.ToBase64String(Encoding.Default.GetBytes(text));
		aes.IV = Encoding.Default.GetBytes(IV);
		
		ICryptoTransform AESDecrypt = aes.CreateDecryptor(aes.Key, aes.IV);
		byte[] buffer = Convert.FromBase64String(text);
		
		return Encoding.Default.GetString(AESDecrypt.TransformFinalBlock(buffer, 0, buffer.Length));
	}

}
