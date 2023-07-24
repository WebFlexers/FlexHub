# FlexHub
<div align="center">
  <img src="https://i.imgur.com/D4xp3In.png" />
</div>
Flexhub is an interactive web application that allows users to search and chat with others who share similar interests, form workgroups and categorise posts. 
The application uses ASP.NET Core Blazor Server, with an MSSQL database accessed with the help of Entity Framework Core. It includes unit tests in a variety of functions to ensure smooth operation.

<br/>
<br/>

The website can be accessed here: https://flexhub.azurewebsites.net/

## Database Diagram

![DatabaseDiagram](https://github.com/WebFlexers/FlexHub/assets/57811193/b3097330-48c8-4ec8-97d4-7b5818e6e29b)


## Home Page:
![](https://i.imgur.com/q85DBpM.png)

## Authentication

For authentication, the app uses Azure Active Directory (B2C) and Google Authentication, in order to provide a secure and scalable system for managing user credentials. 
Users can log in using their social media accounts (Google+) or create a local account in the system.

![](https://i.imgur.com/MCgpgYF.jpg)

## Posts
One of the main features of flexhub is the ability to search, filter and read posts as well as post yourself. Every post has one or more tags that
help people identify what it's about. 

### Posts Home Page:

![](https://i.imgur.com/cYlQ3Xk.png)

### Search by tags: Music, Mathematics

![](https://i.imgur.com/nCw3opW.png)

### Search by title: Adore

![](https://i.imgur.com/QhC4T2k.png)

### Search by title and tags simultaneously

![](https://i.imgur.com/ntU1MQP.png)

## Realtime messages

Another core feature of Flexhub is the ability to chat with your friends one on one or in group chats. Every time you receive a message from a friend or a group chat
you get a real time notification if you are signed in.

![](https://i.imgur.com/Ze6RMFL.png)

## Posting

### Create Posts Page:

![](https://i.imgur.com/E3LX1PQ.png)

### Empty post validation error

![](https://i.imgur.com/51L3V0u.png)

### No tags selected error

![](https://i.imgur.com/yqmK3Nu.png)

### Successful post creation

![](https://i.imgur.com/HEjezzj.png)

### The newly created post when searched

![](https://i.imgur.com/yXUUhM3.png)
