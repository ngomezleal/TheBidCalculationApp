# Challenge: The Bid Calculation
App developed in c#.net. This app allow to calculate fee with the vehicle basic price and vehicle type (Common or Luxury). This application will allow a buyer to calculate the total price of a vehicle at a car auction. The software must consider several costs in the calculation. On the other hand, this one is connected with SQLserver through docker instance.

## SQLServer DataBase
	1.- Sql server docker container previously configured.
	2.- Change the Connection String using your credentials.
    3.- It is important to execute the migration. This command is onñy update-database.

## Docker Container
	1.- The current project has configured the network called bidnetwork. it is important to attach to the container network instance, sql server and other containers if you want.

## AppSettings
	1.- If your front is running in a different port to 4200, you should change in: appsettings.Development.json.

## Fake Data
	1.- If you don't want to use Sql server, you should use the fake data.
    2.- In program.cs you should change the dependency. it mean for example:.
        builder.Services.AddScoped<IBasicFeeService, BasicFeeService>();
        For
        builder.Services.AddScoped<IBasicFeeService, BasicFeeFakeDataService>();

## Unit Test
	1.- You can execute unit test through of the folloging methods:
        AssociationFeeTest: GetAllAssociationFee
        BidCalculationTest: BidCalculation_VehiclePrice1000_Common
        BidCalculationTest: BidCalculation_VehiclePrice398_Common
        BidCalculationTest: BidCalculation_VehiclePrice1000000_Luxury

## FrontEnd (Run)
	1.- Update the environment files with the url backend
    2.- This files are: environment.development.ts and environment.ts
    3.- Command to execute the front app: ng serve -o
    4.- The app will run on http://localhost:4200