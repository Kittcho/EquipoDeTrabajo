using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for RowStoredProcDemo.
  /// </summary>
  public class RowStoredProcDemo : Demo
  {
    const string descriptionShort = "This sample project demonstrates execution of a stored procedure that uses a composite type value.";
    const string descriptionFull = @"This sample project demonstrates execution of a stored procedure that uses a composite type value.";

    public RowStoredProcDemo() 
      : base("RowStoredProc", descriptionShort, descriptionFull) {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new RowStoredProcDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

    public override string CreateSql {
      get {
        return @"CREATE OR REPLACE FUNCTION getdept(dept_container)
  RETURNS dept AS
'DECLARE
  dept_container Alias for $1;
  rc dept%ROWTYPE;
  BEGIN
  rc := $1.f_dept;
  return rc;
  END;
' LANGUAGE 'plpgsql' VOLATILE;";
      }
    }

    public override string DropSql {
      get {
        return @"DROP FUNCTION getdept(dept_container)";
      }
    }
  }
}
