using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Domain.Entities;

public class Pais
{
    public short PaisCodigo { get; set; }
    public string PaisNombre { get; set; } = null!;
}