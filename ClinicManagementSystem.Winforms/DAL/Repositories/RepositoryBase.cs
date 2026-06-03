using Microsoft.Data.SqlClient;
using DAL.DataContext;

namespace DAL.Repositories
{
	public abstract class RepositoryBase
	{
		protected SqlConnection GetConnection()
		{
			return DbConnectionFactory.CreateConnection();
		}
	}
}
