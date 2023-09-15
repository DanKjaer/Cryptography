// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

//Console.WriteLine("x");

//string? enteredText = Console.ReadLine();

// generate a key
var key = new byte[32];
RandomNumberGenerator.Fill(key);

using var aes = new AesGcm(key);

var nonce = new byte[AesGcm.NonceByteSizes.MaxSize]; // MaxSize = 12
RandomNumberGenerator.Fill(nonce);

var plaintextBytes = Encoding.UTF8.GetBytes("got more soul than a sock with a hole");
var ciphertext = new byte[plaintextBytes.Length];
var tag = new byte[AesGcm.TagByteSizes.MaxSize];

aes.Encrypt(nonce, plaintextBytes, ciphertext, tag);

string b64String = Convert.ToBase64String(ciphertext);

string Decrypt(byte[] ciphertext, byte[] nonce, byte[] tag, byte[] key)
{
    using (var aes = new AesGcm(key))
    {
        var plaintextBytes = new byte[ciphertext.Length];
        
        aes.Decrypt(nonce, ciphertext, tag, plaintextBytes);

        return Encoding.UTF8.GetString(plaintextBytes);
    }
}

Console.WriteLine(b64String);
Console.WriteLine(Decrypt(ciphertext, nonce, tag, key));