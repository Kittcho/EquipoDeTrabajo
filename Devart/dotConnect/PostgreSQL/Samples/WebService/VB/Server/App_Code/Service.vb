Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Configuration
Imports Devart.Data.PostgreSql

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Service
  Inherits System.Web.Services.WebService

  Private dataSet As DataSet = New DataSet
  Private connection As PgSqlConnection
  Private dataAdapter As PgSqlDataAdapter

  <WebMethod()> _
  Public Function FetchData(ByVal query As String) As System.Data.DataSet
    Me.connection = New PgSqlConnection(ConfigurationManager.ConnectionStrings("ProviderService").ConnectionString)
    Me.dataAdapter = New PgSqlDataAdapter("", Me.connection)

    Select Case Query
      Case "all employees"
        dataAdapter.SelectCommand.CommandText = "select * from emp"
      Case "all departments"
        dataAdapter.SelectCommand.CommandText = "select * from dept"
      Case "employees having commission"
        dataAdapter.SelectCommand.CommandText = "select * from emp where comm > 0"
      Case "average salary by departments"
        dataAdapter.SelectCommand.CommandText = "select dname as department, avg(sal) as average_salary from dept, emp where dept.deptno=emp.deptno group by dname"
      Case "employees' hire by years"
        dataAdapter.SelectCommand.CommandText = "select to_char(hiredate, 'YYYY') as year, count(empno) as quantity from emp group by 1 order by 1"
      Case "employees' number by departments"
        dataAdapter.SelectCommand.CommandText = "select dname, count(empno) from dept left join emp on dept.deptno = emp.deptno group by dname"
      Case "employees having no subordinates"
        dataAdapter.SelectCommand.CommandText = "select * from emp except select * from emp where empno in (select mgr from emp)"
      Case "employees having subordinates and manager"
        dataAdapter.SelectCommand.CommandText = "select * from emp where (mgr is not null) and (empno in (select distinct mgr from emp))"
      Case "employees with minimal salary by departments"
        dataAdapter.SelectCommand.CommandText = "select dname, ename, sal from dept, emp where sal = (select min(sal) from emp where dept.deptno = emp.deptno)"
      Case "seniority-salary trend"
        dataAdapter.SelectCommand.CommandText = "select to_number(to_char(CURRENT_TIMESTAMP, 'YYYY'), 'S9999')-to_number(to_char(hiredate, 'YYYY'), 'S9999') as seniority, avg(sal) as average_salary from emp group by 1 order by 1"
    End Select

    dataAdapter.Fill(dataSet)

    Return dataSet
  End Function

End Class
