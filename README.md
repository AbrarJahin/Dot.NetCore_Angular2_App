# Welcome to ASP.NET Core

It is a simple Angular2 with Dot.Net Core 1.0.1 App based on -

	http://blog.stevensanderson.com/2016/10/04/angular2-template-for-visual-studio/


## Publishing the app-

	# Remove the publish directory files before start
	dotnet restore
	dotnet build
	dotnet publish

or

After running 'dotnet restore' you'll want to build for each of these like this:

	dotnet publish -r win7-x64
	dotnet publish -r win10-x64
	dotnet publish -r osx.10.10-x64
	dotnet publish -r ubuntu.14.04-x64

And then publish release versions after you've tested, etc.

	dotnet publish -c release -r win7-x64
	dotnet publish -c release -r win10-x64
	dotnet publish -c release -r osx.10.10-x64
	dotnet publish -c release -r ubuntu.14.04-x64

More can be found -

	http://www.hanselman.com/blog/SelfcontainedNETCoreApplications.aspx

### Before publish-

Run Migration-

	dotnet ef migrations add testMigration
	dotnet ef database update

Detail-

	https://damienbod.com/2015/08/30/asp-net-5-with-sqlite-and-entity-framework-7/

A basic tutorial-

	https://stormpath.com/blog/tutorial-entity-framework-core-in-memory-database-asp-net-core


See the result directory with a platform specific dotnet command able to run the app.

## Server Config-

	https://www.microsoft.com/net/core#ubuntu
	https://docs.asp.net/en/latest/publishing/linuxproduction.html

## Entity Framework One To Many-

	http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx

	https://docs.microsoft.com/en-us/ef/core/modeling/relationships#many-to-many

