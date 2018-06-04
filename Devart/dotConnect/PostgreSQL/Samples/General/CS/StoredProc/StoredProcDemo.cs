using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for StoredProcDemo.
  /// </summary>
  public class StoredProcDemo : Demo
  {
    const string descriptionShort = "This sample project demonstrates how to execute a stored procedure and view modified data.";
    const string descriptionFull = @"This sample project demonstrates how to execute a stored procedure and view modified data. 
      Before running the sample, create two procedures by clicking the 'Execute' button from 'Create SQL' tab page.
      When procedures are ready, you can insert or update data in the 'Dept' table. The demo contains two PgSqlCommand objects.
      One PgSqlCommand has CommandType set to StoredProcedure and serves for adding and editing rows in the table. 
      Another PgSqlCommand object is used to retrieve data from the table. After you finish with the sample you can remove 
      procedures from the database on the 'Drop SQL' tab. <P></P> <P></P> <B>Note:</B> the script to create the stored procedures is located in the DDL tab.";

    public StoredProcDemo() 
      : base("StoredProc", descriptionShort, descriptionFull, "Samples.StoredProc.StoredProc.bmp") {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new StoredProcDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

    public override string CreateSql {
      get {
        return @"CREATE FUNCTION Dept_Insert(IN INT,IN VARCHAR(14),IN VARCHAR(13))
RETURNS VOID AS $$ 
INSERT INTO Dept(DeptNo, DName, Loc) VALUES($1, $2, $3); 
$$ LANGUAGE SQL;
/
CREATE FUNCTION Dept_Update(IN INT,IN VARCHAR(14),IN VARCHAR(13))
RETURNS VOID AS $$ 
UPDATE Dept SET DName = $2, Loc = $3 WHERE DeptNo = $1;
$$ LANGUAGE SQL;
";
      }
    }

    public override string DropSql {
      get {
        return @"DROP FUNCTION Dept_Insert(IN INT,IN VARCHAR(14),IN VARCHAR(13));
DROP FUNCTION Dept_Update(IN INT,IN VARCHAR(14),IN VARCHAR(13));";
      }
    }
  }
}
