using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for DataSetDemo.
  /// </summary>
  public class DataSetDemo : Demo
  {
    const string descriptionShort = "This sample project demonstrates using untyped dataset with dotConnect for PostgresSQL to review and update data. The sample uses PgSqlDataAdapter to fill a dataset and post updated data to PostgresSQL database. PgSqlDataAdapter uses PgSqlCommandBuilder class to automatically generate SQL queries for INSERT/UPDATE/DELETE operations.";
    const string descriptionFull = @"This sample project demonstrates using untyped dataset with dotConnect for PostgresSQL to review and update data. The sample uses PgSqlDataAdapter to fill a dataset and post updated data to PostgresSQL database. PgSqlDataAdapter uses PgSqlCommandBuilder class to automatically generate SQL queries for INSERT/UPDATE/DELETE operations.";

    public DataSetDemo() 
      : base("DataSet", descriptionShort, descriptionFull, "Samples.DataSet.DataSet.bmp") {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new DataSetDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

  }
}
