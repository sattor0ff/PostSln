using Domain.Models;
using Infrastructure.Services;

System.Console.WriteLine("Insert: show, insert, update, delete.");

var postService = new PostService();
int counter = 1;
while(true)
{
    string option = Console.ReadLine();
    if(option == "stop") break;

    _ = option switch
    {
        "show" => Show(),
        "update" => Update(),
        "delete" => Delete(),
        "insert" => Insert(),
        _ => false,
    };
    System.Console.WriteLine("\nInsert: show, insert, update, delete.\n");
}


bool Show()
{
    var posts = postService.GetPosts();
    System.Console.WriteLine($"Id     Title     Description     VoteAmount     CreatedAt");
    foreach(var cour in posts)
    {
        System.Console.WriteLine($"{cour.Id}       {cour.Title}     {cour.Description}     {cour.VoteAmount}     {cour.CreatedAt}");
    }
    return true;
}

bool Insert()
{
    var console = new Post(counter);
    System.Console.Write("Your Title: ");
    console.Title = Console.ReadLine();

    System.Console.Write("Your Description: ");
    console.Description = Console.ReadLine();

    System.Console.Write("Your VoteAmount: ");
    console.VoteAmount = Convert.ToInt32(Console.ReadLine());

    //System.Console.Write("Your CreatedAt: ");
    console.CreatedAt = DateTime.Now;

    postService.AddPost(console);
    counter++;

    return true;
}

bool Update()
{
    System.Console.Write("Post ID for Update: ");
    int id = Convert.ToInt32(Console.ReadLine());
    var post = new Post(id);
    System.Console.Write("Your Updated Title: ");
    post.Title = Console.ReadLine();

    System.Console.Write("Your Updated Description: ");
    post.Description = Console.ReadLine();

    System.Console.Write("Your VoteAmount: ");
    post.VoteAmount = Convert.ToInt32(Console.ReadLine());

    //System.Console.Write("Created At: ");
    post.CreatedAt = DateTime.Now;

    postService.UpdatePost(post);
    return true;
}

bool Delete()
{
    System.Console.Write("Post ID to Delete: ");
    int id = Convert.ToInt32(Console.ReadLine());
    postService.Delete(id);
    return true;
}