using System.Data;

namespace GoLiveServiceLogic_v2.Domain.Interfaces.Base
{
    public interface IDapperRepository
    {
        Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = CommandType.StoredProcedure);
        void ExecuteStoredProcedure(string pSql, object dynamicParameters);
        IEnumerable<T> Query<T>(string pSql, object dynamicParameters);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType? commandType = CommandType.StoredProcedure);
        T QueryFirstOrDefault<T>(string pSql, object dynamicParameters);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CommandType? commandType = CommandType.StoredProcedure);
        Task<int> ExecuteScalarAsync(string sql, object param = null, CommandType? commandType = CommandType.StoredProcedure);
    }
}
