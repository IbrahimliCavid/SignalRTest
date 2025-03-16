using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Security
{
    public interface  IAESService
    {
        public string Encrypt(string plainText);
        public string Decrypt(string cipherText);
    }
}
