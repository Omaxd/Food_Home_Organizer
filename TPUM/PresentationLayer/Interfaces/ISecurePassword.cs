using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Interfaces
{
    public interface ISecurePassword
    {
        System.Security.SecureString Password { get; }
        string Login { get; }
    }
}
