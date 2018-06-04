using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for CrystalDemo.
  /// </summary>
  public class CrystalDemo : Demo
  {
    const string descriptionShort = "This sample project demonstrates using dotConnect for PostgresSQL for generating reports with Crystal Report.";
    const string descriptionFull = @"This sample project demonstrates using dotConnect for PostgresSQL for generating reports with Crystal Report.";

    public CrystalDemo() 
      : base("Crystal", descriptionShort, descriptionFull, "Samples.Crystal.Crystal.bmp") {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new CrystalDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

  }
}
