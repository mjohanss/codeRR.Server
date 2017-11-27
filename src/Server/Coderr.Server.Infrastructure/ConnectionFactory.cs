#if NET452
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace codeRR.Server.Infrastructure
{
    /// <summary>
    ///     Generates SQL connections
    /// </summary>
    public class DbConnectionFactory
    {
        /// <summary>
        ///     Opens a connection
        /// </summary>
        /// <returns>open connection</returns>
        public static IDbConnection Open(ConnectionStringSettings connectionString, bool throwIfMissing)
        {
            //var conStr = ConfigurationManager.ConnectionStrings[connectionStringName];
            //if (conStr == null)
            //{
            //    if (throwIfMissing)
            //        throw new ConfigurationErrorsException(
            //            $"Expected a <connectionString> named '{connectionStringName}' in web.config");
            //    return null;
            //}

            var provider = DbProviderFactories.GetFactory(connectionString.ProviderName);
            if (provider == null)
                throw new ConfigurationErrorsException(
                    $"Sql provider '{connectionString.ProviderName}' was not found/registered.");

            var connection = provider.CreateConnection();
            connection.ConnectionString = connectionString.ConnectionString + ";connect timeout=22;";
            try
            {
                connection.Open();
            }
            catch (DataException ex)
            {
                throw new DataException(
                    $"Failed to connect to '{connectionString.ConnectionString}'. See inner exception for the reason.", ex);
            }

            return connection;
        }
    }
}
#endif