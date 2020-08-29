# Event-Planner-API-.Net-Core
This is an api written in .net core for a CRUD application for events that also implements authentication with JWT


# Appsettings.json
add the follow to the appsettings.json file to run the application  
  "ConnectionStrings": {  
    "EventsDatabase": "Server=SERVERCONNECTION;Database=Events;Trusted_Connection=True"  
  },  
  "Jwt": {  
    "Key": "supersecretkeyhastobeverylong",  
    "Issuer": "EventsAuthenticationServer",  
    "Audience": "EventsServicePostmanClient",  
    "Subject": "EventsServiceAccessToken"  
  }  
