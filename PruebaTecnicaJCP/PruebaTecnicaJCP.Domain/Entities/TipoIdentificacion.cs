using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Domain.Entities;

public class TipoIdentificacion
{
    public int TpoIdnId { get; set; }
    public string TpoIdnCodigo { get; set; } = string.Empty;
    public string TpoIdnNombre { get; set; } = string.Empty;
}
