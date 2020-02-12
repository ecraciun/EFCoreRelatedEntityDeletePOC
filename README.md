# EFCoreRelatedEntityDeletePOC

I'm going to keep things short and simple. This is a proof of concept demo solution for a potential Entity Framework Core (2.2 & 3.1) I stumbled upon.

### Running the demo
- load in your favorite IDE
- restore packages
- build solution
- open up DemoDbContext and change the connection string to the SQL database you want to use
- depending on which version you want to test, run the corresponding migration to set up the database
- run

### Context

Let's say we have 3 classes: A,B,C (named like this).

A and C both contains a B instance.

Since this is a code first example the generated db will have 3 tables As, Bs, Cs with As and Cs having a nullable foreing key to Bs.

And let's say this setup is used in a web app and we want to update an A and a C which both have a B and remove those B(s) from them.
 
### Expected behavior

I would expect that once I detected that a delete of B happened on either A or C and I applied the update (removing the foreign key value) of A/C and the delete of B on the EF context, when I call SaveChanges EF generates the correct SQL commands in the correct order.

### Observed behavior

In reality for the A case it works, for the C case it doesn't. 
Apparently, form what I was able to make out, the statements are generated in the alphabetical order of the affected tables of the tracked entities. 
Until now I was certain that EF checks the dependencies of the tracked entities in order to apply the changes in the expected sequence, so I find this a bit baffling.