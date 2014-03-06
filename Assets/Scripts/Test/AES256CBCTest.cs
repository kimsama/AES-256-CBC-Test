using UnityEngine;
using System.Collections;

using CoreUtils.Utilities;


/// <summary>
/// AES-256-CBC Test
/// </summary>
public class AES256CBCTest : MonoBehaviour 
{
	
	void Start () 
	{
		// does not correctly work as it is expected!
		//TestSuite_MessageUtil();

		// works fine!
		TestSuite_CoreUtils ();

	}

	/// <summary>
	/// 
	/// Found at:
	/// 	http://stackoverflow.com/questions/18502375/aes256-encryption-decryption-in-both-nodejs-and-c-sharp-net
	/// 
	/// </summary>
	void TestSuite_CoreUtils()
	{
		string message = "Hello, world";		
		string key = "This is my password.";
		
		Debug.Log ("Original message: " + message);
		
		string encryptedMsg = CryptoUtility.Encrypt (message, key);
		
		Debug.Log ("Ectripted Message: " + encryptedMsg);
		
		string decryptedMsg = CryptoUtility.Decrypt (encryptedMsg, key);
		
		Debug.Log("Decrypted Message: " + decryptedMsg);
	}

	/// <summary>
	/// 
	/// Found at:
	/// 	http://www.codingvision.net/security/c-php-compatible-encryption-aes256
	/// 
	/// </summary>
	void TestSuite_MessageUtil()
	{
		string message = "Hello, world";
		string key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ012345";
		
		Debug.Log ("orignal message: " + message);
		
		string encriptedMessage = MessageUtil.EncryptMessage( GetBytes(message), key);
		
		string descriptedMesssage = MessageUtil.DecryptMessage (encriptedMessage, key);
		
		Debug.Log ("descripted messsage: " + descriptedMesssage);
	}

	// deprecated.
	static byte[] GetBytes(string str)
	{
		byte[] bytes = new byte[str.Length * sizeof(char)];
		System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
		return bytes;
	}

}
