using System;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.Services;
using System.Web.Services.Protocols;
using Devart.Data.PostgreSql;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService {
  private PgSqlConnection connection = null;
  private PgSqlDataAdapter dataAdapter = null;
  private DataSet dataSet = new DataSet();

  public Service() {
    //Uncomment the following line if using designed components 
    //InitializeComponent(); 
  }

  [WebMethod]
  public DataSet FetchData(string Query) {
    try {
      connection = new PgSqlConnection(ConfigurationManager.ConnectionStrings["ProviderService"].ConnectionString);
      dataAdapter = new PgSqlDataAdapter("", connection);
      switch (Query) {
        case "all employees":
          dataAdapter.SelectCommand.CommandText = "SELECT * FROM emp";
          break;
        case "all departments":
          dataAdapter.SelectCommand.CommandText = "SELECT * FROM dept";
          break;
        case "employees having commission":
          dataAdapter.SelectCommand.CommandText = "SELECT * FROM emp WHERE comm > 0";
          break;
        case "average salary by departments":
          dataAdapter.SelectCommand.CommandText = "SELECT dname AS department, AVG(sal) AS average_salary FROM dept, emp WHERE dept.deptno=emp.deptno GROUP BY dname";
          break;
        case "employees' hire by years":
          dataAdapter.SelectCommand.CommandText = "SELECT TO_CHAR(hiredate, 'YYYY') AS year, COUNT(empno) AS quantity FROM emp GROUP BY 1 ORDER BY 1";
          break;
        case "employees' number by departments":
          dataAdapter.SelectCommand.CommandText = "SELECT dname, COUNT(empno) FROM dept LEFT JOIN emp ON dept.deptno = emp.deptno GROUP BY dname";
          break;
        case "employees having no subordinates":
          dataAdapter.SelectCommand.CommandText = "SELECT e1.* FROM emp e1 LEFT JOIN emp e2 ON e1.empno = e2.mgr WHERE e2.mgr IS NULL";
          break;
        case "employees having subordinates and manager":
          dataAdapter.SelectCommand.CommandText = "SELECT * FROM emp WHERE (mgr IS NOT NULL) AND (empno IN (SELECT DISTINCT mgr FROM emp))";
          break;
        case "employees with minimal salary by departments":
          dataAdapter.SelectCommand.CommandText = "SELECT dname, ename, sal FROM dept, emp WHERE sal = (SELECT MIN(sal) from emp WHERE dept.deptno = emp.deptno)";
          break;
        case "seniority-salary trend":
          dataAdapter.SelectCommand.CommandText = "SELECT TO_NUMBER(TO_CHAR(CURRENT_TIMESTAMP, 'YYYY'), 'S9999')-TO_NUMBER(TO_CHAR(hiredate, 'YYYY'), 'S9999') AS seniority, AVG(sal) AS average_salary FROM emp GROUP BY 1 ORDER BY 1";
          break;
        default:
          return null;
      }
      dataAdapter.Fill(dataSet);
    }
    catch (Exception ex) {
      throw new Exception(ex.Message);
    }
    finally {
      if (connection != null)
        connection.Close();
    }
    return dataSet;
  }
}