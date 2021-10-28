# TradingManagment

**Description**

The web application simulates the operation of a beverage vending machine. Drinks are represented by name, picture and cost.
The machine accepts coins in denominations of 1, 2, 5, 10 rubles. Provides the opportunity to buy drinks for an amount equal to or greater than their cost.
The application must have a user and administrative interface.
The user interface assumes the purchase of drinks - depositing the amount with coins, choosing a drink, receiving change. Access to the user interface is free.
The administrative interface should provide tools for managing the machine.

**User interface capabilities**

Add the amount by clicking on the buttons with the denomination of coins (1, 2, 5, 10). If the coin is locked, highlight the corresponding button and block the press. Show the deposited amount.
Choose a drink by clicking on the corresponding picture. At the same time, do not allow to select the finished drinks or drinks, the cost of which exceeds the deposited amount. After selecting a drink, the number of remaining drinks should decrease by one, the number of coins in the vending machine should increase, and the remaining amount should be returned as change. Locked coins may be issued as change.

**Administrative interface capabilities**

Administer the assortment of drinks: add, remove drinks, change their quantity, cost and image
Manage coins in the machine: change the number of coins, block the acceptance of certain coins
Access to the administrative interface using a secret key, which is passed as a parameter in the address bar

