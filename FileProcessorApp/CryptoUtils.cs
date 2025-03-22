using System;
using System.Security.Cryptography;
using System.Text;

public static class CryptoUtils
{
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("ThisIsASecretKey"); 
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("ThisIsAnIV123456"); 

    public static string Encrypt(string plainText)
    {
        using Aes aes = Aes.Create();
        aes.Key = Key;
        aes.IV = IV;

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

        return Convert.ToBase64String(encryptedBytes);
    }

    public static string Decrypt(string encryptedText)
    {
        using Aes aes = Aes.Create();
        aes.Key = Key;
        aes.IV = IV;

        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] plainBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

        return Encoding.UTF8.GetString(plainBytes);
    }
}