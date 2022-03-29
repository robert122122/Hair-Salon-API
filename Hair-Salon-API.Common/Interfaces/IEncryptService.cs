using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Common.Interfaces
{
    public interface IEncryptService
    {
        string Encrypt(string encryptText);
        string GetSalt();
    }
}
