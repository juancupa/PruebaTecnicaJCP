using Dapper;
using HospitalPatients.Infraestructure.Data;
using PruebaTecnicaJCP.Application.DTOs;
using PruebaTecnicaJCP.Application.Interfaces;
using PruebaTecnicaJCP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaJCP.Infrastructure.Repository;

public class ClienteRepository : IClienteRepository
{

    private readonly IDbConnectionFactory _dbConnectionFactory;

    public ClienteRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<bool> ActualizarAsync(int id, ClienteUpdateDto cliente)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@ClnTpoIdnId", cliente.ClnTpoIdnId);
        parameters.Add("@ClnNumeroIdentificacion", cliente.ClnNumeroIdentificacion);
        parameters.Add("@ClRazonSocial", cliente.ClRazonSocial);
        parameters.Add("@ClnDvsPltColCodigoDane", cliente.ClnDvsPltColCodigoDane);

        var result = await connection.QueryFirstOrDefaultAsync<int>(
           "dbo.sp_ActualizarCliente",
           parameters,
           commandType: CommandType.StoredProcedure);

        return result == 1;
    }

    public async Task<int> CrearAsync(ClienteCreateDto cliente)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@ClnTpoIdnId", cliente.ClnTpoIdnId);
        parameters.Add("@ClnNumeroIdentificacion", cliente.ClnNumeroIdentificacion);
        parameters.Add("@ClRazonSocial", cliente.ClRazonSocial);
        parameters.Add("@ClnDvsPltColCodigoDane", cliente.ClnDvsPltColCodigoDane);

        return await connection.ExecuteScalarAsync<int>(
                "dbo.sp_CrearCliente",
                parameters,
                commandType: CommandType.StoredProcedure
            );

    }

    /*public async Task CreateClienteAsync(Cliente cliente)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        var parameters = new DynamicParameters();

        parameters.Add("@ClnTpoIdnId", cliente.ClnTpoIdnId);
        parameters.Add("@@ClnNumeroIdentificacion", cliente.ClnNumeroIdentificacion);
        parameters.Add("@@ClRazonSocial", cliente.ClRazonSocial);
        parameters.Add("@@ClnPaisCodigo", cliente.ClnPaisCodigo);
        parameters.Add("@@ClnDptColcodigoDane", cliente.ClnDptColcodigoDane);
        parameters.Add("@@ClnDvsPltColCodigoDane", cliente.ClnDvsPltColCodigoDane);

        var commando = new CommandDefinition(
            "sp_crear_cliente",
            parameters,
            commandType:System.Data.CommandType.StoredProcedure);

        await connection.ExecuteAsync(commando);
        
    }*/

    public async Task DeleteAsync(int id)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        var command = new CommandDefinition(
                "sp_elimnar_cliente",
                new { ClnNumeroIdentificacion = id },
                commandType: System.Data.CommandType.StoredProcedure);
        await connection.ExecuteAsync(command);

    }

    /*public async Task<IEnumerable<ClienteResponse>> GetAllAsync()
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        var command = new CommandDefinition(
                "sp_obtener_Todos_Cliente",
                commandType: System.Data.CommandType.StoredProcedure);

        return await connection.QueryAsync<ClienteResponse>(command);
    }*/

    /*public async Task<ClienteResponse?> GetByIdentificacionAsync(int id)
    {
        using var connection= _dbConnectionFactory.CreateConnection();
        var command = new CommandDefinition(
            "sp_obtenerID_Cliente",
            new { ClnNumeroIdentificacion= id},
            commandType:System.Data.CommandType.StoredProcedure );
        return await connection.QueryFirstOrDefaultAsync<ClienteResponse>(command);
    }*/

    public async Task<ClienteResponseDto?> ObtenerPorIdAsync(int id)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<ClienteResponseDto>(
          "dbo.sp_ObtenerClientePorId",
          new { ClnNumeroIdentificacion = id },
          commandType: CommandType.StoredProcedure);

    }

    public async Task<IEnumerable<ClienteResponseDto>> ObtenerTodosAsync()
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        return await connection.QueryAsync<ClienteResponseDto>(
       "dbo.sp_ObtenerClientes",
       commandType: CommandType.StoredProcedure);
    }

    /*public Task<bool> UpdateAsync(UpdateClienteRequest request)
    {
        throw new NotImplementedException();
    }*/
}
