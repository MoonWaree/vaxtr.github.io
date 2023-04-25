using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public static class DllProtection
{
    [DllImport("kernel32.dll")]
    static extern unsafe bool VirtualProtect(IntPtr lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

    public static void CheckSignature(string filePath)
    {
        X509Certificate2 cert = null;
        try
        {
            Assembly assembly = Assembly.LoadFile(filePath);
            byte[] bytes = assembly.GetName().GetPublicKey();
            if (bytes != null)
            {
                cert = new X509Certificate2(bytes);
                if (!cert.Verify())
                {
                    throw new Exception("Invalid digital signature.");
                }
            }
        }
        catch
        {
            throw new Exception("Invalid digital signature.");
        }
    }

    public static void ProtectMemory(IntPtr address, int size)
    {
        uint oldProtect;
        if (!VirtualProtect(address, size, 0x40, out oldProtect)) // PAGE_EXECUTE_READWRITE = 0x40
        {
            throw new Exception("Failed to protect memory.");
        }
    }

    public static void UnprotectMemory(IntPtr address, int size)
    {
        uint oldProtect;
        if (!VirtualProtect(address, size, 0x04, out oldProtect)) // PAGE_READWRITE = 0x04
        {
            throw new Exception("Failed to unprotect memory.");
        }
    }

    public static byte[] Decrypt(byte[] data, string key)
    {
        byte[] keyBytes = Encoding.ASCII.GetBytes(key);
        using (var aes = new AesCryptoServiceProvider())
        {
            aes.KeySize = 128;
            aes.Key = keyBytes;
            aes.IV = keyBytes;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                }
                return ms.ToArray();
            }
        }
    }

    public static byte[] ReadEncryptedFile(string filePath, string key)
    {
        byte[] encryptedData = File.ReadAllBytes(filePath);
        return Decrypt(encryptedData, key);
    }
}