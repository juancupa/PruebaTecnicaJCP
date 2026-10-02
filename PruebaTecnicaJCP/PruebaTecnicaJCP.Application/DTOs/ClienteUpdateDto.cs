using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Application.DTOs;

public class ClienteUpdateDto
{
    [Required]
    public short ClnTpoIdnId { get; set; }

    [Required]
    [StringLength(30)]
    public string ClnNumeroIdentificacion { get; set; } = null!;

    [Required]
    [StringLength(150)]
    public string ClRazonSocial { get; set; } = null!;

    [Required]
    public int ClnDvsPltColCodigoDane { get; set; }
}
