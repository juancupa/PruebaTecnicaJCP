using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.DTOs;

public record CreateClienteRequest(

    short ClnTpoIdnId,
    string ClnNumeroIdentificacion,
    string ClRazonSocial,
    short ClnPaisCodigo,
    int lnDptColcodigoDane,
    int ClnDvsPltColCodigoDane
    );


