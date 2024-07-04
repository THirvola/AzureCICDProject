using CliWrap;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using TatunBlazorApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

//initializing the repository
/*
Repository repo = new Repository("path");
repo.Index.Add("newFile.txt");
Commands.Stage(repo, "newFile.txt");
Signature sign = new Signature("name", "email", DateTimeOffset.Now);
repo.Commit("Automated commit by the app", sign, sign);

//Remote remote = repo.Network.Remotes.Add("origin", "https://github.com/THirvola/AzureCICDProject.git");

if (repo.Head.Commits != null && repo.Head.Commits.Any())
{
    Remote remote = repo.Network.Remotes["origin"];

    var pushOptions = new PushOptions
    {
        CredentialsProvider = new CredentialsHandler(
        (url, usernameFromUrl, types) =>
            new UsernamePasswordCredentials()
            {
                Username = "username",
                Password = "pass",
            }
    ),
    };
    repo.Network.Push(remote, "refs/heads/master", pushOptions);
}
System.Console.WriteLine(repo.Head.Tip.Message);
*/
//cliwrap test
//todo: test if cliwrap works on local machine
CommandResult result = await Cli.Wrap("git").WithArguments("add --all").ExecuteAsync();
if (result.IsSuccess)
{
    result = await Cli.Wrap("git").WithArguments("commit -m \"Automated commit by the application\"").ExecuteAsync();
    if (result.IsSuccess)
    {
        result = await Cli.Wrap("git").WithArguments("push origin master").ExecuteAsync();
        if (result.IsSuccess)
        {
            System.Console.WriteLine("Successfully added, committed and pushed");
        }
    }
}



//todo: if works on local, try to get git on azure machine

app.Run();
