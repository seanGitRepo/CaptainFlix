//we are doing aggerate roots ?!? 


using CAptainFlix;
using System.Runtime.CompilerServices;

var company = new Company("CaptainFlix");
var theatre1 = company.AddTheatre("Events");
var theatre2 = company.AddTheatre("Hoyts");
//Data entry shennaigans ------------------------------------------------------------------------------------

//lets now try to load just the movies.

//borrowed from prior project https://github.com/seanGitRepo/aiToHuman.txt/blob/main/textApp/textStorage.cs
StreamReader movieTitles = new StreamReader($"../../../{company.TradingName}Data/movies.csv");
StreamReader movieTimes = new StreamReader($"../../../{company.TradingName}Data/times.csv");
StreamReader movieSessions = new StreamReader($"../../../{company.TradingName}Data/sessions.csv");

List<string> foundTitles = new List<string>();
string line; 
while((line = movieTitles.ReadLine())!= null)
{
    string[] split = line.Split(',');

    company.RegisterMovie(split[0], split[1], int.Parse(split[2]));

    //this now sucesfully registers the movies into the company

}

List<DateTime> foundTimes = new List<DateTime>();

while ((line = movieTimes.ReadLine()) != null)
{
    string[] split = line.Split(',');//not sure why it doesn't let me just int.parse the split entitty 
    List<int> ints = new List<int>();
    for (int i = 0; i < split.Length; i++)
    {
        int aaa = int.Parse(split[i]);
        ints.Add(aaa);

    }
    DateTime tempa = new DateTime(ints[0], ints[1], ints[2], ints[3], ints[4], ints[5], ints[6]);
    foundTimes.Add(tempa);

    //this now sucesfully registers the times into the program
}


Random random = new Random();
while ((line = movieSessions.ReadLine()) != null)
{
    int randomSelectT = random.Next(0,14);
    int randomSelectM = random.Next(0,3);
    if (line[4] == '1')
    {
        theatre1.ScheduleSession(line, foundTimes[randomSelectT], company.Movies[randomSelectM]);

    }
    else
    {
        theatre2.ScheduleSession(line, foundTimes[randomSelectT], company.Movies[randomSelectM]);

    }

}


//add the sessions 


// two theatres

// now a program generates seats for the following (our data entry)
for (char  row = 'A'; row <= 'G'; row++)
{
    for(int seatNumber = 0; seatNumber <= 10; seatNumber++)
    {

        theatre1.AddSeat(row, seatNumber);
        theatre2.AddSeat(row, seatNumber);
    }
    
}

//I could use the list of sessions in theatres here to create a new session when using the csv file.

var seat1 = theatre1.FindSeatByCode("A-4"); // this finds a seat and then makes seat1 that specific seat.
var seat2 = theatre1.FindSeatByCode("B-2");
var seat3 = theatre1.FindSeatByCode("C-5");
var seat4 = theatre1.FindSeatByCode("C-4");
var seat5 = theatre1.FindSeatByCode("C-2");
var seat6 = theatre1.FindSeatByCode("C-3");

int randomsessionSelection= random.Next(0, 6);

var ticketTest1 = theatre1.Sessions[randomsessionSelection].IssueTicket("Daniel", seat1);
 randomsessionSelection = random.Next(0, 6);
var ticketTest2 = theatre1.Sessions[randomsessionSelection].IssueTicket("Oliver", seat2);
 randomsessionSelection = random.Next(0, 6);
var ticketTest3 = theatre1.Sessions[randomsessionSelection].IssueTicket("Sean", seat3);
 randomsessionSelection = random.Next(0, 6);
var ticketTest4 = theatre1.Sessions[randomsessionSelection].IssueTicket("Saxon", seat4);
 randomsessionSelection = random.Next(0, 6);
var ticketTest5 = theatre1.Sessions[randomsessionSelection].IssueTicket("James", seat5);
 randomsessionSelection = random.Next(0, 6);
var ticketTest6 = theatre1.Sessions[randomsessionSelection].IssueTicket("George", seat6);


// ---------------------------------------------------------------------------------------------------------------


//I need a theatre selection first.
Console.WriteLine($"Welcome to {company.TradingName}'s!");
Console.WriteLine("Please start by selecting a Movie");

for (int i = 0; i < company.Movies.Count; i++)
{
    Console.WriteLine($"{i + 1}. {company.Movies[i].Title}");

}

var a = true;

int userSelection = -1;

