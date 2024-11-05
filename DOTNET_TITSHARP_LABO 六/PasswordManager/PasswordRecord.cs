using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_TITSHARP_LABO_六.PasswordManager
{
    public class PasswordRecord
    {
        public string Label { get; }
        public string EncryptedPassword { get; }

        public PasswordRecord(string label, string encryptedPassword)
        {
            Label = label;
            EncryptedPassword = encryptedPassword;
        }
    }

}
