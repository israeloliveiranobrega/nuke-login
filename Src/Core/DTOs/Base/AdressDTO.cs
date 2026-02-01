using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Core.DTOs.Base;
public record AdressDTO
{
    public string PostalCode { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}

