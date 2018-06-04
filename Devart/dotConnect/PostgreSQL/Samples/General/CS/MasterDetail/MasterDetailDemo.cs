using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for MasterDetailDemo.
  /// </summary>
  public class MasterDetailDemo : Demo
  {
    const string descriptionShort = "This sample project demonstrates setting master-detail relation in an untyped dataset. The sample fills two tables in a dataset using PgSqlDataAdapter and sets master-detail relation between them.";
    const string descriptionFull = @"This sample project demonstrates setting master-detail relation in an untyped dataset. The sample fills two tables in a dataset using two PgSqlDataAdapters and sets master-detail relation between them. For successfull Select/Update commands PgSqlDataAdapter requires PgSqlCommandBuilder and PgSqlCommand with a valid PgSqlConnection. After DataSet is filled, you can navigate in the top DataGrid, which shows the parent table Dept, and see rows of the child table Emp in the bottom DataGrid.";

    public MasterDetailDemo()
      : base("MasterDetail", descriptionShort, descriptionFull, "Samples.MasterDetail.MasterDetail.bmp") {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new MasterDetailDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }
  }
}
