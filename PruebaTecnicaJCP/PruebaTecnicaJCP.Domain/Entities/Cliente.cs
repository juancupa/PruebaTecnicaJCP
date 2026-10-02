using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Domain.Entities;

public class Cliente
{

   // public int Clnid { get; set; }
    public short ClnTpoIdnId { get; set; }
    public string ClnNumeroIdentificacion { get; set; } = null!;
    public string ClRazonSocial { get; set; } = null!;
    public int ClnDvsPltColCodigoDane { get; set; }



}
