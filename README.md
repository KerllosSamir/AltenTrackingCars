# Alten Tracking Cars

## This solution is used to track customer vehicles status whether it's connected or not,you can filter vehicles by customer or status.

### I've used the below technolgies to develope this solution:
#### - MS VS 2015.
#### - MS SQL Server 2014.
#### - MS SignalR for pushing status.
#### - MS Web API2.
#### - Entity Framework.
#### - Bootstrap.
#### - MS Membership for authentication.
#### - KnockoutJS.



### Also kindly find below steps to run this solution on your local machine

-	Use visual studio 2015 to open the application.
-	Restore data bases (DB/AltenChallenge.bak) to your SQL server 2014 or higher.
-	Modify web.config connection strings(DefaultConnection, AltenChallengeEntities) of below applications to point to your instance name with the right login information.
•	TrackingCars.Web
•	TrackingCars.Tests
-	Run TrackingServer.SignalR hub console application, this application is used to push vehicle status to web client and it opens port 8089 on the local host.
•	TrackingServerSignalR.EXE
-	Run Tracking Cars web application and use the below credentials to log in.
•	User name : admin@admin.com
•	Password :P@ssW0rd

Screenshot from the application after successful deployment

![screen](https://user-images.githubusercontent.com/31819932/36504985-dc8b71f2-175a-11e8-9dd1-1127e0e6c531.PNG)
