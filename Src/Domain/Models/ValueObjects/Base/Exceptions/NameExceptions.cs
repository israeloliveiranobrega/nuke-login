using NukeLogin.Src.Domain.Models.Base.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Domain.Models.ValueObjects.Base.Exceptions;
public class InvalidNameLengthExceptions : DomainException
{
    public InvalidNameLengthExceptions(string str) : base ($"O {str} deve conter no mínimo 3 caracteres.") { }
}
public class InvalidNameCharacterExceptions : DomainException
{
    public InvalidNameCharacterExceptions(string str) : base ($"O {str} deve conter apenas letras.") { }
}
