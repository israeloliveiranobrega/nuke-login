using NukeLogin.Src.Domain.Models.Base.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Domain.Models.ValueObjects.Base.Exceptions;
public class UnderageException : DomainException
{
    public UnderageException() : base("O usuário deve ser maior de idade.") { }
}
public class OveragedException : DomainException
{
    public OveragedException() : base("A idade do usuário é inválida.") { }
}
