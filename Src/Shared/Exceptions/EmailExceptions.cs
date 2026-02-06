using NukeLogin.Src.Shared.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Shared.Exceptions;

public class InvalidEmailFormatExceptions : DomainException
{
    public InvalidEmailFormatExceptions() : base("O formato do email é inválido.") { }
}
