# CI/CD Demonstration project
![Workflow badge](https://github.com/THirvola/AzureCICDProject/actions/workflows/azure-webapps-dotnet-core.yml/badge.svg)
Accessible [here](https://cicddemoth.azurewebsites.net/)
## Background
This project combines different aspects of a typical web app project such as:
- CI/CD
- Cloud services
- REST API

The project does not itself hold any practical value aside from being a learning experience. 

## Functionalities
The site consists of one page. This simple page includes a button and a number.
When the button is pressed, the server pulls the latest code for the project and rewrites the number in the source code itself. 
After this, the new code is pushed into Github and a Github action starts a workflow run to build and deploy the site with the new number.
That's it. As simple as the functionality itself is, the surrounding structure required is similar to any other cloud web application.