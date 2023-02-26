# Smartwyre Developer Test Instructions

In the 'PaymentService.cs' file you will find a method for making a payment. At a high level the steps for making a payment are:

 1. Lookup the account the payment is being made from.
 2. Check that the account is in a valid state to make the payment.
 3. Deduct the payment amount from the account’s balance and update the account in the database.

What we'd like you to do is refactor the code with the following things in mind:

 - Adherence to SOLID principles
 - Testability
 - Readability
 - The "client" will add many more Payment Types in the future. Determining the payment type should be made as easy and intuitive as possible for developers who will edit this in the future.

We’d also like you to 
 - Add some unit tests to the Smartwyre.DeveloperTest.Tests project to show how you would test the code that you’ve produced 
 - Run the PaymentService from the Smartwyre.DeveloperTest.Runner console application

The only specific 'rules' are:

- The solution should build
- The tests should all pass

You are free to use any frameworks/NuGet packages that you see fit. You should plan to spend around 1 hour completing the exercise.



--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Solution

1) Refactored the Account class to add a Withdraw method and stop Balance from being publicly modifiable.
2) use a factory pattern to find and return a validator, validators all implement the IPaymentSchemeValidator interface.
3) Adding a new validator is as simple as creating a new class that uses the interface and registering it with DI (.AddSingleton<IPaymentSchemeValidator, ExpeditedPaymentsValidator>()).
4) Created an interface for the AccountDataStore and injected it into the PaymentService.
5) Added unit tests around the Account model, PaymentService and validators (I added one validator test class as an example, each one will test its own logic).
6) Added DI setup in Program.cs, I created everything as Singleton just for the example. 

notes: I negated to test the AccountDataStore as it has no logic and implementing that class was not mentioned. 