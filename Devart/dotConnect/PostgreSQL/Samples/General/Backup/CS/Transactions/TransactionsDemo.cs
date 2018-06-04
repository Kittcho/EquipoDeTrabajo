using System;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for TransactionsDemo.
  /// </summary>
  public class TransactionsDemo : Demo
  {
    const string descriptionShort = "This sample project demonstrates working with PostgresSQL transactions in dotConnect for PostgresSQL. The sample demonstrates how to get a PgSqlTransaction object from a PgSqlConnection object, how to commit or rollback a transaction.";
    const string descriptionFull = "This sample project demonstrates working with PostgresSQL transactions in dotConnect for PostgresSQL. The sample demonstrates how to get a PgSqlTransaction object from a PgSqlConnection object, how to commit or rollback a transaction.";

    public TransactionsDemo() 
      : base("Transactions", descriptionShort, descriptionFull) {
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection){

      return new TransactionsDemoControl((Devart.Data.PostgreSql.PgSqlConnection)connection);
    }

  }
}
