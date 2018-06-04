using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for MetaDataDemo.
  /// </summary>
  public class MetaDataDemo : Demo
  {
    const string descriptionShort = @"This sample project shows how to retrieve information about databases, tables, 
columns, users, and so on. The only method used for these tasks is <b>GetSchema</b>.";

    const string descriptionFull = @"<P>This sample project shows how to retrieve information about databases, tables,
columns, users, and so on. The only method used for these tasks is <B>GetSchema</B>.
<P>At the TreeView the results of calling GetSchema() without parameters are shown.
This list represents keywords allowed to be passed to the method as first 
parameter, or types of PostgresSQL's objects. After some node is 
selected, DataGrid displays the collection returned by GetSchema('selected 
node'). In the PropertyGrid there are restrictions list for selected object. You 
can assign any restrictions and click the 'Refresh' button. For example, specify 
only Owner = sys for Tables and click 'Refresh' to see all tables of the user sys in the DataGrid.</P>";

    public MetaDataDemo() 
      : base("MetaData", descriptionShort, descriptionFull) {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new MetaDataDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

  }
}
