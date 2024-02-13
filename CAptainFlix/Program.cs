//we are doing aggerate roots ?!? 


using CAptainFlix;

var company = new Company("Captain Flix");
//Data entry shennaigans ------------------------------------------------------------------------------------
var starWars = company.RegisterMovie("Star Wars","PG",180);
var hangover = company.RegisterMovie("The Hangover", "R", 150);
var oppenheimer = company.RegisterMovie("Oppenheimer", "R", 180);

// two theatres
var theatre1 = company.AddTheatre("Events");
var theatre2 = company.AddTheatre("Hoyts");

for (char  row = 'A'; row <= 'G'; row++)
{
    for(int seatNumber = 0; seatNumber <= 10; seatNumber++)
    {

        theatre1.AddSeat(row, seatNumber);
        theatre2.AddSeat(row, seatNumber);
    }
    
}



//chat gpt to understand how time is inputed into to code.
DateTime one = new DateTime(2024, 2, 14, 14, 30,0,0);
DateTime two = new DateTime(2024, 2, 15, 22, 30, 0, 0, 0);

theatre1.ScheduleSession(one, starWars);
theatre1.ScheduleSession(DateTime.Now, starWars);
theatre1.ScheduleSession(two, hangover);
theatre1.ScheduleSession(DateTime.Now, hangover);
theatre1.ScheduleSession(DateTime.Now, oppenheimer);
theatre1.ScheduleSession(two, oppenheimer);

theatre2.ScheduleSession(two, starWars);
theatre2.ScheduleSession(DateTime.Now, starWars);
theatre2.ScheduleSession(two, hangover);
theatre2.ScheduleSession(DateTime.Now, hangover);
theatre2.ScheduleSession(DateTime.Now, oppenheimer);
theatre2.ScheduleSession(one, oppenheimer);

//Completion of data entry shennaigans ------------------------------------------------------------------------------------


// now a program generates seats for the following (our data entry)

Console.WriteLine("Select a Movie");

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
var userSelectionMovie = company.Movies[userSelection].Title;

//now code that shows the avaliable sessuions for the list of films.


//I want to loop through the threates that are avaliable, show on the screen hoyts and event.
Console.WriteLine("Avaliable Sessions ");
for (int i = 0; i < company.Theatres.Count; i++)
{
    Console.WriteLine($"{i + 1}. {company.Theatres[i].Name}");
    int counter = 0;
    for (int j = 0; j < company.Theatres[i].Sessions.Count; j++)
    {
       
        //i need something that only selects the movies that i want. (which is userselection)
        
        if(userSelectionMovie.ToString() == theatre1.Sessions[j].Movie.Title)
        {
        
            Console.WriteLine($"\t{counter + 1}.{theatre1.Sessions[j].StartDateTime}");
            counter++;
        }
        
    }


}

//showings.











var seat = theatre1.FindSeatByCode("C-3");
//var ticket = session.IssueTicket("Fred", seat);