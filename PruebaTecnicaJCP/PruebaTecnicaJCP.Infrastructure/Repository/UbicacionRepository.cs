using Dapper;
using HospitalPatients.Infraestructure.Data;
using PruebaTecnicaJCP.Application.DTOs;
using PruebaTecnicaJCP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Infrastructure.Repository;

public class UbicacionRepository : IUbicacionRepository
{


    private readonly IDbConnectionFactory _dbConnectionFactory;

    public UbicacionRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }



    public async Task<IEnumerable<DepartamentoDto>> ObtenerDepartamentosAsync(short paisCodigo)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        return await connection.QueryAsync<DepartamentoDto>(
            "sp_ObtenerDepartamentosPorPais",
            new { PaisCodigo = paisCodigo },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<MunicipioDto>> ObtenerMunicipiosAsync(int departamentoCodigo)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        return await connection.QueryAsync<MunicipioDto>(
            "sp_ObtenerMunicipiosPorDepartamento",
            new { DptColCodigoDane= departamentoCodigo },
            commandType:CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<PaisDto>> ObtenerPaisesAsync()
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        return await connection.QueryAsync<PaisDto>(
            "sp_ObtenerPaises",
            commandType: CommandType.StoredProcedure);
    }
}