while (a == true)
{//tests if the user input is valid.
    try
    {
        userSelection = int.Parse(Console.ReadLine()) - 1;
        Console.Clear(); //another chat gpt goodie that i asked <3
        Console.WriteLine(company.Movies[userSelection].Title);
        a = false;
    }
    catch
    {
        a = true;
        Console.WriteLine("Please select a valid movie");
    }

}

//makes my code easier to follow zzz
var chosenFilm = company.Movies[userSelection].Title; //hypothetically starwars

//now code that shows the avaliable sessuions for the list of films.


//I want to loop through the threates that are avaliable, show on the screen hoyts and event.

//there could be an application here where it takes inputs to display the screen
// so maybe a class that is purely for displaying stuff.
var chosenCinema = company.Theatres[0];//get by

    Console.WriteLine("Avaliable Sessions ");
    for (int i = 0; i < company.Theatres.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {company.Theatres[i].Name}");


    int current = company.Theatres.Count +1;

    for (int check = 0; check < company.Theatres.Count; check++)
    {
        if(company.Theatres[i].Name == company.Theatres[check].Name)
        {
            current = check;
        }

    }

         chosenCinema = company.Theatres[current]; // this line selects whatever cinema has been written on the console.
    //as I was having an issue of selecting the correct session times.
 
  

        int counter = 0;
    for (int j = 0; j < company.Theatres[i].Sessions.Count; j++)
    {

        //i need something that only selects the movies that i want. (which is userselection)
        //this code only prints the times for the one theatre. 
        if (chosenFilm.ToString() == chosenCinema.Sessions[j].Movie.Title) { 
            
                Console.WriteLine($"\t{counter + 1}.{chosenCinema.Sessions[j].StartDateTime}");
                counter++;
            }

        }


    }

//Now i need to select the time and the cinema. 


var b = true;
int userSelectionCinema = -1;

while (b)
{
    try
    {
        userSelectionCinema = int.Parse(Console.ReadLine()) - 1;
        chosenCinema = company.Theatres[userSelectionCinema];
        Console.Clear();
        Console.WriteLine(chosenCinema.Name);
        int counter = 0;
        for (int j = 0; j < company.Theatres[userSelectionCinema].Sessions.Count; j++)
        {

            //i need something that only selects the movies that i want. (which is userselection)

            if (chosenFilm.ToString() == theatre1.Sessions[j].Movie.Title)
            {

                Console.WriteLine($"\t{counter + 1}.{theatre1.Sessions[j].StartDateTime}");
                counter++;
            }

        }

      

        b = false;
    }
    catch
    {
        b = true;
        Console.WriteLine("Please select a valid Cinema");
        //need to print the times again when we have created cleaner code.
    }



}

//selecting a valid session time
int userSelectionSession = -1;


var c = true;

while (c)
{
    try
    {
        userSelectionSession = int.Parse(Console.ReadLine()) - 1;
        Console.Clear();
        Console.WriteLine(company.Theatres[userSelectionCinema].Name);
        Console.WriteLine($"\t{company.Theatres[userSelectionCinema].Sessions[userSelectionSession].StartDateTime}");
        int counter = 0;
      
        c = false;
    }
    catch
    {
        c = true;
        Console.WriteLine("Please select a valid session time");
        //need to print the times again when we have created cleaner code.
    }



}
var chosenSession = company.Theatres[userSelectionCinema].Sessions[userSelectionSession];


//now i need code that shows the avaliable seats for the selected session.

// a - f 
// 0 - 10

//lets start with a for loop that just shows a 11 wide and 6 high 

List<Seat> availSeats = chosenSession.GetavaliableSeats(chosenCinema);
int counter2 = 0;
for (char row = 'A'; row < 'G'; row++)
{
    Console.Write("\n");
        Console.Write($"{row} --");

    for (int num = 0; num < 11; num++)
    {
        string seatCheck = $"{row}-{num}";
       

        if (availSeats[counter2].Row == 'X')
        {
            Console.Write($"  [ ]");

        }
        else
        {
            Console.Write($"  [{num}]");
        }

        counter2 ++;
    }
}
Console.WriteLine("");
Console.WriteLine("\nPlease select an avaliable ticket");
// now we need a program that checks if a seat is already taken
string userSelectionTicket = Console.ReadLine();

// NOOOOOOOOOOOOOOOOOOOOOW 
// chosenFilm,chosenCinema,ChosenSession creates my current profile of the person


//TODO: Create the way to select a ticket

//TODO: Create a method to check double bookings when issuing

//TODO: Data creation, excel to here on bookings -- i want to do this next, then i can use my csv reader thingy.

//TODO: There could be an easy way to control booking times with numbers, as supposed to the sesh111 method, even though in my mind that works qutie well.






