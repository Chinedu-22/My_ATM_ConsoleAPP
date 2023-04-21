//Declaration
double myBalance = 3500;
int myPIN = 4569;
int numberOfTrial = 3;
        
Console.WriteLine("Choose what you want do:");
Console.WriteLine("Type 1 if you want to see your account balance");
Console.WriteLine("Type 2 if you want to withdraw money");
Console.WriteLine("Type 3 if you want to change your PIN");

List<int> choices = new List<int>() { 1,2,3}; // Creation of integer list

int value; //Declaration of userinput and value
string userInput = Console.ReadLine(); // Console.ReadLine() allows userinput to be displayed
while (!int.TryParse(userInput, out value) || !choices.Contains(value)) // ! is used to negate a function
{
    Console.WriteLine("Please enter a number 1 or 2 or 3");
    userInput = Console.ReadLine();
}

Console.WriteLine($"You just entered the value: \'{value}\'"); // \ allows only the variable to be in quote

if (value == 1)
{

    Console.WriteLine($"Your balance = {myBalance}"); // {} displays the value of a vriable
}else if (value == 2)
{
    Console.WriteLine($"How much do you want to withdraw?");
    double suggestion = checkInputDouble();


    if (suggestion > myBalance)
    {
        Console.WriteLine("Insufficient balance");
    }else // Suggestion <= mybalance
    {
        Console.WriteLine("Please enter you PIN:");
        int userPIN = checkInputInt();
        numberOfTrial = numberOfTrial - 1;
        while (numberOfTrial > 0 && userPIN != myPIN)
        {
            Console.WriteLine($"Sorry wrong PIN. You have only: {numberOfTrial} trial left");
            Console.WriteLine("Please enter a number:");
            userPIN = checkInputInt();
            numberOfTrial--;//This is the same as writing numberOfTrial = numberOfTrial - 1
   
        }

        if (userPIN == myPIN)
        {
            Console.WriteLine("Please take your money");
            Console.WriteLine("Withdrawal Successful");
            double currentBalance = myBalance - suggestion;
            Console.WriteLine($"My currentBalance is: {currentBalance}");

            // $ sign allows you to use a variable as a value inside a string
        }
        else
        {
            Console.WriteLine("Incorrect PIN. GOODBYE");
        }
       
    }
}else if (value == 3)
{
    Console.WriteLine("Please enter your old PIN:");
    int oldPIN = checkInputInt();
    numberOfTrial = numberOfTrial - 1;
    while (numberOfTrial > 0 && oldPIN != myPIN)
    {
        Console.WriteLine($"Sorry wrong PIN. You have only:  {numberOfTrial} trial left");
        Console.WriteLine("Please enter a number:");
        oldPIN = checkInputInt();
        numberOfTrial--;
        //TODO: allow same number of trial as we did in value = 2
    }
    if (oldPIN == myPIN)
    {
        Console.WriteLine("Please enter your new PIN");
        string userNewPIN = Console.ReadLine();
        Console.WriteLine("Please confirm your new PIN");
        string userNewPIN2 = Console.ReadLine();
        if(userNewPIN == userNewPIN2)
        {
            Console.WriteLine("New PIN changed successfuly");
        }
        else
        {
            Console.WriteLine("PIN does not match");
        }
    }
    else
    {
        Console.WriteLine("Incorrect PIN. GOODBYE");
    }
}

Console.WriteLine("done");

Console.ReadKey();






int checkInputInt()
{
    string oldPinString = Console.ReadLine();
    int oldPIN;
    while (!int.TryParse(oldPinString, out oldPIN))
    {
        Console.WriteLine("Please enter a number");
        oldPinString = Console.ReadLine();
    }
    return oldPIN;
}


double checkInputDouble()
{
    string oldPinString = Console.ReadLine();
    double oldPIN;
    while (!double.TryParse(oldPinString, out oldPIN))
    {
        Console.WriteLine("Please enter a number");
        oldPinString = Console.ReadLine();
    }
    return oldPIN;
}
