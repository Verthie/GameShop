# E-commerce web application
An application that allows you to manage a computer game store
## Project description
The theme of the project is to create a complete online store that specializes in selling computer games.  
The system allows to manage the assortment by adding, editing and deleting products, browse available games, as well as add them to a shopping cart and create an order.
## Functions
- Displaying the game catalog
  - The store presents to users a list of available games with their detailed information, such as: title, description, price, manufacturer, publisher and image
- Adding, editing and deleting products
  - The administrator has the ability to add new products to the store, edit existing products (e.g. change description, price, image) and delete outdated items
- Registration and account management
  - Users can register in the store
  - After logging in, users have the option to change their e-mail address or password
  - Users also get the option to delete their account, which removes all related information
- Shopping cart and price calculation
  - Users can add selected games to the shopping cart, and the system automatically calculates the total price of the order based on the number of products and their prices. The total price is dynamically updated when items are added or removed from the shopping cart.
- Placing orders
  - Users with the roles of Customer or Company can place orders
  - Administrators can finalize orders by providing necessary information, such as supplier name and tracking number
- Managing orders
  - Adminstrator can view all placed orders, filter them by order status, and update order data
  - A user with the Company role can cancel an order
  - Once the product is shipped, the store marks the order as completed
## User data for testing
The project contains a roles which are assigned to user accounts, they determine various functions and permissions available on the site:
- Users with the Customer role:
  - Login: test@mail.com – Password: zaq1@WSX
- Users with the Admin role:
  - Login: ja@szef.pl – Password: zaq1@WSX
- Users with the Company role:
  - Login: boss@kierownik.com – Password: zaq1@WSX
  - Login: firma@xz.com – Password: zaq1@WSX
## Database diagram
![image](https://github.com/Verthie/GameShop/assets/47531645/10eefc20-300b-49fe-9e77-43044ce7efd9)
## User interface
![image](https://github.com/Verthie/GameShop/assets/47531645/f7221091-1406-4a3d-8e05-72ffd3a1bcc3)
![image](https://github.com/Verthie/GameShop/assets/47531645/e1f2e4e1-5d95-4382-b009-8a6d619dd5cb)
![image](https://github.com/Verthie/GameShop/assets/47531645/eb44b2b2-fe20-404f-825b-d348743dfa20)
![image](https://github.com/Verthie/GameShop/assets/47531645/2966f765-7718-40bd-aa1e-5761aaa22aa1)

