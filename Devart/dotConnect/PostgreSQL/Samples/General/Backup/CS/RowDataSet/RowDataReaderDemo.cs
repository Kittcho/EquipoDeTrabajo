using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for RowDataSetDemo.
  /// </summary>
  public class RowDataSetDemo : Demo
  {
    const string descriptionShort = "This sample project demonstrates using dataset with dotConnect for PostgreSQL to review and update composite type values. The sample uses PgSqlDataAdapter to fill a dataset and post updated data to PostrgeSQL database. PgSqlDataAdapter uses PgSqlCommandBuilder class to automatically generate SQL for INSERT/UPDATE/DELETE operations.";
    const string descriptionFull = @"This sample project demonstrates using dataset with dotConnect for PostgreSQL to review and update composite type values. The sample uses PgSqlDataAdapter to fill a dataset and post updated data to PostrgeSQL database. PgSqlDataAdapter uses PgSqlCommandBuilder class to automatically generate SQL for INSERT/UPDATE/DELETE operations.";

    public RowDataSetDemo() 
      : base("RowDataSet", descriptionShort, descriptionFull) {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new RowDataSetDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

    public override string CreateSql {
      get {
        return @"CREATE TABLE dept_container (
  id INT4,
  f_dept DEPT
);

INSERT INTO dept_container VALUES (1, '(10,N a m e,location)')";
      }
    }

    public override string DropSql {
      get {
        return @"DROP TABLE dept_container CASCADE";
      }
    }
  }
}
