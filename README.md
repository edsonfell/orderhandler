# Order Handler

Order Handler is an API responsible for distributing the orders to it respective area in the kitchen. It is only a little part of the restaurant complex system.


### Requirements to run the project
It was built with .Net Core, so you should be able to run the project in any OS since you have installed the .Net Core 3.1 runtime or it SDK. To run and edit the project you can use the Visual Studio 2019 or any source code editor like Visual Studio Code, Sublime 3, Atom and etc.

#### Installing .Net Core 3.1
- Access the link below and download the latest SDK version of .Net Core 3.1 compatible with you OS.
- https://dotnet.microsoft.com/download/dotnet-core/3.1


#### Building and running with .Net CLI and VS Code
- With you terminal opened, clone the project to any directory you prefer.
- Open your VS Code then click on File -> Open... and select the project folder.
- Let's build the project clicking on Terminal -> New Terminal. In the new terminal below type the following command: **`dotnet build` **
- After this you should see a message like *Build Succeeded*
- Now we are ready to run the project with the following command: **`dotnet run --project OrderRouter/OrderRouter.csproj`**

#### Building and running in Windows with Visual Studio 2019
- With you terminal opened, clone the project to any directory you prefer.
- Open your VS Code then click on File -> Open... and select the project folder.
- Let's try to build the project clicking on Terminal -> New Terminal. In the new terminal window below type the following command: **`dotnet build` **
- After this, you should see a message like *Build Succeeded*
- Now we are ready to run the project with the following command: **`dotnet run --project OrderRouter/OrderRouter.csproj`**

### Available routes
As this project is just a simple API part of the restaurant complex system, we only have a POST route: `https://localhost:5001/orders`
We assume this route will receive the order from the service counter system, so in the request body we send only the product's IDs and the kitchen area ID. See the request body example below:
```json
{
	"Products": 
	[
		{
			"ProductId": 1,
			"KitchenAreaId": 1
		},
		{
			"ProductId": 2,
			"KitchenAreaId": 1
		}
	]
}
```

This route will do the following steps:
- Generate an unique ID for you order;
- Replicate this ID to each product, so the program will be able to manage each product prepare status individually;
- Send each product of the order to it respective area in the kitchen;
- The kitchen area is just a simulated, so immediately it will return that the product is ready;
- The program will update the product prepare status and check if all products of the order has been prepared.
- After all products of the order has been prepared, the program role is over. In the real case, it could alert another system responsible to notify the customers about their orders.

Feel free to submit feedbacks about the code, it structure or even about my english written in this readme file.
