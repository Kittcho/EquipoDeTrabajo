using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for RefCursorDemo.
  /// </summary>
  public class RefCursorDemo : Demo
  {
    const string descriptionShort = @"This sample project demonstrates using REF CURSOR type in dotConnect for PostgreSQL.";
    const string descriptionFull = @"This sample project demonstrates using REF CURSOR type in dotConnect for PostgreSQL.
Notice that CURSOR is accessible only in a transaction.";

    public RefCursorDemo() 
      : base("RefCursor", descriptionShort, descriptionFull) {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new RefCursorDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

    public override string CreateSql {
      get {
        return @"CREATE FUNCTION getDeptCursor(refcursor) RETURNS refcursor
    AS '
BEGIN
  OPEN $1 FOR SELECT * from dept;

  RETURN $1;
END;'
LANGUAGE plpgsql;";
      }
    }

    public override string DropSql {
      get {
        return @"DROP FUNCTION getDeptCursor(refcursor);";
      }
    }
  }
}
