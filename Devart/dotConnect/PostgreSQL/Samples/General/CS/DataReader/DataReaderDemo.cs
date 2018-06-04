using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for DataReaderDemo.
  /// </summary>
  public class DataReaderDemo : Demo
  {
    const string descriptionShort = "This sample project demonstrates using PgSqlDataReader class to obtain data from a query. The sample executes SQL statement at the PgSqlCommand and gets PgSqlDataReader to retrieve data.";

    const string descriptionFull = @"This sample project demonstrates using PgSqlDataReader class to obtain data from a query. The sample executes SQL statement at the PgSqlCommand and gets PgSqlDataReader to retrieve data.
You can retrieve data from any existing table or from several tables like 'SELECT Ename, Hiredate, Loc FROM Dept INNER JOIN Emp ON Emp.DeptNo = Dept.DeptNo'. Just write the correct SQL query at the top area and click 'Execute' button.";

    public DataReaderDemo() 
      : base("DataReader", descriptionShort, descriptionFull) {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new DataReaderDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

  }
}
