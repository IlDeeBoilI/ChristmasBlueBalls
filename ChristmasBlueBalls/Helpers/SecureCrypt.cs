using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

public class SecureCrypt
{
    public string EncryptPassword(string plainPassword)
    {
        return Crypto.HashPassword(plainPassword);
    }

    public bool VerifyPassword(string plainPassword, string CryptPass)
    {
        return Crypto.VerifyHashedPassword(CryptPass, plainPassword);
    }
}
