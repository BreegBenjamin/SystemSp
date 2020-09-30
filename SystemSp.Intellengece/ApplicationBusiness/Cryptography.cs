using System;
using System.Security.Cryptography;
using System.Text;

namespace SystemSp.Intellengece.ApplicationBusiness
{
    public class Cryptography
    {
        private readonly string _password = "passSystemSp";
        // Función para cifrar una cadena.
        public string Encrypt(string cadeEncriptar)
        {
            try
            {
                byte[] llave; //Arreglo donde guardaremos la llave para el cifrado 3DES.
                byte[] arreglo = UTF8Encoding.UTF8.GetBytes(cadeEncriptar); //Arreglo donde guardaremos la cadena descifrada.
                                                                            // Ciframos utilizando el Algoritmo MD5.
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_password));
                md5.Clear();
                //Ciframos utilizando el Algoritmo 3DES.
                TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
                tripledes.Key = llave;
                tripledes.Mode = CipherMode.ECB;
                tripledes.Padding = PaddingMode.PKCS7;
                ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
                byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
                tripledes.Clear();
                return Convert.ToBase64String(resultado, 0, resultado.Length); // Convertimos la cadena y la regresamos.
            }
            catch(Exception ex)
            {
               string message = $"Ocurrio una expeción al encriptar la cadena de entrada : {cadeEncriptar}";
               throw  new CryptographicException(message, ex.InnerException);
            }
        }
        // Función para descifrar una cadena.
        public string Decrypt(string cadenaDesencriptar)
        {
            try
            {
                byte[] llave;
                byte[] arreglo = Convert.FromBase64String(cadenaDesencriptar); // Arreglo donde guardaremos la cadena descovertida.
                                                                          // Ciframos utilizando el Algoritmo MD5.
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_password));
                md5.Clear();
                //Ciframos utilizando el Algoritmo 3DES.
                TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
                tripledes.Key = llave;
                tripledes.Mode = CipherMode.ECB;
                tripledes.Padding = PaddingMode.PKCS7;
                ICryptoTransform convertir = tripledes.CreateDecryptor();
                byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
                tripledes.Clear();
                string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtenemos la cadena
                return cadena_descifrada; // Devolvemos la cadena
            }
            catch (Exception ex)
            {
                string message = $"Ocurrio una expeción al encriptar la cadena de entrada : {cadenaDesencriptar}";
                throw new CryptographicException(message, ex.InnerException);
            }
        }
    }
}
