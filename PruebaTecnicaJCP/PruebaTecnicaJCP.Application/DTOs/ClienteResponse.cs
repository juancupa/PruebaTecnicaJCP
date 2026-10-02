using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.DTOs;

public record ClienteResponse(

     int Clnid,
     short ClnTpoIdnId,
     string ClnNumeroIdentificacion,
     string ClRazonSocial,
     string DptColNombredelDepartamento,
     string DvsPltColNombreMunicipio
    );



