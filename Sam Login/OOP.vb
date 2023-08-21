Public Class OOP
    Public Class Employee
        Private employeeId As Integer
        Private employeeName As String
        Private employeeSalary As Decimal

        Public Property Id As Integer
            Get
                Return employeeId
            End Get
            Set(ByVal value As Integer)
                employeeId = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return employeeName
            End Get
            Set(ByVal value As String)
                employeeName = value
            End Set
        End Property

        Public Property Salary As Decimal
            Get
                Return employeeSalary
            End Get
            Set(ByVal value As Decimal)
                employeeSalary = value
            End Set
        End Property

        Public Sub DisplayInfo()
            Console.WriteLine("Employee ID: " & Id)
            Console.WriteLine("Employee Name: " & Name)
            Console.WriteLine("Employee Salary: " & Salary)
        End Sub
    End Class

    Public Class Program
        Public Shared Sub Main()
            Dim emp As New Employee()
            emp.Id = 1
            emp.Name = "John Doe"
            emp.Salary = 5000
            emp.DisplayInfo()
        End Sub
    End Class
End Class