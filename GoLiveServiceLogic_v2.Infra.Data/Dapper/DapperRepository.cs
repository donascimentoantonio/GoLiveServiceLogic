using GoLiveServiceLogic_v2.Domain.Interfaces.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;

namespace GoLiveServiceLogic_v2.Infra.Data.Dapper
{
    public class DapperRepository : IDapperRepository
    {
        private readonly SqlConnection _instance;
        static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
        private readonly IConfiguration _configuration;

        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            if (_instance is null)
                _instance = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }


        public void ExecuteStoredProcedure(string pSql, object dynamicParameters)
        {
            _semaphoreSlim.Wait();
            try
            {
                _instance.Open();

                _instance.Execute(pSql, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
            finally
            {
                _instance.Close();
                _semaphoreSlim.Release();
            }
        }

        public T QueryFirstOrDefault<T>(string pSql, object dynamicParameters)
        {
            _semaphoreSlim.Wait();
            try
            {
                _instance.Open();

                return _instance.Query<T>(pSql, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            finally
            {
                _instance.Close();
                _semaphoreSlim.Release();
            }
        }

        public IEnumerable<T> Query<T>(string pSql, object dynamicParameters)
        {
            _semaphoreSlim.Wait();
            try
            {
                _instance.Open();

                return _instance.Query<T>(pSql, dynamicParameters, commandType: CommandType.StoredProcedure);
            }

            finally
            {
                _instance.Close();
                _semaphoreSlim.Release();
            }

        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType? commandType = CommandType.StoredProcedure)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                await _instance.OpenAsync();

                return await _instance.QueryAsync<T>(sql, param, commandType: commandType);
            }
            finally
            {
                _instance.Close();
                _semaphoreSlim.Release();
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CommandType? commandType = CommandType.StoredProcedure)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                return await _instance.QueryFirstOrDefaultAsync<T>(sql, param, commandType: commandType);
            }

            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = CommandType.StoredProcedure)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                return await _instance.ExecuteAsync(sql, param, commandType: commandType);
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async Task<int> ExecuteScalarAsync(string sql, object param = null, CommandType? commandType = CommandType.StoredProcedure)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                return await _instance.ExecuteScalarAsync<int>(sql, param, commandType: commandType);
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }
    }
}
