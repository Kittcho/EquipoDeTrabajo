using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for PicturesDemo.
  /// </summary>
  public class PicturesDemo : Demo
  {
    const string descriptionShort = "This sample project demonstrates using dotConnect for PostgresSQL for working with BLOB objects as graphics. The sample demonstrates how to retrieve binary data from PostgresSQL database and display it at the monitor, load and save pictures into the file and the database.";
    const string descriptionFull = @"This sample project demonstrates using dotConnect for PostgresSQL for working with BLOB objects as graphics. The sample demonstrates how to retrieve binary data from PostgresSQL database and display it at the monitor, load and save pictures into the file and the database.";

    public PicturesDemo() 
      : base("Pictures", descriptionShort, descriptionFull) {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new PicturesDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

    public override string CreateSql {
      get {
        return @"CREATE TABLE pgsqlnet_pictures (
  UID SERIAL PRIMARY KEY,
  NAME VARCHAR(50),
  PICTURE BYTEA
);";
      }
    }

    public override string DropSql {
      get {
        return @"DROP TABLE pgsqlnet_pictures;";
      }
    }
  }
}
