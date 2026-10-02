using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.DTOs;

public record UpdateClienteRequest(
    
    int ClnTpoIdnId,
    string ClnNumeroIdentificacion,
    string ClRazonSocial,
    int ClnPaisCodigo,
    int ClnDptColcodigoDane,
    int ClnDvsPltColCodigoDane
    );


