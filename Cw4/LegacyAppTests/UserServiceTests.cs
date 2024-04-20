using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_Dot_And_At()
    {
        //Arrange
        string firstName = "Joe";
        string lastName = "Doe";
        DateTime dateOfBirth = new DateTime(1973, 2, 1);
        int clientId = 5;
        string email = "doe";
        var service = new UserService();

        //Act
        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Is_Null()
    {
        //Arrange
        string firstName = "";
        string lastName = "Doe";
        DateTime dateOfBirth = new DateTime(1973, 2, 1);
        int clientId = 5;
        string email = "doe@gmail.pl";
        var service = new UserService();

        //Act
        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Is_Null()
    {
        //Arrange
        string firstName = "Joe";
        string lastName = "";
        DateTime dateOfBirth = new DateTime(1973, 2, 1);
        int clientId = 5;
        string email = "doe@gmail.pl";
        var service = new UserService();

        //Act
        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Age_Is_Less_Than_21()
    {
        //Arrange
        string firstName = "Joe";
        string lastName = "Doe";
        DateTime dateOfBirth = new DateTime(2010, 2, 1);
        int clientId = 5;
        string email = "doe@gmail.pl";
        var service = new UserService();

        //Act
        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Data_Is_Correct()
    {
        //Arrange
        string firstName = "Joe";
        string lastName = "Doe";
        DateTime dateOfBirth = new DateTime(1999, 2, 1);
        int clientId = 5;
        string email = "doe@gmail.pl";
        var service = new UserService();

        //Act
        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        //Assert
        Assert.Equal(true, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_HasCreditLimit_And_CreditLimit_Is_Less_Than_500()
    {
        string firstName = "Jan";
        string lastName = "Kowalski";
        DateTime dateOfBirth = new DateTime(1999, 2, 1);
        int clientId = 1;
        string email = "doe@gmail.pl";
        var service = new UserService();
        
        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
        Assert.Equal(false,result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_VeryImportantClient()
    {
        string firstName = "Jan";
        string lastName = "Malewski";
        DateTime dateOfBirth = new DateTime(1999, 2, 1);
        int clientId = 1;
        string email = "doe@gmail.pl";
        var service = new UserService();
        
        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
        Assert.Equal(true,result);
    }

}