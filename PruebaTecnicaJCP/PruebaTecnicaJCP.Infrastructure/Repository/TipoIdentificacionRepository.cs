using Dapper;
using HospitalPatients.Infraestructure.Data;
using PruebaTecnicaJCP.Application.DTOs;
using PruebaTecnicaJCP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Infrastructure.Repository;

public class TipoIdentificacionRepository : ITipoIdentificacionRepository
{

    private readonly IDbConnectionFactory _dbConnectionFactory;

    public TipoIdentificacionRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<TipoIdentificacionResponseDTO>> GetTipoIdentificacion()
    {
        using var connection= _dbConnectionFactory.CreateConnection();
        var command = new CommandDefinition(
                "sp_tipo_Identificacion",
                commandType:System.Data.CommandType.StoredProcedure);

        return await connection.QueryAsync<TipoIdentificacionResponseDTO>(command);
    }

    

    public async Task<TipoIdentificacionResponseDTO?> ObtenerTipoIdentificacionAsync(int id)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        var command = new CommandDefinition(
            "sp_tipo_ObtenerId",
            new { TpoIdnId=id },
            commandType:System.Data.CommandType.StoredProcedure);

        return await connection.QueryFirstOrDefaultAsync<TipoIdentificacionResponseDTO>(command);
    }
}
