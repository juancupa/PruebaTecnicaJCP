using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.DTOs;

public class ClienteResponseDto
{
    public int Clnid { get; set; }

    public short ClnTpoIdnId { get; set; }

    public string ClnNumeroIdentificacion { get; set; } = null!;

    public string ClRazonSocial { get; set; } = null!;

   // public short PaisCodigo { get; set; }

    public string PaisNombre { get; set; } = null!;

    //public int DptColCodigoDane { get; set; }

    public string DptColNombredelDepartamento { get; set; } = null!;

    //public int DvsPltColCodigoDane { get; set; }

    public string DvsPltColNombreMunicipio { get; set; } = null!;
}
