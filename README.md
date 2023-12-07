# OrderDelayAnnouncement

This project is designed for customers who have not yet received their orders. 
To use this project, you can first execute the script provided in the source code on the SQL Server database ( script file is in root of project ) or you can use migration and then run the project.

Several services have been created for you. These services allow you to store information about vendors, customers, and agents details. With this foundational data, you can use the order creation service to create orders. you can set minute to delivery . After creating a certain number of orders, you can initiate a trip using the trip services. Additionally, there are services for delays, assigning delays to agents, and also get reports of store delays.

This project has dockerfile , so you can use it to run . also contains some unit and integration tests . 
