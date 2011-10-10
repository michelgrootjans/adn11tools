Dear fellow .net devs

If you want to get started with this project, these are the steps to follow:

Get the tests running:
- add a sql database named: MobWars_Test
> msbuild buil.xml
the build should work

Get the web application running:
- add a sql database named: MobWars_Web
> rake db:migrate
> rake db:seed

Special DB operations:
rake db:reset // reset the web database
rake db:migrate 1 // bring the database to version 1
rake db:reset test // resest the test datbase