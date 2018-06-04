using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for TableDemo.
  /// </summary>
  public class TableDemo : Demo
  {
    const string descriptionShort = "This sample project demonstrates data mapping from PostgresSQL tables. The sample sets CommandType property of PgSqlCommand to TableDirect to access data from the table.";
    const string descriptionFull = "This sample project demonstrates data mapping from PostgresSQL tables. The sample sets CommandType property of PgSqlCommand to TableDirect to access data from the table.";

    public TableDemo() 
      : base("Table", descriptionShort, descriptionFull) {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new TableDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

  }
}
