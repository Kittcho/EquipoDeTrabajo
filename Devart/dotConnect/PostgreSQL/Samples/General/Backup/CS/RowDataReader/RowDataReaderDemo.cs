using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for RowDataReaderDemo.
  /// </summary>
  public class RowDataReaderDemo : Demo
  {
    const string descriptionShort = "This sample project demonstrates using PgSqlDataReader class to obtain composite type values. The sample executes SQL statement at the PgSqlCommand and gets PgSqlDataReader to retrieve data.";
    const string descriptionFull = @"This sample project demonstrates using PgSqlDataReader class to obtain composite type values. The sample executes SQL statement at the PgSqlCommand and gets PgSqlDataReader to retrieve data.";

    public RowDataReaderDemo() 
      : base("RowDataReader", descriptionShort, descriptionFull) {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new RowDataReaderDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

    public override string CreateSql {
      get {
        return @"CREATE TABLE dept_container(
  id int4,
  f_dept dept
);

INSERT INTO dept_container VALUES(1, '(10,N a m e,location)')";
      }
    }

    public override string DropSql {
      get {
        return @"DROP TABLE dept_container CASCADE";
      }
    }
  }
}
