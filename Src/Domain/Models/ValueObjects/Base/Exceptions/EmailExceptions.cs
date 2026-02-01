using NukeLogin.Src.Domain.Models.Base.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Domain.Models.ValueObjects.Base.Exceptions;

public class InvalidEmailFormatExceptions : DomainException
{
    public InvalidEmailFormatExceptions() : base("O formato do email é inválido.") { }
}
